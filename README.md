# TcLibraryVersions

The TwinCAT remote manager facilitates developing in a production environment where multiple version of TwinCAT are used simultaniously. This is achieved by switching the TwinCAT version directly in the the integrated-development-environment (IDE, e.g. TwinCAT XAE).
However, when installing TwinCAT with a specific version it comes with a large number of libraries in a specific version. With multiple version of TwinCAT installed, there is no real way to tell, which TwinCAT Version comes with what library version.

In a supportable production-environment this information is crucial for maintaining stability. When a harddrive crashes it is desirable to go back to the exact version of all libraries that were used in the PLC with a CI system. Some times it may make no real difference, but in a production-environment the PLCs of some machines may be pretty old and upgrading them to a new library version may introduce undesirable sideeffects, e.g. some bugs in a new library version could have been fixed. As allows in development ["somebody's bug, may be somebody's feature"](https://xkcd.com/1172/) and thus, it is not always beneficial to update to a new version.

Since Beckhoff does not officially provide any information about the "TwinCAT version" - "library version" relationship, this repository is used to provide this information to developers.

# TwinCAT versions and the library versions it ships with

|TcVersion|4024.55|4024.54|4024.53|4024.50|4024.47|4024.44|4024.42|4024.40|4024.35|4024.32|4024.29|4024.25|4024.22|4024.20|4024.17|4024.12|4022.29|4022.22|4022.16|4022.4|4020.39|
|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|
|Tc2_BA|3.4.1.0|3.4.1.0|3.4.1.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.1.12.0|3.1.8.1|3.1.6.0|3.1.6.0|3.1.3.0|
|Tc2_BABasic|3.2.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.2.0|3.1.1.0|3.1.1.0|3.1.1.0|3.1.0.0|3.1.0.0|
|Tc2_BACnetRev12|2.6.2.0|2.6.2.0|2.6.2.0|2.6.2.0|2.6.2.0|2.6.2.0|2.5.20.0|2.5.20.0|2.5.20.0|2.5.19.0|2.5.19.0|2.5.18.1|2.5.18.1|2.5.18.1|2.5.18.1|2.5.18.1|2.5.6.0|2.5.0.3|2.4.3.0|2.4.3.0|2.4.3.0|
|Tc2_CncBase|3.3.3031.13|3.3.3031.13|3.3.3031.13|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.9|3.3.3031.9|3.3.3031.7|3.3.3031.6|3.3.3031.2|
|Tc2_CncHli|3.3.3031.54|3.3.3031.54|3.3.3031.54|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.43|3.3.3031.42|3.3.3031.41|3.3.3031.30|3.3.3031.26|3.3.3031.25|3.3.3031.23|3.3.3031.10|
|Tc2_CncPlcopenP1|3.3.3031.14|3.3.3031.14|3.3.3031.14|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.11|3.3.3031.8|3.3.3031.8|3.3.3031.8|3.3.3031.8|3.3.3031.3|
|Tc2_CncPlcopenP4|3.3.3031.13|3.3.3031.13|3.3.3031.13|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.10|3.3.3031.9|3.3.3031.9|3.3.3031.8|3.3.3031.8|3.3.3031.1|
|Tc2_ControllerToolbox|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.1.4|3.4.1.4|3.4.1.4|3.4.1.4|3.4.1.4|
|Tc2_Coupler|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|
|Tc2_DALI|3.7.2.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.18.0|3.6.11.0|3.6.7.0|3.6.5.0|3.6.2.0|3.4.3.0|
|Tc2_Database|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|3.3.20.2|
|Tc2_DataExchange|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|
|Tc2_DMX|3.6.4.0|3.6.3.0|3.6.3.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.5.0|3.5.4.0|3.5.4.0|
|Tc2_Drive|3.3.11.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.9.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.7.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|
|Tc2_EIB|3.4.2.0|3.4.2.0|3.4.2.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.9.0|3.3.7.0|3.3.6.0|3.3.5.0|3.3.5.0|
|Tc2_EnOcean|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|
|Tc2_EtherCAT|3.4.3.0|3.4.3.0|3.4.2.0|3.4.2.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.20.0|3.3.19.0|3.3.19.0|3.3.16.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.10.0|3.3.10.0|
|Tc2_EthernetIP|1.1.1.0|1.1.1.0|1.1.1.0|1.1.1.0|1.1.1.0|1.0.3.0|1.0.3.0|1.0.3.0|1.0.3.0|1.0.3.0|1.0.3.0|1.0.3.0|1.0.3.0|1.0.3.0|1.0.3.0|1.0.2.0|1.0.2.0|1.0.1.0|1.0.1.0|1.0.1.0|1.0.1.0|
|Tc2_FTP|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|3.3.5.2|
|Tc2_GENIbus|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|
|Tc2_HVAC|3.4.2.0|3.3.9.0|3.3.9.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|--|--|--|--|--|
|Tc2_IoFunctions|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.13.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|
|Tc2_KL85xx|3.5.4.0|3.5.2.0|3.5.2.0|3.5.2.0|3.5.2.0|3.5.2.0|3.5.2.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.6.0|3.4.5.0|3.3.4.0|
|Tc2_LON|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|
|Tc2_Math|3.4.3.0|3.4.3.0|3.4.3.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|
|Tc2_MBus|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.7.0|3.4.6.0|
|Tc2_MC2|3.3.59.0|3.3.56.0|3.3.56.0|3.3.56.0|3.3.54.0|3.3.54.0|3.3.53.0|3.3.50.0|3.3.48.0|3.3.48.0|3.3.46.0|3.3.46.0|3.3.45.0|3.3.45.0|3.3.45.0|3.3.42.0|3.3.29.0|3.3.23.0|3.3.21.0|3.3.18.0|3.3.18.0|
|Tc2_MC2_Camming|3.4.0.0|3.3.19.0|3.3.19.0|3.3.19.0|3.3.19.0|3.3.19.0|3.3.18.0|3.3.18.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.11.0|3.3.7.0|3.3.7.0|3.3.6.0|3.3.4.0|3.3.4.0|
|Tc2_MC2_Drive|3.3.36.0|3.3.34.0|3.3.34.0|3.3.34.0|3.3.32.0|3.3.31.0|3.3.31.0|3.3.31.0|3.3.29.0|3.3.26.0|3.3.25.0|3.3.25.0|3.3.24.0|3.3.23.0|3.3.23.0|3.3.22.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.14.0|3.3.9.0|
|Tc2_MC2_FlyingSaw|3.3.6.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|3.3.0.0|
|Tc2_MC2_XFC|3.3.25.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.22.0|3.3.21.0|3.3.19.0|3.3.19.0|3.3.18.0|3.3.18.0|3.3.18.0|3.3.17.0|3.3.17.0|3.3.15.0|3.3.15.0|3.3.13.0|3.3.13.0|
|Tc2_MDP|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.7.0|3.3.6.0|3.3.6.0|3.3.5.0|3.3.5.0|3.3.5.0|
|Tc2_ModbusRTU|3.5.6.0|3.5.6.0|3.5.6.0|3.5.6.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.2.0|3.4.2.0|3.4.2.0|3.4.2.0|3.4.2.0|3.4.2.0|3.4.2.0|3.4.2.0|3.4.2.0|
|Tc2_ModbusSrv|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|
|Tc2_MPBus|3.6.4.0|3.6.4.0|3.6.3.0|3.6.3.0|3.6.1.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.12.0|3.4.11.0|3.4.9.0|3.4.8.0|3.4.7.0|3.4.7.0|
|Tc2_NC|3.3.7.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.2.0|3.3.2.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|
|Tc2_NcDrive|3.3.6.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.4.0|3.3.4.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|
|Tc2_NcFifoAxes|3.3.5.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|
|Tc2_NCI|3.3.17.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.12.0|3.3.11.0|3.3.10.0|3.3.8.0|
|Tc2_NciXFC|3.3.9.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.5.0|3.3.5.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|
|Tc2_OpcUa|3.3.2.0|3.3.2.0|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|3.3.2.0|
|Tc2_PlcInterpolation|3.3.20.0|3.3.18.0|3.3.18.0|3.3.18.0|3.3.18.0|3.3.18.0|3.3.18.0|3.3.18.0|3.3.16.0|3.3.16.0|3.3.16.0|3.3.16.0|3.3.16.0|3.3.16.0|3.3.16.0|3.3.16.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.14.0|
|Tc2_ProfinetDiag|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.2.0|1.2.2.0|1.2.2.0|1.2.2.0|1.2.2.0|
|Tc2_RFID|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.6.0|3.3.6.0|3.3.4.0|3.3.4.0|3.3.4.0|
|Tc2_S5S7Com|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|
|Tc2_SerialCom|3.4.1.0|3.4.1.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.8.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|
|Tc2_SMI|3.4.2.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|3.3.7.0|
|Tc2_SMS|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|
|Tc2_Smtp|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|
|Tc2_SPA|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|
|Tc2_Standard|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|
|Tc2_SUPS|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.5.0|
|Tc2_System|3.6.2.0|3.6.2.0|3.5.3.0|3.5.3.0|3.5.3.0|3.5.3.0|3.4.26.0|3.4.26.0|3.4.26.0|3.4.25.0|3.4.25.0|3.4.25.0|3.4.24.0|3.4.24.0|3.4.24.0|3.4.24.0|3.4.21.0|3.4.19.0|3.4.17.0|3.4.17.0|3.4.17.0|
|Tc2_SystemC69xx|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|
|Tc2_SystemCX|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.8.0|3.4.7.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.4.0|
|Tc2_TcpIp|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.10.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.6.0|3.3.4.0|3.3.3.0|3.3.3.0|3.3.3.0|
|Tc2_TempController|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.4.0|3.3.3.0|3.3.3.0|3.3.3.0|
|Tc2_Utilities|3.6.1.0|3.5.2.0|3.4.8.0|3.4.8.0|3.3.54.0|3.3.54.0|3.3.54.0|3.3.54.0|3.3.54.0|3.3.52.0|3.3.52.0|3.3.50.0|3.3.47.0|3.3.46.0|3.3.42.0|3.3.41.0|3.3.35.0|3.3.28.0|3.3.26.0|3.3.22.0|3.3.22.0|
|Tc2_XmlDataSrv|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|
|Tc3_Analytics|--|--|3.1.6.1|3.1.6.1|3.1.6.1|3.1.5.0|3.1.5.0|3.1.5.0|--|--|--|--|--|--|--|--|--|--|--|--|--|
|Tc3_AnalyticsCommunication|3.1.3.0|3.1.3.0|3.1.3.0|3.1.3.0|3.1.3.0|3.1.3.0|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|
|Tc3_AnalyticsStorageProvider|1.0.1.0|1.0.1.0|1.0.1.0|1.0.1.0|1.0.1.0|1.0.1.0|1.0.1.0|1.0.0.12|1.0.0.12|1.0.0.12|--|--|--|--|--|--|--|--|--|--|--|
|Tc3_BA|1.2.1.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.5.0|1.1.1.0|--|--|--|--|
|Tc3_BA_Common|2.2.3.0|2.2.3.0|2.2.3.0|2.2.3.0|2.1.5.2|2.1.5.2|2.1.5.2|2.1.5.2|2.1.5.2|2.1.5.2|2.1.5.2|2.1.5.2|2.1.4.0|2.1.4.0|2.1.4.0|2.1.4.0|1.0.5.0|--|--|--|--|
|Tc3_BA2|5.3.6.0|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|
|Tc3_BA2_Common|2.2.12.0|2.2.10.0|2.2.6.0|2.2.6.0|2.1.20.0|2.1.20.0|2.1.20.0|2.1.19.0|2.1.17.0|2.1.16.0|2.1.14.0|2.1.14.0|2.1.11.0|2.1.11.0|2.1.9.0|2.1.3.23|--|--|--|--|--|
|Tc3_BACnetRev14|4.2.20.0|4.2.20.0|4.2.20.0|4.2.7.0|4.2.4.0|4.2.2.0|4.1.26.0|4.1.26.0|4.1.26.0|4.1.24.0|4.1.19.0|4.1.19.0|4.1.17.0|4.1.16.0|4.1.9.0|4.0.22.12|--|--|--|--|--|
|Tc3_DALI|3.18.1.0|3.17.1.0|3.17.1.0|3.17.1.0|3.16.1.0|3.13.0.0|3.13.0.0|3.13.0.0|3.13.0.0|3.12.0.0|3.11.0.0|3.10.5.0|3.9.0.0|3.8.0.0|3.6.2.0|3.5.0.0|3.1.4.0|--|--|--|--|
|Tc3_Database|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.19|3.4.0.15|3.4.0.15|3.4.0.15|3.4.0.15|3.3.0.21|3.3.0.14|3.3.0.14|3.3.0.14|3.3.0.14|
|Tc3_DriveMotionControl|3.0.11.0|3.0.10.0|3.0.10.0|3.0.10.0|3.0.9.0|3.0.9.0|3.0.7.0|3.0.7.0|3.0.6.0|3.0.5.0|3.0.5.0|3.0.4.0|3.0.3.0|3.0.3.0|3.0.3.0|3.0.3.0|--|--|--|--|--|
|Tc3_DynamicMemory|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|--|--|--|--|--|
|Tc3_EtherCATExtSync|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|3.3.0.0|
|Tc3_EventLogger|3.3.7.0|3.1.33.0|3.1.33.0|3.1.33.0|3.1.33.0|3.1.33.0|3.1.33.0|3.1.33.0|3.1.33.0|3.1.30.0|3.1.30.0|3.1.30.0|3.1.30.0|3.1.28.0|3.1.28.0|3.1.24.0|3.1.19.0|3.1.16.0|3.0.3.0|3.0.3.0|3.0.3.0|
|Tc3_Interfaces|--|--|--|--|--|--|--|--|--|--|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.3.0|3.4.2.0|3.4.2.0|3.4.2.0|
|Tc3_IoLink|3.4.2.0|3.4.2.0|3.4.2.0|3.4.2.0|3.4.2.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.3.0|3.3.2.0|3.3.1.5|3.3.1.5|--|--|--|--|--|--|--|--|--|
|Tc3_IotBase|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.1.19.0|3.1.19.0|3.1.19.0|3.1.19.0|3.1.19.0|3.1.19.0|3.1.19.0|3.1.18.0|3.1.18.0|3.1.18.0|3.1.18.0|3.1.18.0|3.1.7.0|3.1.7.0|3.1.5.0|3.1.5.0|--|
|Tc3_IotCommunicator|1.2.2.0|1.2.2.0|1.2.2.0|1.2.2.0|1.1.16.0|1.1.16.0|1.1.16.0|1.1.16.0|1.1.15.0|1.1.12.0|1.1.12.0|1.1.12.0|1.1.10.0|1.1.10.0|1.1.10.0|1.0.7.0|1.0.7.0|1.0.7.0|1.0.7.0|1.0.4.0|--|
|Tc3_IotFunctions|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|3.3.1.0|--|--|--|
|Tc3_IPCDiag|1.1.3.0|1.1.3.0|1.1.3.0|1.1.3.0|1.0.15.0|1.0.15.0|1.0.15.0|1.0.14.0|1.0.12.0|1.0.11.0|1.0.11.0|1.0.11.0|1.0.9.0|1.0.9.0|1.0.8.0|1.0.5.0|--|--|--|--|--|
|Tc3_JsonXml|3.4.3.0|3.4.3.0|3.3.19.0|3.3.19.0|3.3.19.0|3.3.19.0|3.3.19.0|3.3.18.0|3.3.18.0|3.3.18.0|3.3.17.0|3.3.16.0|3.3.15.0|3.3.14.0|3.3.14.0|3.3.14.0|3.3.4.0|3.3.3.3|3.3.3.3|3.3.3.1|--|
|Tc3_LS|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.2.3.0|1.1.12.0|1.1.12.0|1.1.12.0|1.1.9.0|1.1.9.0|1.1.9.0|1.1.9.0|1.1.6.0|1.1.6.0|1.1.6.0|1.1.5.0|--|--|--|--|--|
|Tc3_MC2_AdvancedHoming|3.0.24.0|3.0.23.0|3.0.23.0|3.0.23.0|3.0.21.0|3.0.20.0|3.0.20.0|3.0.20.0|3.0.18.0|3.0.15.0|3.0.14.0|3.0.13.0|3.0.13.0|3.0.13.0|3.0.13.0|3.0.13.0|3.0.10.0|3.0.8.0|3.0.8.0|3.0.7.0|3.0.5.0|
|Tc3_MC2_AdvancedHoming_XFC|3.0.9.0|3.0.8.0|3.0.8.0|3.0.8.0|3.0.8.0|3.0.8.0|3.0.8.0|3.0.8.0|3.0.6.0|3.0.6.0|3.0.6.0|3.0.6.0|3.0.6.0|3.0.6.0|3.0.6.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.3.0|
|Tc3_MemMan|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|3.3.1.0|
|Tc3_MLL|3.2.3.0|3.2.3.0|3.2.3.0|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|
|Tc3_Module|3.3.23.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.23.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.21.0|3.3.20.0|3.3.18.0|3.3.18.0|3.3.17.0|3.3.16.0|
|Tc3_mxAutomation|2.1.3.5|2.1.3.5|2.1.3.4|2.1.3.4|2.1.3.4|2.1.3.4|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.3|2.1.3.2|2.1.3.2|2.1.3.2|
|Tc3_mxAutomationV3_0|3.0.4.2|3.0.4.2|3.0.4.1|3.0.4.1|3.0.4.1|3.0.4.1|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.4.0|3.0.2.0|--|--|--|--|
|Tc3_mxAutomationV3_1|3.1.0.2|3.1.0.2|3.1.0.1|3.1.0.1|3.1.0.1|3.1.0.1|3.1.0.0|3.1.0.0|3.1.0.0|3.1.0.0|3.1.0.0|3.1.0.0|3.1.0.0|3.1.0.0|3.1.0.0|3.1.0.0|--|--|--|--|--|
|Tc3_mxAutomationV3_2|3.2.0.3|3.2.0.3|3.2.0.2|3.2.0.2|3.2.0.2|3.2.0.2|3.2.0.1|3.2.0.1|3.2.0.1|3.2.0.1|3.2.0.1|3.2.0.1|3.2.0.1|3.2.0.1|3.2.0.1|--|--|--|--|--|--|
|Tc3_mxAutomationV3_3|3.3.1.2|3.3.1.2|3.3.1.1|3.3.1.1|3.3.1.1|3.3.1.1|3.3.1.1|3.3.1.0|--|--|--|--|--|--|--|--|--|--|--|--|--|
|Tc3_OpcUa|--|--|--|--|--|--|--|--|--|--|1.0.0.24|1.0.0.24|1.0.0.24|1.0.0.24|1.0.0.24|--|--|--|--|--|--|
|Tc3_PackML|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.5.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|3.3.3.0|
|Tc3_PackML_V2|3.3.17.0|3.3.17.0|3.3.17.0|3.3.17.0|3.3.17.0|3.3.17.0|3.3.17.0|3.3.17.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.15.0|3.3.14.0|3.3.11.0|3.3.8.0|3.3.8.0|3.3.8.0|3.3.8.0|
|Tc3_PLCopen_OpcUa|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.3.2.0|3.2.12.0|3.2.12.0|3.2.12.0|3.2.11.0|3.2.10.0|3.2.10.0|3.2.10.0|3.2.9.0|3.2.9.0|3.2.9.0|3.1.7.0|3.1.7.0|3.1.7.0|3.1.7.0|3.1.6.0|
|Tc3_RealtimeMonitoring|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|1.0.2.0|--|--|--|--|--|
|Tc3_Units|--|--|1.0.0.3|1.0.0.3|1.0.0.3|1.0.0.2|1.0.0.2|1.0.0.2|--|--|--|--|--|--|--|--|--|--|--|--|--|
|Tc3_uniValPlc|3.1.0.6|3.1.0.6|3.1.0.5|3.1.0.5|3.1.0.5|3.1.0.5|3.1.0.4|3.1.0.4|3.1.0.4|3.1.0.4|3.1.0.4|3.1.0.4|3.1.0.4|3.1.0.4|3.1.0.4|3.1.0.2|3.1.0.0|3.1.0.0|3.1.0.0|2.3.0.2|2.3.0.2|
|Tc3_uniValPlc_v4|4.1.1.7|4.1.1.7|4.1.1.6|4.1.1.6|4.1.1.6|4.1.1.6|4.1.1.5|4.1.1.5|4.1.1.5|4.1.1.5|4.1.1.5|4.1.1.5|4.1.1.5|4.1.1.5|4.1.1.5|4.1.1.3|4.1.1.1|--|--|--|--|
|Tc3_uniValPlc_v4_3|4.3.0.5|4.3.0.5|4.3.0.4|4.3.0.4|4.3.0.4|4.3.0.4|4.3.0.3|4.3.0.3|4.3.0.3|4.3.0.3|4.3.0.3|4.3.0.3|4.3.0.3|4.3.0.3|4.3.0.3|4.3.0.1|--|--|--|--|--|
|Tc3_uniValPlc_v4_4|4.4.1.5|4.4.1.5|4.4.1.4|4.4.1.4|4.4.1.4|4.4.1.4|4.4.1.3|4.4.1.3|4.4.1.3|4.4.1.3|4.4.1.3|4.4.1.3|4.4.1.3|4.4.1.3|4.4.1.3|4.4.1.0|--|--|--|--|--|
|Tc3_uniValPlc_v4_5|4.5.0.2|4.5.0.2|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|4.5.0.1|--|--|--|--|--|--|
|Tc3_uniValPlc_v4_6|4.6.0.2|4.6.0.2|4.6.0.1|4.6.0.1|4.6.0.1|4.6.0.1|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|
|Tc3_XLS|--|--|--|--|--|--|--|--|--|--|1.0.1.0|1.0.1.0|1.0.1.0|1.0.1.0|1.0.1.0|--|--|--|--|--|--|
|Tc3_XBA|5.5.6.0|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|--|
