using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace PCL
{
    public class Calls
    {
        private readonly string apiuri = "";

        public Calls ()
        {
            httpClient = new HttpClient (CustomHttpClientHandler.Instance);
            //httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri ("http://localhost:3000/");
        }

        private HttpClient httpClient;

        public async Task<HttpResponseMessage> GetViewModel (Request request)
        {
            StringContent content = CreateStringContent(request);
            return await httpClient.PostAsync (apiuri + "post", content);
        }

        private static StringContent CreateStringContent (object request)
        {
            return new StringContent (JsonConvert.SerializeObject (request), Encoding.UTF8, "application/json");
        }
    }
}

