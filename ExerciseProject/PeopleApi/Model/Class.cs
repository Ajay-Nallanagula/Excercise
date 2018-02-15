using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PeopleApi.Model
{
    public class People
    {
       
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }
    }


    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class PeopleColl
    {
        public List<People> PeopleIter { get; set; }
    }
}
