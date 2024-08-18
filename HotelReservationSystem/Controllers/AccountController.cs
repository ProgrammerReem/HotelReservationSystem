using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _environment;

        public AccountController(ModelContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                //create user
                var user = new User()
                {
                    CreatedAT = DateTime.Now,
                    Email = userVM.Email,
                    Name = userVM.Name,
                    Password = userVM.Password,
                    phone = userVM.phone,
                };
                //role - image path
                if (userVM.ImageFile != null)
                {
                    user.ImagePath = SaveImage(userVM.ImageFile);
                }
                //first Account => Admin
                if (_context.users.Count() == 0)
                {
                    user.Role = "Admin";
                }
                else
                {
                    user.Role = "user";
                }
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(userVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserVM userVM)
        {
            //email => vm و pass=>vm


       



            var user = _context.users.FirstOrDefault(x => x.Email == userVM.Email && x.Password == userVM.Password);
            if (user != null)
            {
                //login
                HttpContext.Session.SetString("userId", user.Id.ToString());
                HttpContext.Session.SetString("userName", user.Name);
                return RedirectToAction("TestSession");
            }
            ViewBag.error = "invalid ";
            return View();
        }
        public IActionResult TestSession()
        {
            var x = HttpContext.Session.GetString("userId");
            var cx = HttpContext.Session.GetString("userName");
            var cxc = HttpContext.Session.GetString("userName2");
            return View();
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
