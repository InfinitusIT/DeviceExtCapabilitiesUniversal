using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Device
{
    public class DeviceUseModeEventArgs : EventArgs
    {
        public DeviceUseMode DeviceUseMode { get; set; }
    }

    public class DeviceDockedStatusEventArgs : EventArgs
    {
        public bool IsDocked { get; set; }
    }
}
