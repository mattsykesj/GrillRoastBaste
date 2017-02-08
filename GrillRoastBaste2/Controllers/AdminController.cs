using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GrillRoastBaste2.Models;

namespace GrillRoastBaste2.Controllers
{
    
    public class AdminController : Controller
    {

        public ActionResult Delete(int ID)
        {
            CustomerDbContext context = new CustomerDbContext();
            var customerToDelete = context.Customers.Find(ID);
            context.Customers.Remove(customerToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            CustomerDbContext context = new CustomerDbContext();
            var customerToEdit = context.Customers.Find(ID);
    

            return View(customerToEdit);
        }

        [HttpPost]
        public ActionResult Edit(int? ID)
        {

            ViewBag.StatusList = GetStatusList();//Not sure how else to do this, getting an error when posting this
                                                 //didnt want to duplicate code so moved to a method but doesnt feel
                                                 //like a good solution.
                                                 //(error)there is no status list object, need to look at tempdata maybe?

            using (var context = new CustomerDbContext()) //uses the db context to add the customer sub to the db
            {
                

                if (ID == null)
                {
                    var result = new HttpNotFoundResult("No User ID associated with this customer");
                    return result;
                }
                
                var customerToUpdate = context.Customers.Find(ID);
                TryUpdateModel(customerToUpdate);
                if (ModelState.IsValid)
                {

                    try
                    {
                        context.SaveChanges();
                        return View("Index", context.Customers.ToList());
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "Unable to edit the customer");
                    }

                }
             return View(customerToUpdate);
                
            }
           

        }

        [Authorize]
        public ActionResult Index(string sortOrder, string searchString, string StatusList)
        {
            CustomerDbContext context = new CustomerDbContext();
            ViewBag.StatusList = GetStatusList();

            ViewBag.NameSort = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.NameSort = sortOrder == "surname" ? "surname_desc" : "surname";
            ViewBag.DateSort = sortOrder == "date" ? "date_desc" : "date";
            
            var customers = from c in context.Customers select c;
            //Should use a switch here
            if(StatusList == "0")
            {
                customers = customers.Where(x => ((int)x.Status == 0));
            }
            if (StatusList == "1")
            {
                customers = customers.Where(x => ((int)x.Status == 1));
            }
            if (StatusList == "2")
            {
                customers = customers.Where(x => ((int)x.Status == 2));
            }
            if (StatusList == "3")
            {
                customers = customers.Where(x => ((int)x.Status == 3));
            }


            if (searchString != null)
            {
                customers = customers.Where(x => x.Name.Contains(searchString) || x.SurName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name":
                    {
                        customers = customers.OrderByDescending(x => x.Name);
                        break;
                    }
                case "name_desc":
                    {
                        customers = customers.OrderBy(x => x.Name);
                    }
                        break;
                case "surname":
                    {
                        customers = customers.OrderByDescending(x => x.Name);
                        break;
                    }
                case "surname_desc":
                    {
                        customers = customers.OrderBy(x => x.Name);
                    }
                    break;
                case "date":
                    {
                        customers = customers.OrderByDescending(x => x.DateOfEvent);
                        break;
                    }
                case "date_desc":
                    {
                        customers = customers.OrderBy(x => x.DateOfEvent);
                    }
                    break;
                default:
                    {
                        customers = customers.OrderBy(x => x.DateOfEvent);
                    }
                    break;
            }
            
           

            return View(customers.ToList());
        }

        public List<SelectListItem> GetStatusList()
        {
            List<SelectListItem> statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem { Text = "New", Value = "0", Selected = true });
            statusList.Add(new SelectListItem { Text = "Replied", Value = "1" });
            statusList.Add(new SelectListItem { Text = "Secured", Value = "2" });
            statusList.Add(new SelectListItem { Text = "Done", Value = "3" });
            statusList.Add(new SelectListItem { Text = "All", Value = "4" });
            return statusList;
        }
    }
}