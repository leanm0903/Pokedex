using System;

using Pokedex.Models;
using Pokedex.Models.Interfaces;
using Pokedex.Services.Interfaces;

namespace Pokedex.Services.Domain
{
    public class MovieService : IDetailInfoService
    {
        public string NamePage => "Movie";
        public PokemonDetail Detail { get; set; }


        public MovieService(PokemonDetail detail)
        {
            Detail = detail;
        }


        public IDetailModel CreateDetail()
        {
            return new Movie
            {
                Name = NamePage
            };
        }
    }
}
