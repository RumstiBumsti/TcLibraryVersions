using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Collections;
using System.Diagnostics;
using Octokit;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using System.Collections.Generic;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;

namespace TcLibraryVersions
{
    class Program
    {
        public class Options
        {
            [Option('d', "direct", Required = false,
                                    HelpText = "Change Readme File direct on github without cloning on the local disk. Therefore you have to either clone the repo on your github account or have an access token to my repo.",
                                    SetName = "direct")]
            public bool Direct { get; set; }

            [Option('p', "push", Required = false,
                                    HelpText = "Clones repo to your local disk and makes a pull request after updating the table.",
                                    SetName = "push")]
            public bool Push { get; set; }

            [Option('l', "local", Required = false,
                                    HelpText = "Creates a table which is saved in C:\\Temp. You can update the table ob github then manually.",
                                    SetName = "local")]
            public bool Local { get; set; }

            [Option('c', "commit", Required = false,
                                    HelpText = "Clones repo to your local disk and commits the changes. The Pull request has to be done manually.",
                                    SetName = "commit")]
            public bool Commit { get; set; }

            [Option('m', "manually", Required = false,
                                    HelpText = "Insert the Personal Access Token manually. (And not via an environment variable)")]
            public bool Manually { get; set; }


            [Option('t', "transpose", Required = false,
                                      HelpText = "Transpose the table.")]
            public bool Transpose { get; set; }

        }



