using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToSqlRelationships.Data;
using LinqToSqlRelationships.Web.Models;

namespace LinqToSqlRelationships.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new PersonRepository(Properties.Settings.Default.ConStr);
            var vm = new HomePageViewModel
            {
                People = db.GetPeople()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult GetCars(int personId)
        {
            var db = new PersonRepository(Properties.Settings.Default.ConStr);

            //List<string> firstNames = new List<string>();
            //foreach (Car car in db.GetCarsForPerson(personId))
            //{
            //    firstNames.Add(car.Person.FirstName);
            //}


            //return Json(firstNames);
            //return Json(db.GetCarsForPerson(personId).Select(c => c.Person.FirstName));
            IEnumerable<Car> cars = db.GetCarsForPerson(personId);
            //Person p = cars.First().Person;
            //return Json(new
            //{
            //    firstName = p.FirstName,
            //    lastName = p.LastName,
            //    age = p.Age
            //});
            return Json(cars.Select(c => new
            {
                make = c.Make,
                model = c.Model,
                year = c.Year,
                id = c.Id
            }));
        }
    }
}

//Orders
    //Date
    //Title
    //Amount
    //Completed
//Issues
    //OrderId
    //Note
    //Resolved (bit)

//On the home page, display all the orders that have not been completed yet. 
//For each order, display the Date, Title, Amount, as well
//as the Resolved Count (how many resolved issues) and Unresolved Count (how many unresolved issues).
// Next to each order, there should also be a button that says "Mark as Completed". This
//button should only be enabled if the order has zero unresolved issues. When this button is clicked
//the order should be marked as completed in the database and the table should refresh. Use AJAX
//to do this.

// On the home page, there should be also be a link to a page that allows you to add a new order.
//Next to each order, there should also be a link that takes you to a page to see all the issues for
//that order. On this page only display the unresolved issues. For each issue, show the Note
//along with a button to "Mark as Resolved". When this button is clicked, via ajax, set this issue
//to resolved and the list of issues should get updated.
//On top of page, display the order information e.g. "Issues for Order #123 placed on 1/1/2001". 
//Also on top of this page, have a link that takes you to a page that allows adding new Issues for this
//current order.