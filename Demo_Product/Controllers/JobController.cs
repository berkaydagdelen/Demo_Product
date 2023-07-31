using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class JobController : Controller
    {
        JobManager JobManager = new JobManager(new EfJobDal());

        public IActionResult Index()
        {
            var values = JobManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddJob()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job p)
        {
            JobValidator validationRules = new JobValidator();
            ValidationResult results = validationRules.Validate(p);
            if (results.IsValid)
            {
                JobManager.TInsert(p);

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
        public IActionResult DeleteJob(int id)
        {
            var values = JobManager.TGetByID(id);
            JobManager.TDelete(values);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {

            var values = JobManager.TGetByID(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job p)
        {

            JobManager.TUpdate(p);

            return RedirectToAction("Index");
        }
    }
}
