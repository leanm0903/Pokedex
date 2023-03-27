using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

using Pokedex.Models;
using Pokedex.Models.Interfaces;
using Pokedex.Services.Domain;
using Pokedex.Services.Interfaces;
using Pokedex.ViewModels.Base;

namespace Pokedex.ViewModels
{
    public class PokemonDetailViewModel : BaseViewModel
    {

        public string Name { get; set; }
        private PokemonDetail detail;
        private int positionSelected;
        private readonly IPokemonService pokemonService;

        private List<IDetailModel> detailInfo;

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

        public List<IDetailModel> DetailInfo
        {
            get
            {
                return this.detailInfo ?? new List<IDetailModel>();
            }
            set
            {
                detailInfo = value;
                RaisePropertyChanged(() => DetailInfo);
            }
        }

        public int PositionSelected
        {
            set
            {
                positionSelected = value;
                RaisePropertyChanged(() => PositionSelected);

            }
            get => positionSelected;
        }

        public ICommand GetDetail { get; }
        public ICommand SelectItemCommand { get => new Command<string>((param) => PositionSelected = int.Parse(param)); }


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


        public PokemonDetailViewModel(IPokemonService pokemonService)
        {
            Detail = new PokemonDetail();
            this.pokemonService = pokemonService;

            GetDetail = new Command(async () =>
            {
                await SetDetail(this.Name);

                this.detailInfo = new List<IDetailInfoService>
                {
                    new AboutService(Detail),
                    new BaseStatsService(Detail),
                    new MovieService(Detail),
                    new EvolutionService(Detail),

                }.Select(x => x.CreateDetail()).ToList();
            });
        }

        private async Task SetDetail(string nameOrId)
        {
            Detail = await this.pokemonService.GetPokemonDetailByNameOrId(nameOrId);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            GetDetail.Execute(null);           
        }
    }
}