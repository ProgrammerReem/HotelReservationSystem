using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ModelContext _context;

        public AdminController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult GetAllReservation()
        {
            var model = _context.reservations.Include(x => x.user).Include(x => x.room).ThenInclude(x => x.hotel).ToList();
            return View(model);
        }
        public IActionResult Accept(int id)//reservation id
        {
            var OldReservation = _context.reservations.FirstOrDefault(x => x.Id == id);
            //user in room Resident
            var resident = new Resident()
            {
                CheckIn = OldReservation.CheckIn,
                CheckOut = OldReservation.CheckOut,
                RoomId = OldReservation.RoomId,
                UserID = OldReservation.UserID
            };
            //remove old reservation
            //add resident
            //save
            _context.Remove(OldReservation);
            _context.Add(resident);
            _context.SaveChanges();

            return RedirectToAction("GetAllReservation");
        }
        public IActionResult Refuse(int id)
        {
            //get reser 
            var reservation = _context.reservations.FirstOrDefault(x => x.Id == id);

            //user Transaction
            var userTRansaction = _context.userTransactions.FirstOrDefault(x => x.UserID == reservation.UserID && x.RoomId == reservation.RoomId);
            //total price
            var user = _context.users.FirstOrDefault(x => x.Id == reservation.UserID);
            user.balance += userTRansaction.Price;

            //remove reser
            //update user
            //save changes
            _context.Remove(userTRansaction);
            _context.Remove(reservation);
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction("GetAllReservation");
        }

        public IActionResult GetAllResidents()
        {
            var Residents = _context.residents.Include(x => x.user).Include(x => x.room).ThenInclude(x => x.hotel).ToList();
            return View(Residents);
        }


        public IActionResult AddTestimonial(AddTestimonialVM testimonialsVM)
        {
            //text , roomId , User?
            var user = GetUser();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var test = new Testimonial()
            {
                CreatedAt = DateTime.Now,
                roomId = testimonialsVM.RoomId,
                text = testimonialsVM.Text,
                userId = user.Id
            };
            _context.Add(test);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetAllTestimonial()
        {
            var tests = _context.testimonials.Include(x => x.user).Include(x => x.room).ThenInclude(x => x.hotel).Where(x=>x.status==false).ToList();
            return View(tests);
        }
        public IActionResult AcceptTest(int id)
        {
            //residents?
            var testie = _context.testimonials.FirstOrDefault(x => x.Id == id);
            testie.status = true;
            _context.Update(testie);
            _context.SaveChanges();
            return RedirectToAction("GetAllTestimonial");
        }

        public IActionResult RefuseTest(int id)
        {
            var testie = _context.testimonials.FirstOrDefault(x => x.Id == id);
            _context.Remove(testie);
            _context.SaveChanges();
            return RedirectToAction("GetAllTestimonial");
        }

        public IActionResult ContactUs(ContactUsVM contactUs)
        {
            var model = new ContactUs()
            {
                CreatedAt = DateTime.Now,
                 Email=contactUs.Email,
                 Name=contactUs.Name,
                 PhoneNumber=contactUs.phone,
                 Text=contactUs.text
            };
            //Save in DB
            _context.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult GetContactUs()
        {
            var CU = _context.contactUs.ToList();
            return View(CU);
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

    }
}
