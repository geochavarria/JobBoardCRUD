using JobBoardApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApi.Services
{
    public class JobService
    {
        private DbSet<Jobs> Jobs;
        private JobBoardContext context;
        public JobService(JobBoardContext _context)
        {
            this.context = _context;
            this.Jobs = _context.JobsData;

        }

        /// <summary>
        /// List of All Data
        /// </summary>
        /// <returns></returns>
        public List<Jobs> GetAll()
        {
            return Jobs.ToList();
        }


        /// <summary>
        /// Get unique Job
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public Jobs Get(int job)
        {
            return Jobs.ToList().Find(x => x.Job == job);
        }

        /// <summary>
        /// Insert Job
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Jobs Insert(Jobs data)
        {
            var last = Jobs.LastOrDefault();//Get current value
            int nextValue = last == null ? 1 : last.Job+1;
            data.Job = nextValue ; //Id Auto
            Jobs.Add(data);
            context.SaveChanges();
            return data;
        }

        /// <summary>
        /// Updata Job
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Jobs Update(Jobs data)
        {
            if (!Jobs.Any(x => x.Job == data.Job))
            {
                return null;
            }

            Jobs.Update(data);
            context.SaveChanges();
            return data;
        }

        /// <summary>
        /// Remove Job
        /// </summary>
        /// <param name="data"></param>
        public void Remove(Jobs data)
        {
            if (!Jobs.Any(x => x.Job == data.Job))
            {
                return;
            }
            Jobs.Remove(data);
            context.SaveChanges();
        }
    }
}
