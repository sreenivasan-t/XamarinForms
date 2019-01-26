using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InternetChecking
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetupConnectionListeners();
            //if (CrossConnectivity.Current.IsConnected)
            //{
            //    var bandwidth = CrossConnectivity.Current.Bandwidths;
            //    var layout = new StackLayout { Padding = new Thickness(5, 10) };
            //    var label = new Label { Text = "Bandwidth : ", TextColor = Color.FromHex("#77d065"), FontSize = 20 };
            //    layout.Children.Add(label);
            //    this.Content = layout;
            //}
           
        }

        private static void CurrentOnConnectivityTypeChanged(object sender, ConnectivityTypeChangedEventArgs connectivityTypeChangedEventArgs)
        {
            if (!connectivityTypeChangedEventArgs.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("NO INTERNET CONNECTION");
                return;
            }
                
            var availableConnections = string.Join(",", connectivityTypeChangedEventArgs.ConnectionTypes);
            Console.WriteLine($"Connections available: {availableConnections}");
            
            // TODO: store available connections?
        }

        private static void CurrentOnConnectivityChanged(object sender, ConnectivityChangedEventArgs connectivityChangedEventArgs)
        {
            if (connectivityChangedEventArgs.IsConnected)
            {
                Console.WriteLine($"Connectivity has been restored");
                CrossToastPopUp.Current.ShowToastMessage("INTERNET CONNECTION RESTORED");
                // TODO: maintain connection status"
            }
        }

        private static void SetupConnectionListeners()
        {
            CrossConnectivity.Current.ConnectivityChanged += CurrentOnConnectivityChanged;
            CrossConnectivity.Current.ConnectivityTypeChanged += CurrentOnConnectivityTypeChanged;
        }
    }
}
