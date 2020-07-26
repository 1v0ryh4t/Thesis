This project can be run with Unity 2018.4.2f1, the windows sdk, access to the windows device portal, and either a Microsoft HoloLens or a Microsoft HoloLens emulator. 
To run this project, open it in Unity, build one of the scenes, HorizBisectScene for example, and select a folder to build the project in. 
Then launch the solution file from that in visual studio. From there, make sure the options “Release”,”x86”, and “Device” are selected if using a HoloLens, 
“emulator” is using an emulator. Then press “Device” to launch the application on the HoloLens, assuming the device is plugged into a USB port and recognized by the computer, 
or press “emulator” to launch an emulator which will launch the project automatically. When this project is done being used, access the windows device portal and go to the path
“System->File Explorer->LocalAppData->HoloHelloWorld->LocalState” to download Entries.txt. 
To modify this project, go to the TanGameObjects->TanScripts folder in the unity project, and modify the scripts.
