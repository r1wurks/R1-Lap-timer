using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlakBox.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BlakBox.Data {
    public class RestService {
        HttpClient client;

        public RestService() {
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(20);
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<String> PostResponse(string weburl, string jsonstring) {
            string ContentType = "application/json";

            String post_params = jsonstring.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Replace(":", "=");

            try {
                var result = await client.PostAsync(weburl, new StringContent(post_params, Encoding.UTF8, ContentType));
                if (result.StatusCode == System.Net.HttpStatusCode.OK) {
                    var jsonResult = result.Content.ReadAsStringAsync().Result;
                    return jsonResult;
                }
            } catch {
                return null;
            }

            return null;
        }

        public async Task<String> GetResponse(string weburl) {
            try {
                var response = await client.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;

                    if (String.Equals(jsonResult, Constants.error_string, StringComparison.InvariantCultureIgnoreCase)) {
                        ((App)Application.Current).DebugSend("API REQUEST ERROR", "NONE");
                        return null;
                    } else {
                        return jsonResult;
                    }
                    
                } else {
                    ((App)Application.Current).DebugSend("HTTP REQUEST ERROR", "NONE");
                    return null; // Not Found
                }

            } catch {
                ((App)Application.Current).DebugSend("HTTP REQUEST TIMEOUT", "NONE");
                return null;    // Timeout
            }
        }

        public async Task<String> GetResponse(string weburl, string jsonstring) {
            try {

                String[] get_params = jsonstring.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Replace(":", "=").Split(',');
                string temp_params = string.Join("&", get_params);

                string get_weburl = weburl + "?" + temp_params;

                var response = await client.GetAsync(get_weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;
                    if (String.Equals(jsonResult, Constants.error_string, StringComparison.InvariantCultureIgnoreCase)) {
                        ((App)Application.Current).DebugSend("API REQUEST ERROR", "NONE");
                        return null;
                    } else {
                        return jsonResult;
                    }
                } else {
                    ((App)Application.Current).DebugSend("HTTP REQUEST ERROR", "NONE");
                    return null; // Not Found
                }


            } catch {
                ((App)Application.Current).DebugSend("HTTP REQUEST TIMEOUT", "NONE");
                return null;    // Timeout
            }
        }

    }
}
