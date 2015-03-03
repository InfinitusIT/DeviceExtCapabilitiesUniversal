using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace System.Device
{
    public class SystemMetricsMonitor : INotifyPropertyChanged
    {
        private DispatcherTimer timerMonitor { get; set; }

        public SystemMetricsMonitor()
        {

        }


        public void Start(TimeSpan period)
        {

            Stop();

            timerMonitor = new DispatcherTimer();

            timerMonitor.Interval = period;

            timerMonitor.Tick += timerMonitor_Tick;

            ResetProps();

            timerMonitor.Start();

        }

        private void ResetProps()
        {
            CurrentDeviceUseMode = DeviceUseMode.Unknown;
            CurrentDeviceDockedStatus = false;
        }

        void timerMonitor_Tick(object sender, object e)
        {
            CurrentDeviceUseMode = SystemMetricsInfo.GetDeviceSlateMode();
            CurrentDeviceDockedStatus = SystemMetricsInfo.IsDocked();
        }

        public void Stop()
        {
            if (timerMonitor != null)
            {
                timerMonitor.Stop();
                timerMonitor = null;
            }

        }

        private DeviceUseMode _currentDeviceUseMode;

        public DeviceUseMode CurrentDeviceUseMode
        {
            get { return _currentDeviceUseMode; }
            set
            {
                if (_currentDeviceUseMode != value)
                {
                    EventHandler<DeviceUseModeEventArgs> _deviceUseModeChanged = DeviceUseModeChanged;
                    if (_deviceUseModeChanged != null) { _deviceUseModeChanged(this, new DeviceUseModeEventArgs() { DeviceUseMode = value }); }

                }
                Set(ref _currentDeviceUseMode, value);
            }
        }


        private bool _currentDeviceDockedStatus;

        public bool CurrentDeviceDockedStatus
        {
            get { return _currentDeviceDockedStatus; }
            set
            {
                if (_currentDeviceDockedStatus != value)
                {
                    EventHandler<DeviceDockedStatusEventArgs> _deviceDockedStatusChanged = DeviceDockedStatusChanged;
                    if (_deviceDockedStatusChanged != null) { _deviceDockedStatusChanged(this, new DeviceDockedStatusEventArgs() { IsDocked = value }); }

                }
                Set(ref _currentDeviceDockedStatus, value);
            }
        }



        public event EventHandler<DeviceUseModeEventArgs> DeviceUseModeChanged;
        public event EventHandler<DeviceDockedStatusEventArgs> DeviceDockedStatusChanged;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }




}
