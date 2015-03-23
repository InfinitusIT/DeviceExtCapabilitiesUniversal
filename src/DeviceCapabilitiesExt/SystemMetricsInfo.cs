using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Input;

namespace System.Device
{

    public class SystemMetricsInfo
    {

        static SystemMetricsInfo()
        {
            TouchCapabilitiesExt = new TouchCapabilities();
            KeyboardCapabilitiesExt = new KeyboardCapabilities();
            MouseCapabilitiesExt = new MouseCapabilities();
        }

        public static TouchCapabilities TouchCapabilitiesExt { get; set; }

        public static KeyboardCapabilities KeyboardCapabilitiesExt { get; set; }

        public static MouseCapabilities MouseCapabilitiesExt { get; set; }



        [DllImport("user32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        protected static extern int GetSystemMetrics(SystemMetrics deviceMode);

        public static DeviceUseMode GetDeviceSlateMode()
        {

            DeviceUseMode mode;

            try
            {
                var _convertibleSlateMode = GetSystemMetrics(SystemMetrics.SM_CONVERTABLESLATEMODE);

                if (Convert.ToBoolean(_convertibleSlateMode))
                {
                    mode = DeviceUseMode.Normal;
                }
                else
                {

                    var _tabletpc = Convert.ToBoolean(GetSystemMetrics(SystemMetrics.SM_TABLETPC));

                    if (_tabletpc)
                    {
                        mode = DeviceUseMode.Tablet;
                    }
                    else
                    {
                        mode = DeviceUseMode.Normal;
                    }

                    
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
                docked = (Convert.ToBoolean(GetSystemMetrics(SystemMetrics.SM_SYSTEMDOCKED)));
               
            }
            catch (Exception)
            {
                docked = false;
            }

            return docked;
        }

    }
}
