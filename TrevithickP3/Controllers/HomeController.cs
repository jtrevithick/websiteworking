using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrevithickP3.Data;
using TrevithickP3.Migrations;
using TrevithickP3.Models;

namespace TrevithickP3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           ResumeViewModel viewModel=new ResumeViewModel();
            viewModel.SkillItems = _context.Skills.ToList();
            viewModel.EducationItems = _context.Educations.ToList();
            viewModel.ExperienceItems = _context.Experiences.ToList();
            return View("Resume",viewModel);
           
            //return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult PayPalBasicPayment()
        {
            ViewBag.Message = "PayPalPayment.";
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
