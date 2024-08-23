 using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Controllers
{
    public class HotelController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _environment;
        public HotelController(ModelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public IActionResult Index()
        {
            var hotels = _context.hotels.Include(x=>x.rooms).ToList();
            return View(hotels);//@model IEnumrable<hotels>
        }
        [HttpGet]
        public IActionResult Create()
        {
            //
            return View();
        }
        [HttpPost]
        public IActionResult Create(HotelVM model)
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
                    Desc=model.Desc,
                    Imagepath=SaveImage(model.ImagFile)
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
        public IActionResult Delete(int Id)
        {
            var hotel = _context.hotels.FirstOrDefault(x => x.Id == Id);
            _context.Remove(hotel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var hotel = _context.hotels.FirstOrDefault(x => x.Id == id);
            //View Model
            var model = new HotelVM()
            {
                Imagepath = hotel.Imagepath,
                Desc = hotel.Desc,
                Loc = hotel.Loc,
                Name = hotel.Name,
                Id = id,
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(HotelVM hotel)
        {

            var DBHotel = _context.hotels.FirstOrDefault(x => x.Id == hotel.Id);
            DBHotel.Name = hotel.Name;
            DBHotel.Loc = hotel.Loc;
            DBHotel.Desc = hotel.Desc;
            //file image?
            if (hotel.ImagFile != null)
            {
                DBHotel.Imagepath = SaveImage(hotel.ImagFile);
            }
            _context.Update(DBHotel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //data about hotel
            //Rating
            //drop list - int rate - int hotel id
            //---------------------------------------------
            var rate = new RatingVM()
            {
                HotelId = id
            };
            var model = new HotelDetailsVM()
            {
                hotel = _context.hotels.Include(x=>x.rooms).FirstOrDefault(x => x.Id == id),
                ratingVM=rate
                
            };

            return View(model);
        }

        public IActionResult AddRating(RatingVM ratingVM)
        {
            //hotel 
            var hotel=_context.hotels.FirstOrDefault(x=>x.Id== ratingVM.HotelId);
            //count++
            hotel.Count++;
            //rating(average rating)
            int newRating = (hotel.Rating * (hotel.Count - 1) + ratingVM.Rating) / hotel.Count;
            hotel.Rating = newRating;
            // save
            _context.Update(hotel);
            _context.SaveChanges();
           
            return RedirectToAction("Details",controllerName:"Hotel",routeValues: ratingVM.HotelId);
        }

        private string SaveImage(IFormFile file)
        {
            if (file == null)
            {
                return string.Empty;
            }
            string RootPath = _environment.WebRootPath;//== ~
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString();
                var Upload = Path.Combine(RootPath, @"Images");
                var ext = Path.GetExtension(file.FileName);

                using (var filestream = new FileStream(Path.Combine(Upload, filename + ext), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
                return @"Images\" + filename + ext;
            }
            return "";
        }

    }
}
