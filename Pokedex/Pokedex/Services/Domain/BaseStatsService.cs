using Pokedex.Models;
using Pokedex.Models.Interfaces;
using Pokedex.Services.Interfaces;

namespace Pokedex.Services.Domain
{
    public class BaseStatsService : IDetailInfoService
    {
        public PokemonDetail Detail { get; set; }

        public string NamePage => "BaseStats";
        public BaseStatsService(PokemonDetail detail)
        {
            this.Detail = detail;
        }


        public IDetailModel CreateDetail()
        {
            return new BaseStats
            {
                HealthPoints = 30,
                Name = NamePage
            };
        }
    }
}
