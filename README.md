DeviceExtCapabilitiesUniversal
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
