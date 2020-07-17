﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/user/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/user")]

        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            if (newUser.Password == verify)
            {
                ViewBag.user = newUser;
                
                return View("Index");
            }
            else
            {
                ViewBag.error = "Passwords do not match!";
                ViewBag.userName = newUser.Username;
                ViewBag.email = newUser.Email;
                return View("Add");
            }
        }

    }
}
