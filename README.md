# TcLibraryVersions

The TwinCAT remote manager facilitates developing in a production environment where multiple version of TwinCAT are used simultaniously. This is achieved by switching the TwinCAT version directly in the the integrated-development-environment (IDE, e.g. TwinCAT XAE).
However, when installing TwinCAT with a specific version it comes with a large number of libraries in a specific version. With multiple version of TwinCAT installed, there is no real way to tell, which TwinCAT Version comes with what library version.

In a supportable production-environment this information is crucial for maintaining stability. When a harddrive crashes it is desirable to go back to the exact version of all libraries that were used in the PLC with a CI system. Some times it may make no real difference, but in a production-environment the PLCs of some machines may be pretty old and upgrading them to a new library version may introduce undesirable sideeffects, e.g. some bugs in a new library version could have been fixed. As allows in development ["somebody's bug, may be somebody's feature"](https://xkcd.com/1172/) and thus, it is not always beneficial to update to a new version.

Since Beckhoff officially provide any information about the "TwinCAT version" - "library version" relationship, this repository is used to provide this information to developers.

# TwinCAT versions and the library versions it ships with
