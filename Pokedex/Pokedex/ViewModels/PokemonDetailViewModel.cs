using System;
using System.Collections.ObjectModel;
using System.Reflection;
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
        private string nameScreen;
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

        public string NameScreen
        {
            get
            {
                return nameScreen;
            }
            set
            {
                nameScreen = value;
                RaisePropertyChanged(() => NameScreen);
            }

        }
        public ICommand GetDetail { get; }

        public ICommand GetNextDetail => new Command(async() =>
        {
            var nextId = detail.Id + 1;
            await this.SetDetail(nextId.ToString());
        });

        public ICommand GetPreviusDetail => new Command( async() =>
        {
            var nextId = detail.Id -1;
            if(nextId != 0)
            {
                await this.SetDetail(nextId.ToString());
            }
        });
        public ICommand SetScreenName => new Command<string>((string name) =>
        {
            this.NameScreen = name;
        });

        public PokemonDetailViewModel(IPokemonService pokemonService)
        {
            Detail = new PokemonDetail();
            this.pokemonService = pokemonService;

            GetDetail = new Command(async () =>
            {
                await SetDetail(this.Name);
            });
        }

        private async Task SetDetail(string nameOrId)
        {
            Detail = await this.pokemonService.GetPokemonDetailByNameOrId(nameOrId);
            Abilities = SetAbilities();
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

        public bool IsVisible(string name)
        {
            return name == this.NameScreen;
        }
    }
}