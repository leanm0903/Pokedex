using System.Collections.Generic;

namespace Pokedex.Models.Response
{
    public class GetPokemonsResponse
    {
        public long Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Pokemon> Results { get; set; }
    }
}