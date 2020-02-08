using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlakBox.Models {
    public class UpdateSettings : INotifyPropertyChanged {



        public string ItemName { get; set; } = "";
        public string ItemDescription { get; set; } = "";
        public string SetValue { get; set; } = "";
        public string TextColor { get; set; } = "Black";

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged() {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }


        public List<UpdateSettings> GetUpdateSettings() {
            List<UpdateSettings> TabItems = new List<UpdateSettings>() {
                new UpdateSettings(){
                    ItemName="Name:",
                    ItemDescription="Filename",
                },

                new UpdateSettings(){
                    ItemName="Size:",
                    ItemDescription="Size of file",
                },

                new UpdateSettings(){
                    ItemName="MD5:",
                    ItemDescription="MD5 hash",
                },

                new UpdateSettings(){
                    ItemName="Version:",
                    ItemDescription="Version number",
                },

                new UpdateSettings(){
                    ItemName="Type:",
                    ItemDescription="File Type",
                },

            };
            return TabItems;
        }




    }
}
