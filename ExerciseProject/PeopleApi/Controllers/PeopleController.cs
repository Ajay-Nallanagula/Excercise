using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PeopleApi.Model;

namespace PeopleApi.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
       /* public List<People> pplList;
        public PeopleController()
        {
            pplList = new List<People>()
            {
                new People()
                {
                    Age = 1,
                    Gender = "male",
                    Name = "dfdg",
                    Pets = new List<Pet>() {new Pet() {Name = "kksk", Type = "Male"}}
                },
                new People()
                {
                    Age = 1,
                    Gender = "male",
                    Name = "xsjdh",
                    Pets = new List<Pet>() {new Pet() {Name = "qwert", Type = "Female"}}
                },
                new People()
                {
                    Age = 1,
                    Gender = "male",
                    Name = "xsjdh",
                    Pets = null
                }
            };
        }
        */
        // GET api/values
        [HttpGet]
        public string Get()
        {
            using (StreamReader r = new StreamReader(@"Data/People.json"))
            {
                return r.ReadToEnd();
            }
        }

        [HttpGet]
        [Route("GetResponse")]
        public async Task<string> GetResponse([FromQuery]int k)
        {
            IEnumerable<People> peopleList;
            string peopleInfo = string.Empty;

           // var serStr = JsonConvert.SerializeObject(pplList);
            //var deserStr = JsonConvert.DeserializeObject<List<People>>(serStr);

            using (var httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri("http://localhost:55515/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("http://localhost:55514/api/people");
                if (response.IsSuccessStatusCode)
                {
                    peopleInfo = await response.Content.ReadAsStringAsync(); //ReadAsAsync<Product>();
                }

                peopleList = JsonConvert.DeserializeObject<List<People>>(JRaw.Parse(peopleInfo).ToString());

            }

            return peopleInfo;
        }
    }
}

