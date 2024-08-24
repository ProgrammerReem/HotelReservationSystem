using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var test = _context.testimonials.Include(x=>x.user).Include(x=>x.room).ThenInclude(x=>x.hotel).ToList();
            

            var model = new MainPageVM()
            {
                hotels=_context.hotels.ToList(),
                contactUs = conatcUs,
                testimonials= test,
                pageContent= _context.pageContent.FirstOrDefault()
            };

            return View(model);
        }

      
    }
}