        static async Task Main(string[] args)
        {
            // ############### Check Options ###################
            bool directUpload = false, cloneRepo = true, push = false, inputTokenManually = false, transposeTable = false;
            checkOptions(args, out directUpload, out cloneRepo, out push, out inputTokenManually, out transposeTable);

            // ############### Get informations of the current installed system ###################
            string TcVersion;
            ArrayList libs, latestVersion;
            int index;
            checkLocalLibraries(out TcVersion, out libs, out latestVersion, out index);

            string headline, secondLine;
            string[] versionLines;           

            
            if (directUpload)
            {
                // ############################################################
                // ############### Update Table directly on Github ###################
                // ############################################################

                string fullText;
                string currentText;
                string cred;
                string sha;

                // Enter GitHub Username
                Console.Write("Enter your Github username: ");
                string userName = Console.ReadLine();

                var (owner, repoName, filePath, branch) = (userName, "TcLibraryVersions", "README.md", "main");

                var gitHubClient = new GitHubClient(new ProductHeaderValue("TcLibraryVersions"));
                if (inputTokenManually)
                {
                    // manual input of Personal Access Token
                    Console.WriteLine("Please insert your Personal Access Token of Github");
                    cred = Console.ReadLine();
                }
                else
                {
                    // Input via environment variable
                    cred = Environment.GetEnvironmentVariable("GITHUBKEY");
                }
                gitHubClient.Credentials = new Octokit.Credentials(cred);

                if (userName.Equals("RumstiBumsti"))
                {
                    // If i do the changes i do not need to fork
                    var tuple = await getReadmeFromGithub(inputTokenManually, gitHubClient);
                    currentText = tuple.Item1;
                    sha = tuple.Item2;
                }
                else
                {
                    // everybody else has to fork the repo first
                    var newRepositoryFork = new NewRepositoryFork();
                    try
                    {
                        await gitHubClient.Repository.Forks.Create("RumstiBumsti", "TcLibraryVersions", new NewRepositoryFork());
                    }
                    catch (Octokit.AuthorizationException)
                    {
                        Console.WriteLine("Invalid Credentials");
                        System.Environment.Exit(0);
                    }
                    
                    var contents = await gitHubClient.Repository.Content.GetAllContentsByRef(owner, repoName, filePath, branch);
                    sha = contents.First().Sha;
                    currentText = contents.First().Content;
                }
                

                ArrayList tcVersions;
                ArrayList[] ghVersions;
                createVersionArrayLists(libs, latestVersion, TcVersion, currentText, out tcVersions, out ghVersions);
                createTopLines(libs, tcVersions, out headline, out secondLine, transposeTable);

                if (!currentText.Contains(TcVersion))
                {
                    versionLines = createVersionlinesFromArrayLists(TcVersion, tcVersions, libs, ghVersions, transposeTable);
                    writeLocalTable(ref headline, ref secondLine, versionLines);
                    fullText = currentText.Substring(0, currentText.IndexOf("|TcVersion|")) + headline + secondLine;

                    foreach (string vline in versionLines)
                    {
                        fullText += vline;
                    }

                    if (userName.Equals("RumstiBumsti"))
                    {
                        await updateReadmeOnGithub(fullText, TcVersion, sha, gitHubClient);
                    }
                    else
                    {
                        string commitMessage = "inserted entry for Twincat Version: " + TcVersion;

                        try
                        {
                            var updateRequest = new UpdateFileRequest(commitMessage, fullText, sha, branch);
                            var updatefile = await gitHubClient.Repository.Content.UpdateFile(owner, repoName, filePath, updateRequest);
                            NewPullRequest newPr = new NewPullRequest(commitMessage, userName+":main", "main");
                            await gitHubClient.PullRequest.Create("RumstiBumsti", "TcLibraryVersions", newPr);
                        }
                        catch (Octokit.NotFoundException)
                        {
                            Console.WriteLine("Seems like the github Client does not have the permissions to write the readme file");
                            System.Environment.Exit(0);
                        }                        
                    }
                }
                else
                {
                    Console.WriteLine("Version already exists in table.");
                }

            }
            else if (cloneRepo || push)
            {
                // #####################################################################################################################
                // ############### Clone repo, perform changes and commit. if option is active also push the changes ###################
                // #####################################################################################################################
                LibGit2Sharp.Repository repo;
                
                string path = @"c:\temp\TcLibraryVersions";
                clone(path);

                string currentText = File.ReadAllText(path + "\\readme.md");

                ArrayList tcVersions;
                ArrayList[] ghVersions;

                createVersionArrayLists(libs, latestVersion, TcVersion, currentText, out tcVersions, out ghVersions);
                createTopLines(libs, tcVersions, out headline, out secondLine, transposeTable);

                if (!currentText.Contains(TcVersion))
                {
                    versionLines = createVersionlinesFromArrayLists(TcVersion, tcVersions, libs, ghVersions, transposeTable);

                    writeLocalTable(ref headline, ref secondLine, versionLines);

                    string fullText = "";
                    fullText = currentText.Substring(0, currentText.IndexOf("|TcVersion|")) + headline + secondLine;
                    foreach (string vline in versionLines)
                    {
                        fullText += vline;
                    }

                    if (File.Exists(path + "\\readme.md"))
                    {
                        File.Delete(path + "\\readme.md");
                    }

                    //Create the file.
                    using (FileStream fs = File.Create(path + "\\readme.md"))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(fullText);
                        fs.Write(info, 0, info.Length);
                    }

                    Console.Write("Enter your Github username: ");
                    string userName = Console.ReadLine();

                    commit(path, out repo, userName, TcVersion);

                    if (push)
                    {
                        pushChanges(inputTokenManually, repo, userName);
                    }
                }
                else
                {
                    Console.WriteLine("Informations for current TcVersion already exist.");
                }
            }
            else
            {
                // ############################################################
                // ############### Just write a local table ###################
                // ############################################################
                ArrayList tcVersions = new ArrayList();
                ArrayList[] ghVersions = new ArrayList[1];
                ghVersions[0] = new ArrayList();
                ghVersions[0] = latestVersion;
                tcVersions.Add(TcVersion);

                versionLines = createVersionlinesFromArrayLists(TcVersion, tcVersions, libs, ghVersions, transposeTable);
                createTopLines(libs, tcVersions, out headline, out secondLine, transposeTable);
                writeLocalTable(ref headline, ref secondLine, versionLines);
            }
        }

