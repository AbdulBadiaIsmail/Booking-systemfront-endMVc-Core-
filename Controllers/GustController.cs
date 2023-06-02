using BooKingSystemForntEnd.Models;
using BooKingSystemForntEnd.Services.HttPClientServices;
using Microsoft.AspNetCore.Mvc;

namespace BooKingSystemForntEnd.Controllers
{
	public class GustController : Controller
	{
		private readonly GustHttpcs http;
		public GustController(GustHttpcs http)
		{
			this.http = http;	
		}

		public IActionResult getUser()
		{
			var data = http.getAll();

			return View(data);
		}
		[HttpGet]
		public IActionResult Create ()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(addGustcs gustcs)
		{
			if (ModelState.IsValid)
			{
				http.AddGust(gustcs);
				return RedirectToAction("getUser");
			}
			else
			{
				return View();
			}
		}
    }
}
