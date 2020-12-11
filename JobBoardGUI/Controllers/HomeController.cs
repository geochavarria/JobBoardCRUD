using JobBoardApi.Models;
using JobBoardGUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardGUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Repository.JobRepository jobRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            jobRepository = new Repository.JobRepository();
        }

        public IActionResult Index()
        {
            var jobs = jobRepository.GetAll();
            return View(jobs);
        }

        public IActionResult Edit(int jobKey)
        {
            if (jobKey==0)
            {
                return RedirectToAction("Error");
            }
            var jobInfo = jobRepository.Get(jobKey);
            return View("Edit", jobInfo);
        }

        public IActionResult Create(Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                var result  = jobRepository.Create(jobs);
                return RedirectToAction("Index");
            }
            var jobInfo = new Jobs
            {
                JobTitle = "",
                Description = "",
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now
            };
            return View("Create", jobInfo);
        }


        public IActionResult Update(Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                var result = jobRepository.Update(jobs);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        public IActionResult Details(int? jobKey)
        {
            if (jobKey == null)
            {
                return NotFound();
            }

            var jobInfo = jobRepository.Get((int)jobKey);
            if (jobInfo == null)
            {
                return NotFound();
            }

            return View(jobInfo);
        }

        public IActionResult Delete(Jobs jobs)
        {
            if (jobs.Job == 0)
            {
                return NotFound();
            }
            jobRepository.Remove(jobs.Job);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
