using BooKingSystemForntEnd.Models;

namespace BooKingSystemForntEnd.Services.HttPClientServices
{
    public interface BooKing_context
    {
        List<BooKing> GetBooKings();
        string AddBooking(AddBooKing booKing);
        int DeleteBooKing(int id);

        List<Room> getRoomAvailable();
        List<Gust> GetGusts();

        GetBooKingbyID GetBooKingbyId(int id);


    }
}
