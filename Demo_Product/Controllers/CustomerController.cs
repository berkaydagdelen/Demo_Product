using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        JobManager jm = new JobManager(new EfJobDal());

        public IActionResult Index()
        {

            var values = customerManager.GetCustomersListWithJob();

            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {



            List<SelectListItem> values = (from x in jm.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.NAME,
                                               Value = x.JOBID.ToString()
                                           }).ToList();

            ViewBag.JOB = values;

            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                customerManager.TInsert(p);

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        public IActionResult DeleteCustomer(int id)
        {
            var values = customerManager.TGetByID(id);
            customerManager.TDelete(values);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {


            List<SelectListItem> Uvalues = (from x in jm.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.NAME,
                                               Value = x.JOBID.ToString()
                                           }).ToList();

            ViewBag.JOB = Uvalues;

            var values = customerManager.TGetByID(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {

            customerManager.TUpdate(p);

            return RedirectToAction("Index");
        }
    }
}

