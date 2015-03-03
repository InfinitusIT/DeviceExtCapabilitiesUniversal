using System;
using System.Collections.Generic;
using System.Device;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App.Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public SystemMetricsMonitor Monitor { get; set; }
        
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
           

            Monitor = new SystemMetricsMonitor();

            Monitor.DeviceUseModeChanged += Monitor_DeviceUseModeChanged;
            Monitor.DeviceDockedStatusChanged += Monitor_DeviceDockedStatusChanged;

            Monitor.Start(TimeSpan.FromMilliseconds(1000));
        }

        public void Hide()
        {
            imgiunknow.Visibility = Visibility.Collapsed;
            imgiunknow.Visibility = Visibility.Collapsed;
            imgiunknow.Visibility = Visibility.Collapsed;
        }

        public void Show(UIElement element, bool visible)
        {
            if (visible)
            {
                element.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                element.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            }
        } 

        void Monitor_DeviceDockedStatusChanged(object sender, DeviceDockedStatusEventArgs e)
        {
            tbDeviceDocked.Text = e.IsDocked.ToString();

            
        }

        void Monitor_DeviceUseModeChanged(object sender, DeviceUseModeEventArgs e)
        {

            Hide();

            Show(imgiunknow, e.DeviceUseMode == DeviceUseMode.Unknown);
            Show(imglaptop, e.DeviceUseMode == DeviceUseMode.Normal);
            Show(imgtablet, e.DeviceUseMode == DeviceUseMode.Tablet);

            tbDeviceState.Text = e.DeviceUseMode.ToString();

        }
    }
}
