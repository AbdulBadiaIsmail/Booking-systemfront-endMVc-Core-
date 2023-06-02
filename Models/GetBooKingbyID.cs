namespace BooKingSystemForntEnd.Models
{
    public class GetBooKingbyID
    {

     public  int  id { get; set; }  
     public DateTime dataStrat { get; set; }

      public DateTime  dataEnd { get; set; }
       public int  gust_id { get; set; }
         public List<DTORoomusigBooKing>   room { get; set; }

    }
}
