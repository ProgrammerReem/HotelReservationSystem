using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Controllers
{

    public class RoomController : Controller

    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _environment;
        public RoomController(ModelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var room = _context.room.Include(x=>x.hotel).Include(x=>x.Residents).Include(x=>x.reservations).Include(x=>x.testimonials).ToList();

            return View(room);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new RoomVM()
            {
                Hotels = _context.hotels.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(RoomVM roomVM)    
        {
            var room = new Room()
            {
                Desc = roomVM.Desc,
                HotelId=roomVM.hotelId,
                ImagePath =SaveImage(roomVM.ImageFile),
                PriceByNight=roomVM.PriceByNight,
                roomNumber=roomVM.roomNumber,
                RoomType=roomVM.RoomType,
            };

            _context.room.Add(room);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            //room
            var room=_context.room.FirstOrDefault(x=>x.id == id);

            //remove
            _context.Remove(room);
            _context.SaveChanges();
            return RedirectToAction("index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var room = _context.room.Include(x=>x.hotel).FirstOrDefault(x=>x.id==id);
            //Room(DB)==>RoomVm(View)
            var model = new RoomVM()
            {
                Desc=room.Desc,
                hotelId=room.HotelId,
                ImagePath=room.ImagePath,
                PriceByNight=room.PriceByNight,
                roomNumber=room.roomNumber,
                RoomType=room.RoomType,
                id=room.id,
                HotelName=room.hotel.Name,
                Hotels=_context.hotels.ToList().Select(x=>new SelectListItem
                {
                    Text=x.Name,
                    Value=x.Id.ToString()
                }),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(RoomVM room)
        {
            //Room => Db
            var DbRoom = _context.room.Find(room.id);
            //vm=>room
            DbRoom.roomNumber = room.roomNumber;
            DbRoom.Desc = room.Desc;
            DbRoom.HotelId = room.hotelId;
            DbRoom.PriceByNight = room.PriceByNight;
            DbRoom.RoomType = room.RoomType;
            //Vm=> file
            if (room.ImageFile != null)
            {
                DbRoom.ImagePath = SaveImage(room.ImageFile);
            }
            //update
            _context.Update(DbRoom);
            _context.SaveChanges();
            return RedirectToAction("index");
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
