using System;
using System.Diagnostics;
using BlakBox.Data;
using BlakBox.Models;
using BlakBox.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlakBox {

    public partial class App : Application {
        static RestService restService;


        public App() {
            InitializeComponent();
            DebugSend("------------------===         START         ===------------------");
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }





        public static RestService RestService {
            get {
                if (restService == null) {
                    restService = new RestService();
                }
                return restService;
            }
        }

        public void DebugSend(string tag, string message) {
            Debug.WriteLine("\n");
            Debug.WriteLine("\n");
            Debug.WriteLine(Constants.TAG + "  -  " + tag + ":    " + message);
            Debug.WriteLine("\n");
            Debug.WriteLine("\n");
        }

        public void DebugSend(string message) {
            Debug.WriteLine("\n");
            Debug.WriteLine("\n");
            Debug.WriteLine(Constants.TAG + ":    " + message);
            Debug.WriteLine("\n");
            Debug.WriteLine("\n");
        }


        public int get_ConnRetries() {
            // Get default connection retries

            int retVal = 0;
            string preferenceValue;

            preferenceValue = Preferences.Get(Constants.SYSTEM_PREF_ConnRetries, Constants.DEFAULT_ConnRetries);

            if (int.TryParse(preferenceValue, out retVal)) {
                return retVal;
            } else {
                int.TryParse(Constants.DEFAULT_ConnRetries, out retVal);
                return retVal;
            }
        }

        public string get_ServerFullAddress() {
            // Get default connection retries

            string retVal = "";
            string preferenceValue;

            preferenceValue = Preferences.Get(Constants.SYSTEM_PREF_IPaddress, Constants.DEFAULT_IPaddress);

            retVal = "http://" + preferenceValue + ":" + Constants.ServerPort + "/";

            return retVal;
        }

    }


}