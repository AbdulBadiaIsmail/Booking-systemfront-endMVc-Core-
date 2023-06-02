using BooKingSystemForntEnd.Models;
using BooKingSystemForntEnd.Services.HttPClientServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooKingSystemForntEnd.Controllers
{
    public class BookingController : Controller
    {
        private readonly BooKing_context _Context;
        public BookingController( BooKing_context _Context)
        {
            this._Context = _Context;   
        }
        [HttpGet]
        public  IActionResult GetBooKing()
        {
           List<BooKing> data =  _Context.GetBooKings();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            AddBooKing b = new AddBooKing();
            var room = _Context.getRoomAvailable();
            ViewBag.RoomAvailable = new MultiSelectList(room, "Number_Ro", "TypeName");
            var gust = _Context.GetGusts();
            ViewBag.Gust = new SelectList(gust, "id", "F_Name"); 
           
            return View(b);
        }

        [HttpPost]
        public IActionResult Create(AddBooKing booKing,List<int> room)
        {

              booKing.room=getNumberrooms1(room);
            if (ModelState.IsValid)
            {
                _Context.AddBooking(booKing);
                
                return RedirectToAction("GetBooKing");
               
            }
            else
            {
                AddBooKing b = new AddBooKing();
                var room1 = _Context.getRoomAvailable();
                ViewBag.RoomAvailable = new MultiSelectList(room1, "Number_Ro", "TypeName" );
                var gust = _Context.GetGusts();
                ViewBag.Gust = new SelectList(gust, "id", "F_Name");
                return View(b);
            }
            

        }


        private List<AddBookingRoom> getNumberrooms1 (List<int> number)
        {
            List<AddBookingRoom> result = new List<AddBookingRoom>();  
           
            foreach (var item in number)
            {
               AddBookingRoom room = new AddBookingRoom();
                room.room_ID = item;
                   result.Add(room);    
            }
            return result;  
        }

        [HttpDelete]
        public IActionResult Delete(int id )
        {
            _Context.DeleteBooKing(id);
            return RedirectToAction("GetBooKing");
        }
   
      
            
    }
}
