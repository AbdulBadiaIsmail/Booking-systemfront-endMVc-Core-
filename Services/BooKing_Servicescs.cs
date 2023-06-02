using BooKingSystemForntEnd.Models;
using BooKingSystemForntEnd.Services.HttPClientServices;

namespace BooKingSystemForntEnd.Services
{
    public class BooKing_Servicescs : BooKing_context
    {

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly CompaniesClien _companiesClient;

        public BooKing_Servicescs(IHttpClientFactory factory ,CompaniesClien client)
        {
            this._httpClientFactory = factory;
            this._companiesClient = client;
        }
        public string AddBooking(AddBooKing booKing )
        {
            try
            {
               
                var booking = _companiesClient.Client.PostAsJsonAsync("Booking", booKing).Result;
                if (booking.IsSuccessStatusCode)
                {
                    return booking.StatusCode.ToString();
                }
                else
                {
                    return booking.StatusCode.ToString();
                }
              
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }

        public int DeleteBooKing(int id)
        {
            var request = _companiesClient.Client.DeleteAsync($"Booking/Delete/{id}");
            request.Wait();
           
            var result = request.Result;
            if (result.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public GetBooKingbyID GetBooKingbyId(int id)
        {
            var request = _companiesClient.Client.GetAsync($"Booking/getbyid/{id}").Result;
            var response = request.Content.ReadAsAsync<GetBooKingbyID>().Result;
            return response;    
        }

        public  List<BooKing> GetBooKings()
        {
            var result =  _companiesClient.Client.GetAsync("BooKing").Result;
            var Booking =  result.Content.ReadAsAsync<List<BooKing>>().Result;
            return Booking;

        }

        public List<Gust> GetGusts()
        {
            var result  = _companiesClient.Client.GetAsync("Gust").Result;
            var data = result.Content.ReadAsAsync<List<Gust>>().Result;
            return data;
        }

        public List<Room> getRoomAvailable()
        {
            var result = _companiesClient.Client.GetAsync("Room/getRoomAvailable").Result;
            var data = result.Content.ReadAsAsync<List<Room>>().Result;
            return data;
        }

      



    }
}
