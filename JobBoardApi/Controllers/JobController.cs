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

        [HttpGet("{jobKey}", Name = "GetJob")]
        public ActionResult<Jobs> Get(int jobKey)
        {
            var jobResult = _jobService.Get(jobKey);
            if (jobResult != null)
            {
                return jobResult;
            }

            return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Jobs job)
        {
            var result = _jobService.Insert(job);
            return CreatedAtRoute("GetJob", new { jobKey = result.Job }, result);
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
            return CreatedAtRoute("GetJob", new { jobKey = result.Job }, result);
        }


        [HttpDelete]
        [Route("{jobKey}")]
        public IActionResult Delete(int jobKey)
        {
            var jobData = _jobService.Get(jobKey);
            if (jobData == null)
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
