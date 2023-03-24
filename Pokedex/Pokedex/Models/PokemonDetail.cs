using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public class PokemonDetail
    {

        public List<Ability> Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int Experience { get; set; }

        public List<Form> Forms { get; set; }

        public int Height { get; set; }
        public List<object> held_items { get; set; }
        public int Id { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("location_area_encounters")]
        public string LocationAreaEncounter { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        [JsonProperty("past_types")]
        public List<object> PastTypes { get; set; }
        public Species Species { get; set; }
        public Sprites Sprites { get; set; }
        public List<Stat> Stats { get; set; }
        public List<PokemonType> Types { get; set; }
        public int Weight { get; set; }
    }
}

