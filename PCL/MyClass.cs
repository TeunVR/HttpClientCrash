using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

namespace PCL
{
    public class MyClass
    {
        private static MyClass instance;
        private HttpClient httpClient;

        private MyClass() {
            httpClient = new HttpClient();
            httpClient.BaseAddress=new Uri ("http://localhost:3000/");
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

        public async Task<ViewModel> GetViewModelAsync(Request request)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("BEFORE POSTASYNC");

                StringContent content = new StringContent (JsonConvert.SerializeObject (request), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync ("post",content);

                System.Diagnostics.Debug.WriteLine("AFTER POSTASYNC");

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

