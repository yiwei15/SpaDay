using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using SpaDay.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        User newUser = new User();
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View(newUser);
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel(); //create a new instance
            return View(addUserViewModel);
        }

        [HttpPost]
        [Route("/user")]
        public IActionResult SubmitAddUserForm(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {

                    newUser.Username = addUserViewModel.Username;
                    newUser.Email = addUserViewModel.Email;
                    newUser.Password = addUserViewModel.Password;
                    return View("Index", newUser);
   
            }

            return View("Add", addUserViewModel);

        }

    }
}
