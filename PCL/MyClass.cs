using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;
using System.Net.Http;

namespace PCL
{
    public class MyClass
    {
        private static MyClass instance;
        private HttpClient httpClient;

        private MyClass() {
            httpClient = new HttpClient();
            // TODO: YOUR NODEJS-IP HERE (OR LOCALHOST FOR iOS Simulator)
            httpClient.BaseAddress=new Uri ("http://10.0.1.12:3000/");
        }

        public static MyClass Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new MyClass();
                }
                return instance;
            }
        }

        public async Task<ViewModel> GetAsync()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("START GETASYNC");

                // GET works correctly
                var response = await httpClient.GetAsync("get");

                System.Diagnostics.Debug.WriteLine("END GETASYNC");

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ViewModel>(body);
                }

                return null;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            catch(Exception allEx)
            {
                Debug.WriteLine(allEx);
                return null;
            }
        }

        public async Task<ViewModel> PostAsync(Request request)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("START POSTASYNC");

                StringContent content = new StringContent (JsonConvert.SerializeObject (request), Encoding.UTF8, "application/json");

                // POST crashes
                var response = await httpClient.PostAsync ("post",content);

                System.Diagnostics.Debug.WriteLine("END POSTASYNC");

                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ViewModel>(body);
                }

                return null;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
            catch(Exception allEx)
            {
                Debug.WriteLine(allEx);
                return null;
            }
        }

    }
}

