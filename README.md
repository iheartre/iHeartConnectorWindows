# iHeart Connector for Windows
iHeart oximeter data connector for Windows Runtime 10/11.
- Reads oximeter data using built-in or external USB Bluetooth adapter. (Bluetooth V4 or higher)
- Displays oximeter data on a chart in real-time.
- Records oximeter data and exports it to CSV or Excel.
- Streams oximeter real-time data via TCP. (localhost:6000)

[Compilied binaries](https://github.com/iheartre/iHeartConnectorWindows/tree/main/Binaries)

[Visula Studio project](https://github.com/iheartre/iHeartConnectorWindows/tree/main/VisualStudioProject)

![Connector](../../../.github/blob/main/profile/assets/images/connector.png)

Uses [SpreadsheetLight](https://www.nuget.org/packages/SpreadsheetLight)
```
Install-Package SpreadsheetLight -Version 3.5.0
```

## [Matlab example](https://github.com/iheartre/iHeartConnectorWindows/tree/main/Matlab%20Example)

Reading oximeter data from iHeartConnectorWindows via TCP.

![Matlab](../../../.github/blob/main/profile/assets/images/matlab_chart.png)

## [LabView example](https://github.com/iheartre/iHeartConnectorWindows/tree/main/LabView%20Example)

Reading oximeter data from iHeartConnectorWindows via TCP.

![LabView](../../../.github/blob/main/profile/assets/images/labview_front.png)


## [Octave example](https://github.com/iheartre/iHeartConnectorWindows/tree/main/Octave%20Example)

Reading oximeter data from iHeartConnectorWindows via TCP.

![Octave](../../../.github/blob/main/profile/assets/images/octave_chart.png)
