using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    public class HotelController : Controller
    {
        private readonly ModelContext _context;
        public HotelController(ModelContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var hotels = _context.hotels.ToList();
            return View(hotels);//@model IEnumrable<hotels>
        }
        [HttpGet]
        public IActionResult Create()
        {
            //
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelsVM model)
        {
            if (ModelState.IsValid)
            {
                //user => hotel view model
                //Steps

                //new object from hotel
                //mapping HotelVM To Hotel
                var hotel = new Hotel()
                {
                    Loc=model.Loc,
                    Name=model.Name,
                    Desc=model.Desc
                };
                //Save image !!

                //Save Hotel in DB
                _context.hotels.Add(hotel);
                _context.SaveChanges();
                //database<= hotel
                return RedirectToAction("index");
            }
            //view.erro=
            return View(model);
        }


            //Details - Delete
    
    }
}
