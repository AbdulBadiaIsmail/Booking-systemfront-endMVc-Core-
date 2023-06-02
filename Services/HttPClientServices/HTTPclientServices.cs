using BooKingSystemForntEnd.Models;

namespace BooKingSystemForntEnd.Services.HttPClientServices
{
    public interface HTTPclientServices
    {
        List<Room> getAll();
        List<Room> getByavailable(int Aval);

        Roomupdate GEtByID(int id);

        int update(int id, Roomupdate room);

        int Delete(int id);
    }
}
