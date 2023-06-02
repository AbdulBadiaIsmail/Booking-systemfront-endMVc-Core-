using BooKingSystemForntEnd.Models;
using BooKingSystemForntEnd.Services;
using BooKingSystemForntEnd.Services.HttPClientServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooKingSystemForntEnd.Controllers
{
    public class RoomController : Controller
    {
        private  HTTPclientServices http;
        public RoomController(HTTPclientServices calling_)
        {
            this.http = calling_;
        }
        [HttpGet]
        public  IActionResult GetRoom()
        {
            var data =  http.getAll();
            return View(data);
        }

        [HttpPost]
        public IActionResult GetRoom(int  number)
        {
         
            var data = http.getByavailable(number);
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var room = http.GEtByID(id);
            return View(room);
        }
        [HttpPost]
        public ActionResult Edit(int id, Roomupdate room)
        {
            if (ModelState.IsValid)
            {
                if (http.update(id, room) == 1)
                {
                    return RedirectToAction("getRoom");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            
           
        }
        [HttpGet]
        public ActionResult Delete (int id )
        {
            http.Delete(id);
            return RedirectToAction("getRoom");
        }
    }
}
