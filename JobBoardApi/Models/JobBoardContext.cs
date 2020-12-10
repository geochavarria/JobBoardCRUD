using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApi.Models
{
    public class JobBoardContext : DbContext
    {
        public JobBoardContext(DbContextOptions<JobBoardContext> options) : base(options) { }

        public DbSet<Jobs> JobsData { get; set; }


        //Seeding Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var jobs = new List<Jobs>
            {
                new  Jobs{
                    JobTitle = "Ingeniero de Software Web",
                    Description = "Diseño y desarrollo de aplicaciones web y moviles",
                    CreatedAt = DateTime.Now,
                    ExpiresAt = DateTime.Now.AddDays(4)
                },
                new  Jobs{
                    JobTitle = "Desarrollador Java Jr.",
                    Description = "Aplicacion de tecnicas basicas y avanzadas de JAVA",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    ExpiresAt = DateTime.Now.AddDays(2)
                },
            };

            modelBuilder.Entity<Jobs>().HasData(jobs);
        }
    }
}
