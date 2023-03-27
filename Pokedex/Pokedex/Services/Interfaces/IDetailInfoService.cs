using Pokedex.Models;
using Pokedex.Models.Interfaces;

namespace Pokedex.Services.Interfaces
{
    public interface IDetailInfoService
    {
        string NamePage { get; }
        PokemonDetail Detail { get; set; }
        IDetailModel CreateDetail();
    }
}
