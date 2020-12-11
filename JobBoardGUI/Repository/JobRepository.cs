using JobBoardApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobBoardGUI.Repository
{
    public class JobRepository : IJob
    {
        public Jobs Create(Jobs jobs)
        {
         

            throw new NotImplementedException();
        }

        public Jobs Get(string jobKey)
        {
            Jobs job = new Jobs();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalParameters.WebAPIBaseUrl);

                
                var response = client.GetAsync($"Job/{jobKey}");


                response.Wait();
                HttpResponseMessage result = response.Result;
                if (response.IsCompleted)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    job = JsonConvert.DeserializeObject<Jobs>(readTask.Result);
                }
            }

            return job;
        }

        public List<Jobs> GetAll()
        {
            List<Jobs> jobList = new List<Jobs>(); 
            using (var client =  new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalParameters.WebAPIBaseUrl);

                var response = client.GetAsync("Job");
                response.Wait();
                HttpResponseMessage result = response.Result;
                if (response.IsCompleted)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    jobList = JsonConvert.DeserializeObject<List<Jobs>>(readTask.Result);
                }
            }

            return jobList;
        }

        public void Remove(string job)
        {
            throw new NotImplementedException();
        }

        public Jobs Update(Jobs jobs)
        {
            throw new NotImplementedException();
        }

        
    }
}
