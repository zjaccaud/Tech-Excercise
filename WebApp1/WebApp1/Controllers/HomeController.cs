using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using static WebApp1.Models.ContactModel;
using WebApp1.Data;
using Microsoft.EntityFrameworkCore;



namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext dbc = new ContactContext();

        public IActionResult Index()
        {
            IEnumerable<Contacts> _viewModel;
            _viewModel = dbc.Contact.AsEnumerable();
            return View(_viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(string firstname, string lastname, string cellnum, string email)
        {
            Contacts newContact = new Contacts
            {
                FirstName = firstname,
                LastName = lastname,
                CellNum = cellnum,
                Email = email,
            };
            dbc.Contact.Add(newContact);
            dbc.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