        private static void pushChanges(bool inputToken, LibGit2Sharp.Repository repo, string userName)
        {
            string accessToken = "";

            if (inputToken)
            {
                Console.Write("Enter your access token: ");
                accessToken = Console.ReadLine();
            }
            else
            {
                accessToken = Environment.GetEnvironmentVariable("GITHUBKEY");
            }            


            LibGit2Sharp.PushOptions options = new LibGit2Sharp.PushOptions();
            options.CredentialsProvider = new CredentialsHandler(
                (url, usernameFromUrl, types) =>
                    new UsernamePasswordCredentials()
                    {
                        Username = userName,
                        Password = accessToken
                    });
            try
            {
                repo.Network.Push(repo.Branches["main"], options);
            }
            catch (LibGit2Sharp.LibGit2SharpException)
            {
                Console.WriteLine("Invalid Credentials!");
                System.Environment.Exit(0);
            }
            
        }

        private static void clone(string path)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

            // Delete the directory if it exists.
            if (Directory.Exists(path))
            {
                setFileAttributesNormal(dir);
                Directory.Delete(path, true);
            }

            var cloneResult = LibGit2Sharp.Repository.Clone(@"https://github.com/RumstiBumsti/TcLibraryVersions", path);
        }

        private static void commit(string path, out LibGit2Sharp.Repository repo, string userName, string TcVersion)
        {
            // ############### commit the readme file ###################
            Console.Write("Enter your email adress: ");
            string email = Console.ReadLine();
            string commitMessage = "inserted entry for Twincat Version: " + TcVersion;

            repo = new LibGit2Sharp.Repository(path);
            repo.Index.Add("Readme.md");
            repo.Commit(commitMessage, new LibGit2Sharp.Signature(userName, email, DateTimeOffset.Now),
                                            new LibGit2Sharp.Signature(userName, email, DateTimeOffset.Now));
        }

        public static void setFileAttributesNormal(DirectoryInfo dir)
        {
            foreach (var subDir in dir.GetDirectories())
                setFileAttributesNormal(subDir);
            foreach (var file in dir.GetFiles())
            {
                file.Attributes = FileAttributes.Normal;
            }
        }

        private static void createTopLines(ArrayList libs, ArrayList tcVersions, out string headline, out string secondLine, bool transposed)
        {
            if (transposed)
            {
                
                headline = "|TcVersion|";
                secondLine = "|---|";                
                foreach (string version in tcVersions)
                {
                    headline += version + "|";
                    secondLine += "---|";
                }
            }
            else
            {
                headline = "|TcVersion|";
                secondLine = "|---|";
                foreach (string lib in libs)
                {
                    headline += lib + "|";
                    secondLine += "---|";
                }
            }
            
        }

        private static async Task<Tuple<string,string>> getReadmeFromGithub(bool inputToken, GitHubClient gitHubClient)
        {
            var (owner, repoName, filePath, branch) = ("RumstiBumsti", "TcLibraryVersions", "README.md", "main");
            var currentFileText = "";
            IReadOnlyList<RepositoryContent> contents = null;

            try
            {
                // try to get the file (and with the file the last commit sha)
                contents = await gitHubClient.Repository.Content.GetAllContentsByRef(owner, repoName, filePath, branch);
                var targetFile = contents.First();

                if (targetFile.EncodedContent != null)
                {
                    currentFileText = Encoding.UTF8.GetString(Convert.FromBase64String(targetFile.EncodedContent));
                }
                else
                {
                    currentFileText = targetFile.Content;
                }
            }
            catch (Octokit.NotFoundException)
            {
                // The file should exist ... so in this case there might are missing some permissions
                Console.WriteLine("Seems like the github Client does not have the permissions to write the readme file");
            }
            catch (Octokit.AuthorizationException)
            {
                if (inputToken)
                {
                    Console.WriteLine("The Personal Access Token is not valid.");
                }
                else
                {
                    Console.WriteLine("The Environment Variable GITHUBKEY is not set or the key is not valid.");
                }
                System.Environment.Exit(0);
            }

            return new Tuple<string, string>(currentFileText,contents.First().Sha);
        }

        private static async Task updateReadmeOnGithub(string fullText, string TcVersion, string sha, GitHubClient gitHubClient)
        {
            var (owner, repoName, filePath, branch) = ("RumstiBumsti", "TcLibraryVersions", "README.md", "main");

            try
            {
                string commitMessage = "inserted entry for Twincat Version: " + TcVersion;
                var updateRequest = new UpdateFileRequest(commitMessage, fullText, sha, branch);
                var updatefile = await gitHubClient.Repository.Content.UpdateFile(owner, repoName, filePath, updateRequest);
            }
            catch (Octokit.NotFoundException)
            {
                // The file should exist ... so in this case there might are missing some permissions
                Console.WriteLine("Seems like the github Client does not have the permissions to write the readme file");
            }
        }

        private static void createVersionArrayLists(ArrayList libs, ArrayList latestVersion, string TcVersion, string currentFileText, out ArrayList tcVersions, out ArrayList[] ghVersions)
        {
            string ghHeadline = currentFileText.Substring(currentFileText.IndexOf("|TcVersion|") + 10);
            string linebreak = ghHeadline.IndexOf("\n") >= 0 ? "\n" : "\r\n";
            ghHeadline = ghHeadline.Substring(0, ghHeadline.IndexOf(linebreak));

            MatchCollection headlineMatches;
            MatchCollection libVersionMatches;
            MatchCollection libMatches;
            MatchCollection tcVersionMatches;
            ArrayList ghLibs = new ArrayList();
            tcVersions = new ArrayList();
            ArrayList[] ghVersionsTemp;
            string[] lines;

            string pattern = @"([0-9]{3,}.[0-9]+)";
            headlineMatches = Regex.Matches(ghHeadline, pattern);

            // find out if the currentext has a normal or transposed table
            if(headlineMatches.Count > 0)
            {
                // The table is transposed
                pattern = @"(\|)([0-9]{3,}.[0-9]+)";
                tcVersionMatches = Regex.Matches(ghHeadline, pattern);

                pattern = @"Tc[0-9]_[A-Z,a-z,0-9,_]+";
                libMatches = Regex.Matches(currentFileText, pattern);

                lines = new string[libMatches.Count];
                for (int i = 0; i < libMatches.Count; i++)
                {
                    int startOfString = currentFileText.IndexOf(libMatches[i].Value) + libMatches[i].Value.Length;

                    if (i < libMatches.Count - 1)
                    {
                        int uhuh = currentFileText.IndexOf(libMatches[i + 1].Value);
                        lines[i] = currentFileText.Substring(startOfString, currentFileText.IndexOf(libMatches[i + 1].Value) - startOfString - 2);
                    }
                    else
                    {
                        lines[i] = currentFileText.Substring(currentFileText.IndexOf(libMatches[i].Value) + libMatches[i].Value.Length);
                    }
                }

                ghVersionsTemp = new ArrayList[libMatches.Count];
                

                pattern = @"[0-9,.]{4,}|--";
                for (int i = 0; i < libMatches.Count; i++)
                {
                    libVersionMatches = Regex.Matches(lines[i], pattern);

                    ghVersionsTemp[i] = new ArrayList();

                    ghLibs.Add(libMatches[i].Value);

                    for (int j = 0; j < tcVersionMatches.Count; j++)
                    {
                        ghVersionsTemp[i].Add(libVersionMatches[j].Value);
                    }
                }
                ghVersionsTemp = transposeArrayListTable(ghVersionsTemp);
            }
            else
            {
                pattern = @"[A-Z,a-z,0-9,_]+";
                headlineMatches = Regex.Matches(ghHeadline, pattern);
                // The table is not transposed
                pattern = @"(\|)([0-9]{3,}.[0-9]+)(\|)";
                tcVersionMatches = Regex.Matches(currentFileText, pattern);

                lines = new string[tcVersionMatches.Count];
                for (int i = 0; i < tcVersionMatches.Count; i++)
                {
                    int startOfString = currentFileText.IndexOf(tcVersionMatches[i].Value) + tcVersionMatches[i].Value.Length;

                    if (i < tcVersionMatches.Count - 1)
                    {
                        lines[i] = currentFileText.Substring(startOfString, currentFileText.IndexOf(tcVersionMatches[i + 1].Value) - startOfString - 2);
                    }
                    else
                    {
                        lines[i] = currentFileText.Substring(startOfString);
                    }
                }

                ghVersionsTemp = new ArrayList[tcVersionMatches.Count];

                pattern = @"[0-9,.]{4,}|--";
                for (int i = 0; i < tcVersionMatches.Count; i++)
                {
                    libVersionMatches = Regex.Matches(lines[i], pattern);

                    ghVersionsTemp[i] = new ArrayList();

                    for (int j = 0; j < headlineMatches.Count; j++)
                    {
                        if (i == 0)
                        {
                            ghLibs.Add(headlineMatches[j].Value);
                        }
                        ghVersionsTemp[i].Add(libVersionMatches[j].Value);
                    }
                }
            }            

            // ############### Edit the table ###################
            for (int i = 0; i < ghLibs.Count; i++)
            {
                if (libs.Count > i)
                {
                    if (!ghLibs[i].Equals(libs[i]))
                    {
                        // Do we have an additional lib or do we have missing libs??
                        StringComparer sc = StringComparer.CurrentCultureIgnoreCase;
                        int j = 0;
                        while (!ghLibs[i].Equals(libs[i + j]) && sc.Compare(ghLibs[i], libs[i + j]) > 0)
                        {
                            j++;
                        }

                        // if while exit in the first loop, we have less libs in libs[], else we have addditional
                        if (j == 0)
                        {
                            libs.Insert(i, ghLibs[i]);
                            latestVersion.Insert(i, "--");
                        }
                        else
                        {
                            for (int k = 0; k < j; k++)
                            {
                                ghLibs.Insert(i + k, libs[i + k]);
                                for (int l = 0; l < tcVersionMatches.Count; l++)
                                {
                                    ghVersionsTemp[l].Insert(i + k, "--");
                                }
                            }
                        }
                    }
                }
                else
                {
                    libs.Insert(i, ghLibs[i]);
                    latestVersion.Insert(i, "--");
                }
            }

            if (libs.Count > ghLibs.Count)
            {
                for (int i = ghLibs.Count; i < libs.Count; i++)
                {
                    ghLibs.Insert(i, libs[i]);
                    for (int l = 0; l < tcVersionMatches.Count; l++)
                    {
                        ghVersionsTemp[l].Insert(i, "--");
                    }
                }
            }

            // Consolidate the ArrayLists 
            System.Version currentVersion = System.Version.Parse(TcVersion);
            ghVersions = new ArrayList[tcVersionMatches.Count+1];
            bool insertedNewLine = false;

            for (int i = 0; i < tcVersionMatches.Count+1; i++)
            {
                ghVersions[i] = new ArrayList();
                if (i != tcVersionMatches.Count || insertedNewLine)
                {
                    System.Version tempVersion = System.Version.Parse(tcVersionMatches[i - Convert.ToInt32(insertedNewLine)].Groups[2].Value);
                    if (currentVersion.CompareTo(tempVersion) > 0 && !insertedNewLine)
                    {
                        insertedNewLine = true;
                        ghVersions[i]=latestVersion;
                        tcVersions.Add(TcVersion);
                    }
                    else
                    {
                        ghVersions[i]= ghVersionsTemp[i - Convert.ToInt32(insertedNewLine)];
                        tcVersions.Add(tempVersion.ToString());
                    }
                }
                else
                {
                    insertedNewLine = true;
                    ghVersions[i]=latestVersion;
                    tcVersions.Add(TcVersion);
                }
            }
        }

        private static ArrayList[] transposeArrayListTable(ArrayList[] ghVersions)
        {
            ArrayList[] transposedList = new ArrayList[ghVersions[0].Count];

            for (int i = 0; i < ghVersions.Length; i++)
            {
                for (int j = 0; j < ghVersions[0].Count; j++)
                {
                    if (i == 0)
                    {
                        transposedList[j] = new ArrayList();
                    }
                    transposedList[j].Add(ghVersions[i][j]);
                }

            }

            return transposedList;
        }

        private static string[] createVersionlinesFromArrayLists(string TcVersion, ArrayList tcVersions, ArrayList libs, ArrayList[] ghVersions, bool transpose)
        {
            string[] versionLines;
            if (transpose)
            {
                ghVersions = transposeArrayListTable(ghVersions);
                versionLines = new string[libs.Count];

                for (int i = 0; i < libs.Count; i++)
                {
                    versionLines[i] = "|" + libs[i] + "|";
                    for (int j = 0; j < tcVersions.Count; j++)
                    {
                        versionLines[i] += ghVersions[i][j] + "|";
                    }
                }
            }
            else
            {
                versionLines = new string[tcVersions.Count];

                for (int i = 0; i < tcVersions.Count; i++)
                {
                    versionLines[i] = "|" + tcVersions[i].ToString() + "|";
                    for (int j = 0; j < ghVersions[0].Count; j++)
                    {
                        versionLines[i] += ghVersions[i][j].ToString() + "|";
                    }
                }
            }
            
            return versionLines;
        }

        private static void checkLocalLibraries(out string TcVersion, out ArrayList libs, out ArrayList latestVersion, out int index)
        {
            TcVersion = "";

            // Check the product version of TCATSysSrv.exe
            try
            {
                var versionInfo = FileVersionInfo.GetVersionInfo(@"C:\TwinCAT\3.1\System\TCATSysSrv.exe");
                TcVersion = versionInfo.ProductBuildPart.ToString() + "." + versionInfo.ProductPrivatePart.ToString();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Twincat Path not found on System");
                System.Environment.Exit(0);
            }

            // root Directory for the installed libs
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo("C:\\TwinCAT\\3.1\\Components\\Plc\\Managed Libraries\\Beckhoff Automation GmbH");
            System.IO.DirectoryInfo[] dirs = root.GetDirectories("*");

            libs = new ArrayList();
            latestVersion = new ArrayList();
            index = 0;

            // Go through all libs and save the latest version
            foreach (System.IO.DirectoryInfo dir in dirs)
            {
                libs.Add(dir.Name);
                System.IO.DirectoryInfo[] subDirs = dir.GetDirectories("*");

                System.Version latestVersionNumber = new System.Version();

                foreach (System.IO.DirectoryInfo subDir in subDirs)
                {
                    System.Version ver = System.Version.Parse(subDir.Name);
                    if (latestVersionNumber.CompareTo(ver) < 0)
                    {
                        latestVersionNumber = ver;
                    }
                }

                // build the string for the latest version of lib[intdex]
                latestVersion.Add(latestVersionNumber.ToString());

                index++;
            }
        }

        private static void checkOptions(string[] args, out bool directUpload, out bool cloneRepo, out bool push, out bool inputTokenManually, out bool transposeTable)
        {
            ParserResult<Options> parser = null;
            parser = Parser.Default.ParseArguments<Options>(args);


            bool directUploadTemp = true, cloneRepoTemp = false, pushTemp = false, inputTokenManuallyTemp = true, transposeTableTemp = true;

            parser.WithParsed<Options>(o =>
            {
                if (o.Direct)
                {
                    directUploadTemp = true;
                    inputTokenManuallyTemp = false;
                    cloneRepoTemp = false;
                }
                if (o.Local)
                {
                    cloneRepoTemp = false;
                    inputTokenManuallyTemp = false;
                    directUploadTemp = false;
                }
                if (o.Push)
                {
                    directUploadTemp = false;
                    pushTemp = true;
                    cloneRepoTemp = true;
                }
                if (o.Commit)
                {
                    directUploadTemp = false;
                    pushTemp = false;
                    cloneRepoTemp = true;
                }
                if(o.Manually && !o.Local)
                {
                    inputTokenManuallyTemp = true;
                }
                if (o.Transpose)
                {
                    transposeTableTemp = true;
                }

            });

            directUpload = directUploadTemp;
            push = pushTemp;
            cloneRepo = cloneRepoTemp;
            inputTokenManually = inputTokenManuallyTemp;
            transposeTable = transposeTableTemp;
        }

        private static void writeLocalTable(ref string headline, ref string secondLine, string[] versionLines)
        {
            // Generates teh file and inserts all information provided in the parameters
            string path = @"c:\temp\TcLibVersions.txt";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            headline += "\n";
            secondLine += "\n";

            //Create the file.
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, headline);
                AddText(fs, secondLine);
                for (int i = 0; i < versionLines.Count(); i++)
                {
                    versionLines[i] += "\n";
                    AddText(fs, versionLines[i]);
                }
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            // Adds text to the filestream
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
