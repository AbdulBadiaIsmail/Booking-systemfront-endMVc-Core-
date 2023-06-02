namespace BooKingSystemForntEnd.Models
{
	public class AddBooKing
    {
	public DateTime datestart { get; set; }
    public DateTime dateend { get; set; }  
   public int gust_id { get; set; }  

    public List<AddBookingRoom> room { get; set; }  
       =new List<AddBookingRoom>(); 
           
	}
}
