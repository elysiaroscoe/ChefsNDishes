using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
                _context = context;
        }

        //DISPLAY ROUTES

        [HttpGet("")]
        //Chef Roster
        public IActionResult Chefs()
        {
            ViewModel viewmodel = new ViewModel()
            {
                AllChefs = _context.Chefs
                    .Include(c => c.CreatedDishes)
                    .ToList()
            };
            return View(viewmodel);
        }

        [HttpGet("dishes")]
        //Dish Roster
        public IActionResult Dishes()
        {
            ViewModel viewmodel = new ViewModel()
            {
                AllDishes = _context.Dishes
                    .Include(d => d.Creator)
                    .ToList()
            };
            return View(viewmodel);
        }

        [HttpGet("new")]
        //Chef Form
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpGet("dishes/new")]
        //Dish Form
        public IActionResult NewDish()
        {
            Dish Form = new Dish()
            {
                //List of Available Chefs
                AllChefs = _context.Chefs.ToList()
            };
            return View(Form);
        }





        //POST ROUTES

        [HttpPost("chefsubmit")]
        //Chef Form Route
        public IActionResult ChefSubmit(Chef fromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(fromForm);
                _context.SaveChanges();

                return RedirectToAction("chefs");
            }
            else 
            {
                return View("NewChef");
            }
        }


        [HttpPost("dishsubmit")]
        //Dish Form Route
        public IActionResult DishSubmit(Dish fromForm)
        {
            if(ModelState.IsValid)
                {
                    _context.Add(fromForm);
                    _context.SaveChanges();

                    return RedirectToAction("Dishes");
                }
                else 
                {
                    return View("NewDish");
                }
        }

        //Edit and delete are not requested
    }
}
