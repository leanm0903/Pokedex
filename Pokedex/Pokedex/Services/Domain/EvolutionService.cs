using Pokedex.Models;
using Pokedex.Models.Interfaces;
using Pokedex.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Services.Domain
{
    public class EvolutionService : IDetailInfoService
    {
        public string NamePage => "Evolution";

        public PokemonDetail Detail { get; set; }

        public EvolutionService(PokemonDetail detail)
        {
            Detail = detail;
        }

        public IDetailModel CreateDetail()
        {
            return new Evolution
            {
                Name = NamePage,
            };
        }
    }
}
