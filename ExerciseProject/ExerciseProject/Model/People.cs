using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Newtonsoft.Json;

namespace ExerciseProject.Model
{
    
   public class People
    {
        public People(IEnumerable<Pet> pets)
        {
            Pets = new List<Pet>();
        }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("pets")]
        public IEnumerable<Pet> Pets { get; set; }
    }
}
