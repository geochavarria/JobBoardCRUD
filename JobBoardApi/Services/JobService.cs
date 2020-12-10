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

        public List<Jobs> GetAll()
        {
            return Jobs.ToList();
        }


        public Jobs Get(string job)
        {
            return Jobs.ToList().Find(x => x.Job == job);
        }


        public Jobs Insert(Jobs data)
        {
            Jobs.Add(data);
            context.SaveChanges();
            return data;
        }

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
