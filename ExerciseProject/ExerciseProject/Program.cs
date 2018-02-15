using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ExerciseProject.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExerciseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var peopleList = FetchPeopleData().GetAwaiter().GetResult();
            List<string> MaleCats = new List<string>();
            List<string> FemaleCats = new List<string>();
            foreach (var person in peopleList)
            {
                if (person.Gender.ToLower().Equals("male") && person.Pets != null)
                {
                    foreach (var pet in person.Pets)
                    {
                        if (pet.Type.ToLower().Equals("cat"))
                        {
                            MaleCats.Add(pet.Name);
                        }
                    }
                }
                else
                {
                    if (person.Pets != null)
                    {
                        foreach (var pet in person.Pets)
                        {
                            if (pet.Type.ToLower().Equals("cat"))
                            {
                                FemaleCats.Add(pet.Name);
                            }
                        }
                    }
                    
                }
            }

            MaleCats.Sort();
            FemaleCats.Sort();
            Console.WriteLine("Male");
            foreach (var mcats in MaleCats)
            {
                Console.WriteLine(mcats);
            }
            Console.WriteLine("Female");
            foreach (var mcats in MaleCats)
            {
                Console.WriteLine(mcats);
            }
            Console.ReadLine();
        }

        
        public static async Task<IEnumerable<People>> FetchPeopleData()
        {
            List<People> peopleList;
            string peopleInfo =string.Empty;

            using (var httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri("http://localhost:55514/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("http://localhost:55514/api/people");
                if (response.IsSuccessStatusCode)
                {
                    peopleInfo = await response.Content.ReadAsStringAsync(); //ReadAsAsync<Product>();
                }
                peopleList = JsonConvert.DeserializeObject<List<People>>(JRaw.Parse(peopleInfo).ToString());
            }

            return peopleList;

        }
    }
}
