using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;

namespace PCL
{
    public class Module
    {
        private Calls calls;

        public Module()
        {           
            this.calls = new Calls ();
        }

        public async Task<ViewModel> GetViewModelAsync()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("BEFORE");
                var response =
                    await
                    this.calls.GetViewModel(
                        new Request(){
                            Name="MyName"
                        }
                    );

                System.Diagnostics.Debug.WriteLine("AFTER");
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

