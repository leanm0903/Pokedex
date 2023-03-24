using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Pokedex.Models;
using Pokedex.Services.Interfaces;
using Pokedex.ViewModels.Base;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class PokemonDetailViewModel : BaseViewModel
    {

        public string Name { get; set; }
        private PokemonDetail detail;
        private string abilities;
        private readonly IPokemonService pokemonService;

        public PokemonDetail Detail
        {
            get
            {
                return detail;
            }
            set
            {
                detail = value;
                RaisePropertyChanged(() => Detail);
            }
        }
        public string Abilities
        {
            get
            {
                return abilities;
            }
            set
            {
                abilities = value;
                RaisePropertyChanged(() => Abilities);
            }

        }

        public ICommand GetDetail { get; }

        public PokemonDetailViewModel(IPokemonService pokemonService)
        {
            Detail = new PokemonDetail();
            this.pokemonService = pokemonService;

            GetDetail = new Command(async () =>
            {
                Detail = await this.pokemonService.GetPokemonDetailByNameOrId(Name);
                Abilities = SetAbilities();
            });
        }

        public override async Task InitializeAsync(object navigationData)
        {
            GetDetail.Execute(null);               
        }

        public string SetAbilities()
        {
            var abilities = string.Empty;

            if(detail?.Abilities != null)
            {

                foreach (var ability in detail.Abilities)
                {
                    abilities = abilities + ability.ability.Name + ",";
                }
                abilities = abilities.Remove(abilities.Length - 1);

            }

            return abilities;
        }
    }
}