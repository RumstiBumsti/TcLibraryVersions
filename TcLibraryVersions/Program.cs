using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace TcLibraryVersions
{
    class Program
    {
        static void Main(string[] args)
        {
            string TcVersion;
            System.IO.DirectoryInfo[] dirs = null;

            // root directory for the Twincat version
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo("C:\\TwinCAT\\3.1\\Runtimes\\bin");            
            dirs = root.GetDirectories("*");
            string pattern = @"[0-9]{3,}.[0-9]+";

            // extract the twincat version from the folder name
            Match m = Regex.Match(dirs[0].Name, pattern);
            TcVersion = m.Value;

            // root Directory for the installed libs
            root = new System.IO.DirectoryInfo("C:\\TwinCAT\\3.1\\Components\\Plc\\Managed Libraries\\Beckhoff Automation GmbH");
            dirs = root.GetDirectories("*");

            string[] libs = new string[dirs.Length];
            string[] latestVersion = new string[dirs.Length];

            int index = 0;

            // Go through all libs and save the latest version
            foreach (System.IO.DirectoryInfo dir in dirs)
            {
                libs[index] = new string(dir.Name);
                System.IO.DirectoryInfo[] subDirs = dir.GetDirectories("*");

                Version latestVersionNumber = new Version();

                foreach (System.IO.DirectoryInfo subDir in subDirs)
                {
                    Version ver = Version.Parse(subDir.Name);
                    if (latestVersionNumber.CompareTo(ver)<0)
                    {
                        latestVersionNumber = ver;
                    }                    
                }

                // build the string for the latest version of lib[intdex]
                latestVersion[index] = latestVersionNumber.ToString();                

                index++;
            }


            // Write the information i a file in markup format
            string path = @"c:\temp\TcLibVersions.txt";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Create the file.
            using (FileStream fs = File.Create(path))
            {
                string headline = "|TcVersion|";
                string secondLine = "|---|";
                string thirdLine = "|" + TcVersion;
                index = 0;

                foreach(string lib in libs)
                {
                    headline += lib + "|";
                    secondLine += "---|";
                    thirdLine += "|" + latestVersion[index];
                    index++;
                }

                headline += "\n";
                secondLine += "\n";
                thirdLine += "\n";


                AddText(fs, headline);
                AddText(fs, secondLine);
                AddText(fs, thirdLine);
            }


        }


        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }


    }
}
