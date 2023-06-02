using BooKingSystemForntEnd.Models;

namespace BooKingSystemForntEnd.Services.HttPClientServices
{
    public interface GustHttpcs
    {
        List<Gust> getAll();

        int AddGust(addGustcs gust);    


    }
}
