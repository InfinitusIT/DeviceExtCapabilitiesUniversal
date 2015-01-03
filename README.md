Device Extensions Capabilities for Universal Apps
==============================

A wrapper for detect a 2in1 convertable's state using C# for Universal Apps. With a basic monitor.

You can download it in nuget:

https://www.nuget.org/packages/DeviceExtCapabilitiesUniversal/

And use like this:

```
  var mode = SystemMetricsInfo.GetDeviceSlateMode(); // Unknown, Laptop, Tablet
  var state = SystemMetricsInfo.IsDocked(); // bool
  
```

or you can use a basic monitor:

```

  public SystemMetricsMonitor Monitor { get; set; }
  
  ...
  
  Monitor = new SystemMetricsMonitor();

  Monitor.DeviceUseModeChanged += Monitor_DeviceUseModeChanged;
  Monitor.DeviceDockedStatusChanged += Monitor_DeviceDockedStatusChanged;

  Monitor.Start(TimeSpan.FromMilliseconds(1000));
  
```

;)


Helpers:

https://github.com/adrianstevens/WPF-CSharp-2in1-mode-detection
http://windowsdeveloper.de/artikel/wpf-erkennen-laptop-tablet-175661

Sample screenshots:

https://raw.githubusercontent.com/daemun/DeviceExtCapabilitiesUniversal/master/src/App.Test/App.Test.Shared/Assets/screenshot1.png

https://raw.githubusercontent.com/daemun/DeviceExtCapabilitiesUniversal/master/src/App.Test/App.Test.Shared/Assets/screenshot2.png
