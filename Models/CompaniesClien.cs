using System.Net.Http.Headers;
using System.Text.Json;

namespace BooKingSystemForntEnd.Models
{
    public class CompaniesClien
    {
        public HttpClient Client { get; }
        private readonly JsonSerializerOptions _options;

        public CompaniesClien(HttpClient client)
        {
            Client = client;
            Client.BaseAddress = new Uri("https://localhost:44383/api/");
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
