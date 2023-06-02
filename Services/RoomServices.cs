using Newtonsoft.Json;
using BooKingSystemForntEnd.Services.HttPClientServices;
using System.Text.Json;
using System.Net.Http;
using BooKingSystemForntEnd.Models;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace BooKingSystemForntEnd.Services
{
    public class RoomServices:HTTPclientServices
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly CompaniesClien client;

        public RoomServices(IHttpClientFactory httpClientFactory, CompaniesClien httpclient)
        {
            _httpClientFactory = httpClientFactory;
            client = httpclient;   
        }

        public Roomupdate GEtByID(int id)
        {
            var data = client.Client.GetAsync($"Room/{id}").Result;
            var rsult = data.Content.ReadAsAsync<Roomupdate>().Result;
            return rsult;
        }

        public  List<Room> getAll()
        {
           
               var result = client.Client.GetAsync("Room").Result;
               var Data   = result.Content.ReadAsAsync<List<Room>>().Result;
            return Data;
            
        }
       
       public  List<Room> getByavailable(int number)

       {
       
            var result = client.Client.GetAsync($"Room/getRoombyAve/{number}").Result;
            var Data = result.Content.ReadAsAsync<List<Room>>().Result;
            return Data;
        }   

        private int getAve(string Ave)
        {
            if (Ave=="Avalable")
            {
                return 0;   
            }
            else
            {
                return 1;
            }
        }

        public int update(int id, Roomupdate room)
        {
            string contentType = "application/json";
            client.Client.DefaultRequestHeaders
                 .Accept
                 .Add(new MediaTypeWithQualityHeaderValue(contentType));
            var result = client.Client.PostAsJsonAsync($"Room/updateRoom/{id}",room).Result;
           
            if (result.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
      
        public int Delete(int id)
        {
             var request = client.Client.GetAsync($"Room/Delete/{id}").Result;
            if (request.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
