using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlakBox.Models {
    public class MotorSettings : INotifyPropertyChanged {
        public string ItemName { get; set; } = "";
        public string ItemDescription { get; set; } = "";
        public string DefaultValue { get; set; } = "";
        public string SetValue { get; set; } = "";
        public string ValueUnit { get; set; } = "";
        public string ValueChoices { get; set; } = "";
        public string ChoicesRange { get; set; } = "";
        public string EnableSwitch { get; set; } = "False";
        public string SwitchValue { get; set; } = "False";
        public string EnablePicker { get; set; } = "False";
        public string PickerName { get; set; } = "";
        public string PickerValue { get; set; } = "0";
        public List<string> PickerList { get; set; } = new List<string>();
        public string TextColor { get; set; } = "Black";
        public UInt32 API_HexCode { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged() {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        public List<MotorSettings> GetESCSettings() {
            List<MotorSettings> TabItems = new List<MotorSettings>() {
                new MotorSettings(){
                    ItemName="ESC Firmware Version",
                    ItemDescription="ESC Firmware Version",
                    SetValue="0",
                    ValueChoices="none",
                    TextColor="Gray",
                },

                new MotorSettings(){
                    ItemName="Acceleration Pulse",
                    ItemDescription="PWM Acceleration Pulse",
                    DefaultValue="2500",
                    SetValue="2500",
                    ValueChoices="integer",
                    ChoicesRange = "1 ~ 5000",
                    API_HexCode = 0x0101,
                },
                new MotorSettings(){
                    ItemName="Neutral Pulse",
                    ItemDescription="PWM Neutral Pulse",
                    DefaultValue="1895",
                    SetValue="1895",
                    ValueChoices="integer",
                    ChoicesRange = "1 ~ 5000",
                    API_HexCode = 0x0102,
                },
                new MotorSettings(){
                    ItemName="Brake Pulse",
                    ItemDescription="PWM Brake Pulse",
                    DefaultValue="1200",
                    SetValue="1200",
                    ValueChoices="integer",
                    ChoicesRange = "1 ~ 5000",
                    API_HexCode = 0x0103,
                },
                new MotorSettings(){
                    ItemName="Enable Battery Check",
                    ItemDescription="Enables battery voltage check",
                    DefaultValue="True",
                    ValueChoices="boolean",
                    ChoicesRange = "True ~ False",
                    EnableSwitch = "True",
                    SwitchValue = "False",
                    API_HexCode = 0x0104,
                },
                new MotorSettings(){
                    ItemName="Battery Low Voltage",
                    ItemDescription="Battery voltage in mV for low voltage detection",
                    DefaultValue="6.1",
                    SetValue="6.1",
                    ValueUnit="V",
                    ValueChoices="float",
                    ChoicesRange = "5.0 ~ 10.0",
                    API_HexCode = 0x0105,
                },
                new MotorSettings(){
                    ItemName="Forward Neutral",
                    ItemDescription="Forward neutral range",
                    DefaultValue="1",
                    SetValue="1",
                    ValueUnit="%",
                    ValueChoices="integer",
                    ChoicesRange = "0 ~ 100",
                    API_HexCode = 0x0106,
                },
                new MotorSettings(){
                    ItemName="Reverse Neutral",
                    ItemDescription="Reverse neutral range",
                    DefaultValue="1",
                    SetValue="1",
                    ValueUnit="%",
                    ValueChoices="percentage",
                    ChoicesRange = "0 ~ 100",
                    API_HexCode = 0x0107,
                },
                new MotorSettings(){
                    ItemName="Throttle Jump Pass",
                    ItemDescription="Throttle jump allowable value change",
                    DefaultValue="100",
                    SetValue="100",
                    ValueUnit="%",
                    ValueChoices="percentage",
                    ChoicesRange = "0 ~ 100",
                    API_HexCode = 0x0108,
                },
                new MotorSettings(){
                    ItemName="Throttle Jump Persistence",
                    ItemDescription="Threshold for number of PWM value outside Throttle Jump Pass before allowing the value",
                    DefaultValue="20",
                    SetValue="20",
                    ValueChoices="integer",
                    ChoicesRange = "0 ~ 50000",
                    API_HexCode = 0x0109,
                },
                new MotorSettings(){
                    ItemName="Motor Direction",
                    ItemDescription="Motor Direction",
                    DefaultValue="CCW",
                    SetValue="CCW",
                    ValueChoices="choices",
                    ChoicesRange = "CW|CCW",
                    EnablePicker="True",
                    PickerName="Picker_Motor_Direction",
                    PickerValue="0",
                    PickerList = new List<string> {"CW", "CCW"},
                    API_HexCode = 0x010A,
                },
                new MotorSettings(){
                    ItemName="Motor Pole Configuration",
                    ItemDescription="Motor pole configuration",
                    DefaultValue="ABC",
                    SetValue="ABC",
                    ValueChoices="choices",
                    ChoicesRange="ABC|CAB",
                    EnablePicker="True",
                    PickerName="Picker_Pole_Configuration",
                    PickerValue="0",
                    PickerList = new List<string> {"ABC", "ACB", "BAC", "BCA", "CBA", "CAB" },
                    API_HexCode = 0x010B,
                },
                new MotorSettings(){
                    ItemName="Motor OverTemp",
                    ItemDescription="Maximum motor temperature threshold",
                    DefaultValue="200",
                    SetValue="200",
                    ValueUnit="°F",
                    ValueChoices="integer",
                    ChoicesRange="0 ~ 200",
                    API_HexCode = 0x010C,
                },
                new MotorSettings(){
                    ItemName="Motor Phase Shift",
                    ItemDescription="Motor pattern phase shift",
                    DefaultValue="0",
                    SetValue="0",
                    ValueChoices="integer",
                    ChoicesRange="0 ~ 5",
                    API_HexCode = 0x010D,
                },
                new MotorSettings(){
                    ItemName="Motor PWM Accel Period",
                    ItemDescription="Motor PWM while accelerating in Hz",
                    DefaultValue="8000",
                    SetValue="8000",
                    ValueUnit="Hz",
                    ValueChoices="integer",
                    ChoicesRange="1000 ~ 32000",
                    API_HexCode = 0x010E,
                },
                new MotorSettings(){
                    ItemName="Motor PWM Brake Period",
                    ItemDescription="Motor PWM while braking in Hz",
                    DefaultValue="8000",
                    SetValue="8000",
                    ValueUnit="Hz",
                    ValueChoices="integer",
                    ChoicesRange="1000 ~ 32000",
                    API_HexCode = 0x010F,
                },
                new MotorSettings(){
                    ItemName="Motor Burst Enable",
                    ItemDescription="Enables Burst Value",
                    DefaultValue="False",
                    ValueChoices="boolean",
                    ChoicesRange = "True ~ False",
                    EnableSwitch = "True",
                    SwitchValue = "False",
                    API_HexCode = 0x0110,
                },
                new MotorSettings(){
                    ItemName="Motor Burst Value",
                    ItemDescription="Enables Burst Value",
                    DefaultValue="4000",
                    SetValue="4000",
                    ValueChoices="integer",
                    ChoicesRange = "0 ~ 65535",
                    API_HexCode = 0x0111,
                },
                new MotorSettings(){
                    ItemName="Motor Throttle Punch",
                    ItemDescription="Motor Throttle starting value",
                    DefaultValue="1",
                    SetValue="1",
                    ValueUnit="%",
                    ValueChoices="percentage",
                    ChoicesRange = "0 ~ 100",
                    API_HexCode = 0x0112,
                },
                new MotorSettings(){
                    ItemName="Motor Brake Punch",
                    ItemDescription="Motor Brake starting value",
                    DefaultValue="1",
                    SetValue="1",
                    ValueUnit="%",
                    ValueChoices="percentage",
                    ChoicesRange = "0 ~ 100",
                    API_HexCode = 0x0113,
                },
            };
            return TabItems;
        }

        public List<MotorSettings> GetWIFISettings() {
            List<MotorSettings> TabItems = new List<MotorSettings>() {
                new MotorSettings(){
                    ItemName="WiFi Firmware Version",
                    ItemDescription="WiFi Firmware Version",
                    SetValue="0",
                    ValueChoices="none",
                    TextColor="Gray",
                },

                new MotorSettings(){
                    ItemName="IP Address",
                    ItemDescription="IP Address to use",
                    DefaultValue="192.168.0.50",
                    SetValue="192.168.0.530",
                    ValueChoices="ip_address",
                    ChoicesRange = "XXX.XXX.XXX.XXX with a max value of 255",
                    API_HexCode = 0x0507,
                },

                new MotorSettings(){
                    ItemName="AP SSID",
                    ItemDescription="Access Point SSID",
                    DefaultValue="BlakBox",
                    SetValue="BlakBox",
                    ValueChoices="name",
                    ChoicesRange = "Alphanumeric (A-Z, 0-9). 4 - 32 Characters",
                    API_HexCode = 0x0503,
                },

                new MotorSettings(){
                    ItemName="AP Password",
                    ItemDescription="Access Point Password",
                    DefaultValue="goatlabs",
                    SetValue="goatlabs",
                    ValueChoices="name",
                    ChoicesRange = "Alphanumeric (A-Z, 0-9). 4 - 32 Characters",
                    API_HexCode = 0x0504,
                },

                new MotorSettings(){
                    ItemName="WiFi Connect",
                    ItemDescription="Connect to Router",
                    DefaultValue="True",
                    SetValue="",
                    ValueChoices="boolean",
                    EnableSwitch = "True",
                    SwitchValue = "True",
                    API_HexCode = 0x0505,
                },

                new MotorSettings(){
                    ItemName="WiFi SSID",
                    ItemDescription="WiFi SSID",
                    DefaultValue="Kuko Ni Diva",
                    SetValue="Kuko Ni Diva",
                    ValueChoices="name",
                    ChoicesRange = "Alphanumeric (A-Z, 0-9). 4 - 32 Characters",
                    API_HexCode = 0x0501,
                },

                new MotorSettings(){
                    ItemName="WiFi Password",
                    ItemDescription="Password for the wifi",
                    DefaultValue="dakilang bajula",
                    SetValue="dakilang bajula",
                    ValueChoices="name",
                    ChoicesRange = "Alphanumeric (A-Z, 0-9). 4 - 32 Characters",
                    API_HexCode = 0x0502,
                },

                new MotorSettings(){
                    ItemName="WiFi Connect Retries",
                    ItemDescription="Maximum number of retries",
                    DefaultValue="5",
                    SetValue="5",
                    ValueChoices="integer",
                    API_HexCode = 0x0506,
                    ChoicesRange = "0 ~ 200",
                },

            };
            return TabItems;
        }

        public List<MotorSettings> GetRestoreSettings() {
            List<MotorSettings> TabItems = new List<MotorSettings>() {
                new MotorSettings(){
                    ItemName="Restore Default Values",
                    ItemDescription="Restores default values",
                    ValueChoices="button",
                    API_HexCode = 0x3104,
                },

            };
            return TabItems;
        }

        public List<MotorSettings> GetSystemSettings() {
            List<MotorSettings> TabItems = new List<MotorSettings>() {
                new MotorSettings(){
                    ItemName="APP Firmware Version",
                    ItemDescription="APP Firmware Version",
                    SetValue=Constants.SystemFirmwareVersion,
                    ValueChoices="none",
                    TextColor="Gray",
                },

                new MotorSettings(){
                    ItemName="IP Address",
                    ItemDescription="IP Address to use",
                    DefaultValue="192.168.0.50",
                    SetValue="0.0.0.0",
                    ValueChoices="ip_address",
                    ChoicesRange = "XXX.XXX.XXX.XXX with a max value of 255",
                },

                new MotorSettings(){
                    ItemName="ESC Connect Retries",
                    ItemDescription="ESC Connect Retries",
                    DefaultValue="5",
                    SetValue="5",
                    ValueChoices="integer",
                    ChoicesRange = "0 ~ 200",
                },
            };
            return TabItems;
        }
    }
}
