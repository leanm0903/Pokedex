using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pokedex.ViewModels;
using System.Threading.Tasks;

namespace Pokedex.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonListView : ContentPage
    {

        public PokemonListView()
        {
            InitializeComponent();
            var context = (PokemonListViewModel)this.content.Content.BindingContext;
            context.SetPokemons.Execute(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}

