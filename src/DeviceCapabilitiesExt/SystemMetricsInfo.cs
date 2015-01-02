using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System.Device
{

    public class SystemMetricsInfo
    {

        [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        protected static extern int GetSystemMetrics(InternalDeviceMode deviceMode);

        public static DeviceUseMode GetDeviceSlateMode()
        {

            DeviceUseMode mode;

            try
            {
                if (Convert.ToBoolean(GetSystemMetrics(InternalDeviceMode.SM_CONVERTIBLESLATEMODE)))
                {
                    mode = DeviceUseMode.Laptop;
                }
                else
                {
                    mode = DeviceUseMode.Tablet;
                }
            }
            catch (Exception)
            {
                mode = DeviceUseMode.Unknown;
            }

            return mode;
            
        }

        public static bool IsDocked()
        {
            bool docked;

            try
            {
                if (Convert.ToBoolean(GetSystemMetrics(InternalDeviceMode.SM_CONVERTIBLESLATEMODE)))
                {
                    docked = true;
                }
                else
                {
                    docked = false;
                }
            }
            catch (Exception)
            {
                docked = false;
            }

            return docked;
        }

    }
}
