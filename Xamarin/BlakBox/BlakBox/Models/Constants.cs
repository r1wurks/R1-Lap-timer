using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace BlakBox.Models {
    public static class Constants {
        public static bool isDev = true;
        //public static Color BackgroundColor = Color.FromRgb(58,153,215);
        //public static Color MainTextColor = Color.White;
        //public static int LoginIconHeight = 120;

        public static string    TAG                     = "---BlakBox---";
        public static string    SystemFirmwareVersion   = "APP v1.0.0.0";

        public static string    DEFAULT_IPaddress       = "192.168.0.50";
        public static string    DEFAULT_ConnRetries     = "3";



        public static string    ServerPort              = "3500";

        public static string    address_get_esc_all     = "get_esc_all";
        public static string    address_set_value       = "set_value";
        public static string    address_get_value       = "get_value";
        public static string    address_get_version     = "get_version";
        public static string    address_flash_esc       = "flash_esc";



        public static string    error_string            = "";

        public static UInt32    API_Get_ESC_All         = 0x0100;
        public static UInt32    API_Get_WiFi_All        = 0x0500;

        public static UInt32    API_Save_ESC            = 0x3101;
        public static UInt32    API_Save_WiFi           = 0x3102;
        public static UInt32    API_Save_ESC_WiFi       = 0x3103;
        public static UInt32    API_RestoreDefaults     = 0x3104;


        public static string    SYSTEM_PREF_IPaddress   = "IP_Address";
        public static string    SYSTEM_PREF_ConnRetries = "Conn_Retries";
    }
}
