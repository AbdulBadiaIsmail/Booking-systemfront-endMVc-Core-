namespace BooKingSystemForntEnd.Models
{
    public class Roomupdate
    {
        public int Number_Ro { get; set; }
        public string TypeName { get; set; }
        public decimal Price { get; set; }
        public IFormFile image_path { get; set; }
        public string Room_Des { get; set; }
        public int  Avalable { get; set; }
    }
}
