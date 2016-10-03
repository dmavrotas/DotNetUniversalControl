using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

#if WINDOWS_PHONE_APP
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;
using Windows.Devices.Geolocation;
using Windows.UI;
#elif WINDOWS_APP
using Bing.Maps;
using Windows.UI;
using Windows.Devices.Geolocation;
#endif

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _1st
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Geolocator geolocator = null;
        private Geoposition position = null;

        public MainPage()
        {
            this.InitializeComponent();

            GetPosition();
        }

        private async void GetPosition()
        {
            geolocator = new Geolocator();

            position = await geolocator.GetGeopositionAsync();
        } 

        private void ToggleTrafficBtn_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var toggle = sender as AppBarToggleButton;

            MyMap.ShowTraffic = toggle.IsChecked.HasValue && toggle.IsChecked.Value;
        }

        private void AddPushpinsBtn_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var locs = GetSamplePoints();

            for (int i = 0; i < locs.Count; i++)
            {
                MyMap.AddPushpin(locs[i], (i + 1).ToString());
            }
        }

        private void ClearMapBtn_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MyMap.ClearMap();
        }

        private List<BasicGeoposition> GetSamplePoints()
        {
            var center = MyMap.Center.Position;
            List<BasicGeoposition> locs = null;

            if (position != null)
            {
                center.Latitude = position.Coordinate.Latitude;
                center.Longitude = position.Coordinate.Longitude;

                locs = new List<BasicGeoposition>();
                locs.Add(new BasicGeoposition() { Latitude = center.Latitude, Longitude = center.Longitude });
            }

            return locs;
        }

        private Color GetRandomColor()
        {
            var rand = new Random();

            byte[] bytes = new byte[3];
            rand.NextBytes(bytes);

            return Color.FromArgb(150, bytes[0], bytes[1], bytes[2]);
        }
    }
}
