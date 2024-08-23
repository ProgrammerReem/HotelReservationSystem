using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModelContext _context;

        public HomeController( ModelContext context)
        {
          
            _context = context;
        }
       
        public IActionResult Index()
        {
            var conatcUs = new ContactUsVM();


            var model = new MainPageVM()
            {
                hotels=_context.hotels.ToList(),
                contactUs = conatcUs
            };
            return View(model);
        }

      
    }
}
