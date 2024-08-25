using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DiaSymReader;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;

namespace HotelReservationSystem.Controllers
{

    public class RoomController : Controller

    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public RoomController(ModelContext context, IWebHostEnvironment environment, IConfiguration configuration)
        {
            _context = context;
            _environment = environment;
            _configuration = configuration;
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
                HotelName = room.hotel.Name,
                Hotels = _context.hotels.ToList().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
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

        public IActionResult Details(int id , string? viewBagValue=null)
        {
            var room = _context.room.Include(x=>x.testimonials).ThenInclude(x=>x.user).FirstOrDefault(x => x.id == id);
            List<Testimonial> tt = new List<Testimonial>();
            foreach (var item in room.testimonials)
            {
                if (item.status == true)
                {
                    tt.Add(item);
                }
            }
            room.testimonials = tt;
            //room - test - Addtest -Enroll
            var TestVM = new AddTestimonialVM()
            {
                RoomId=id
            };
            var ReservVM = new ReservationVM()
            {
                roomid = id
            };
            var model = new RoomDetailsVM()
            {
                room=room,
                resveration=ReservVM,
                testimonialsVM=TestVM
                
            };
            if(viewBagValue != null)
            {
 ViewBag.CardError = "CardId or Card Cvv is invalid";

            }
            return View(model);
        }
        [HttpPost]
        //enroll - addTest - add rating for hotel
        public IActionResult Enroll(ReservationVM resveration)
        {
            //user id
            var user =GetUser();        
            if (user == null)
            {
                return RedirectToAction("Login", controllerName: "Account");
            }
            //card handle
            if(user.CardId!=resveration.CardId || user.CardCvv != resveration.CardCvv)
            {
               
               
                return RedirectToAction("Details",new {id=resveration.roomid , viewBagValue="ff" });
            }
            //valid hisory
            //min => 1-1-1
            if (!resveration.checkIn.Equals(DateTime.MinValue)&& !resveration.checkOut.Equals(DateTime.MinValue))
            {
                var room = _context.room.FirstOrDefault(x=>x.id== resveration.roomid);
                //Balance?
                var totalCount =( (resveration.checkOut - resveration.checkIn).TotalDays) * (double)room.PriceByNight;
                //check balance for user according to total price
                var userBalance = user.balance -(int) totalCount;
                //check if userBalance is bigger than zero or not?
                if (userBalance < 0)
                {
                    //return Erro Message
                    throw new Exception();
                }
                //change user balance
                user.balance -= (decimal)totalCount;
                _context.Update(user);
                //obj reserv
                var reservation = new Reservation()
                {
                    CheckOut= resveration.checkOut,
                    CheckIn= resveration.checkIn,
                    CreatedAt=DateTime.Now,
                    RoomId= resveration.roomid,
                    UserID=user.Id
                };
                _context.Add(reservation);

                //userT
                var userTransaction = new UserTransactions()
                {
                    CreatedAt=DateTime.Now,
                    Price=(decimal)totalCount,
                    RoomId= resveration.roomid,
                    UserID=user.Id,
                };
                _context.Add(userTransaction);
                _context.SaveChanges();
                //send email
                SendEmail(user.Email, room.roomNumber, (decimal)totalCount, user.balance);
                return RedirectToAction("Index", "Home");
            //new onject from reser
            //save 
            }
           
            return View();


        }


        public IActionResult GetAll(GetAllRoomsVM getAll)
        {
            //querable vs Ienumtable
            var rooms = _context.room.Include(x => x.hotel).ToList();
            //rooms
            //search
            if (!string.IsNullOrWhiteSpace(getAll.search))
            {
                //r==
                rooms = rooms.Where(x => x.hotel.Name.Contains(getAll.search) ).ToList();
            }
            //from - to
            if(getAll.From != DateTime.MinValue &&getAll.To != DateTime.MinValue)
            {
                rooms=rooms.Where(x=>x.CreatedAt>=getAll.From && x.CreatedAt<=getAll.To).ToList();
            }
            var x = rooms.ToList();
            var model = new GetAllRoomsVM()
            {
                Rooms=x
            };
            
            return View(model);
        }

        public void SendEmail(string EmailSentTo, int roomNumber, decimal price, decimal balance)
        {
            //google developer 
            var email = new MimeMessage();
           
            email.From.Add(new MailboxAddress(_configuration["SendEmail:FromName"], _configuration["SendEmail:FromEmail"]));
            email.To.Add(MailboxAddress.Parse(EmailSentTo));
            email.Subject = "Room Request";
            var htmlPage = $"<h1>Room Request in website</h1><p>Good morning .. you sucessfully send request for room number:{roomNumber} the total price is : {price}$ ,  and your current balance now is : {balance}$ </p>";
            email.Body = new TextPart(TextFormat.Html) { Text = htmlPage };
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate(userName: _configuration["SendEmail:FromEmail"], password: _configuration["SendEmail:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        private User GetUser()
        {
            var userId = HttpContext.Session.GetString("userId");
            if (userId == null)
            {
                return null;
            }
            var user = _context.users.FirstOrDefault(x => x.Id == int.Parse(userId));
            if (user == null)
            {
                return null;
            }
            return user;
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
