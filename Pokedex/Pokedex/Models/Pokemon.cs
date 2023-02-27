using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public class Pokemon
	{
        public string Name { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
        public PokemonDetail Detail { get; set; }

        public Pokemon()
		{
		}
    }
}

