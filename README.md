# ASCOM-LS-Demo

This is a demo to show an ASCOM Local Server (directly derived from the Rotator Simulator) that only loads internal drivers. You can view the commits for all the changes that I made to convert over.

The primary change is to the LoadComObjectAssemblies function in the LocalServer class. Instead of loading from adjacent dlls it loads from the executing assembly only.
See https://github.com/DanielVanNoord/ASCOM-LS-Demo/commit/3a07b4d92f993ec877a43db3e1695b1e025511f5?branch=3a07b4d92f993ec877a43db3e1695b1e025511f5&diff=split for the details on the changes and the LoadComObjectAssemblies function for the implementation.

To keep the test project as close to the original simulator as possible the driver is still named Driver.cs (normally I would change this for clarity). The only pitfall I know of is that if there are multiple identical drivers in a single project (say two rotators) each would need to be in a different Namespace, just like they already do when they are in separate dlls.

See the https://github.com/DanielVanNoord/Alpaca-CoverCalibrator repository for another example that local loads only and also removes the driver's background WinForm display. Because the Rotator Simulator used the UI to display information it is still displayed in this project. 