using JobBoardApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardGUI.Repository
{
    public class JobRepository : IJob
    {
        public Jobs Create(Jobs jobs)
        {
            Jobs jobResult = new Jobs();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalParameters.WebAPIBaseUrl);
                var JSONUserInfo = JsonConvert.SerializeObject(jobs);
                string data = JSONUserInfo.ToString();


                var response = client.PostAsync("Job/Create", new StringContent(data, Encoding.UTF8, "application/json"));
                response.Wait();
                HttpResponseMessage result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    jobResult = JsonConvert.DeserializeObject<Jobs>(readTask.Result);
                }
            }
            return jobResult;
        }
        public Jobs Get(int jobKey)
        {
            Jobs job = new Jobs();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalParameters.WebAPIBaseUrl);

                var response = client.GetAsync($"Job/{jobKey}");

                response.Wait();
                HttpResponseMessage result = response.Result;
                if (result.IsSuccessStatusCode)
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
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    jobList = JsonConvert.DeserializeObject<List<Jobs>>(readTask.Result);
                }
            }

            return jobList;
        }

        public void Remove(int jobKey)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalParameters.WebAPIBaseUrl);
                

                var response = client.DeleteAsync($"Job/{jobKey}");
                response.Wait();
                HttpResponseMessage result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var results = readTask.Result;
                }
            }
        }

        public Jobs Update(Jobs jobs)
        {
            Jobs jobResult = new Jobs();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalParameters.WebAPIBaseUrl);
                var  JSONUserInfo = JsonConvert.SerializeObject(jobs);
                string data = JSONUserInfo.ToString();


                var response = client.PutAsync("Job/Update", new StringContent(data, Encoding.UTF8, "application/json"));
                response.Wait();
                HttpResponseMessage result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    jobResult = JsonConvert.DeserializeObject<Jobs>(readTask.Result);
                }
            }

            return jobs;
        }

        
    }
}
