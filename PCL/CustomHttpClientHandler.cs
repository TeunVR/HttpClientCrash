using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace PCL
{
    public class CustomHttpClientHandler : HttpClientHandler
    {
        private static CustomHttpClientHandler instance;

        public static CustomHttpClientHandler Instance
        {
            get
            {
                return instance ?? (instance = new CustomHttpClientHandler());
            }
        }

        private CustomHttpClientHandler()
        {
            this.UseCookies = true;
            this.AllowAutoRedirect = false; // dont allow redirect because it can be used to redirect to an server of an attacker
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Debug.WriteLine ("BEFORE " + request.RequestUri);
            var response = await base.SendAsync(this.SetupRequest(request), cancellationToken);
            //Debug.WriteLine ("AFTER " + request.RequestUri);


            return response;
        }

        private HttpRequestMessage SetupRequest(HttpRequestMessage request)
        {
            return request;
        }
    }
}

