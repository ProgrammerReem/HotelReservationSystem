﻿using HotelReservationSystem.Models;
using HotelReservationSystem.Models.Data;
using HotelReservationSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                    balance=1000
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

                return RedirectToAction("index", controllerName: "Home");
            }
            ViewBag.error = "invalid ";
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var user = GetUser();
            if(user == null)
            {
                return RedirectToAction("Login");
            }
            //
            var model = new UserVM()
            {
                Id=user.Id,
                CardID=user.CardId,
                CardCvv=user.CardCvv,
                Email=user.Email,
                Name=user.Name,
                phone=user.phone,
                ImagePath=user.ImagePath,   
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(UserVM userVM)
        {
            var user = _context.users.FirstOrDefault(x => x.Id == userVM.Id);

            user.phone = userVM.phone;
            user.Name = userVM.Name;
            user.CardCvv = userVM.CardCvv;
            user.CardId = userVM.CardID;
            user.Email = userVM.Email;

            //password - image
            if (userVM.Password != null)
            {
                user.Password=userVM.Password;
            }
            if (userVM.ImageFile != null)
            {
                user.ImagePath = SaveImage(userVM.ImageFile);
            }
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction("index",controllerName:"Home");
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }

        private User GetUser()
        {
            var userId = HttpContext.Session.GetString("userId");
            if (userId == null)
            {
                return null;
            }
            var user = _context.users.FirstOrDefault(x => x.Id == int.Parse(userId));
            if (user == null) {
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
