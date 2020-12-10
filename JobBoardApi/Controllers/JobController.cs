using JobBoardApi.Models;
using JobBoardApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private JobService _jobService;

        [HttpGet(Name = "Get")]
        public ActionResult<List<Jobs>> Get()
        {
            return _jobService.GetAll();
        }

        [HttpGet("{job}", Name = "GetJob")]
        public ActionResult<Jobs> Get(string job)
        {
            var jobResult = _jobService.Get(job);
            if (jobResult != null)
            {
                return jobResult;
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Jobs job)
        {
            var result = _jobService.Insert(job);
            return CreatedAtRoute("GetJob", new { job = result.Job }, result);
        }


        [HttpPut]
        [Route("[action]")]
        public IActionResult Update(Jobs job)
        {
            var result = _jobService.Update(job);
            if (result == null)
            {
                return NotFound();
            }
            return CreatedAtRoute("GetJob", new { job = result.Job }, result);
        }


        [HttpDelete]
        [Route("[action]/{job}")]
        public IActionResult Delete(string job)
        {
            var jobData = _jobService.Get(job);
            if (job == null)
            {
                return NotFound();
            }

            _jobService.Remove(jobData);

            return NoContent();
        }


        public JobController(Models.JobBoardContext _context)
        {
            this._jobService = new JobService(_context);
        }
    }
}
