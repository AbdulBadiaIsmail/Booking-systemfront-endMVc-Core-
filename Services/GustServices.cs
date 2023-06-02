using BooKingSystemForntEnd.Models;
using BooKingSystemForntEnd.Services.HttPClientServices;
using Newtonsoft.Json;
using NuGet.Versioning;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using System.Text;

namespace BooKingSystemForntEnd.Services
{
    public class GustServices : GustHttpcs
    {
        private readonly CompaniesClien client;
        private readonly IHttpClientFactory factory;
        public GustServices(CompaniesClien companiesClien,IHttpClientFactory http )
        {
            this.client = companiesClien;   
            this.factory = http;
        }

        public int AddGust(addGustcs gust)
        {
            var respons = client.Client.PostAsJsonAsync<addGustcs>("Gust", gust);
            respons.Wait();
            var result = respons.Result;
            if (result.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<Gust> getAll()
        {
             var data =client.Client.GetAsync("Gust").Result;
            var Data = data.Content.ReadAsAsync<List<Gust>>().Result;
            return Data;
        }
    }
}
