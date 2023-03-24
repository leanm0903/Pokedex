using Pokedex.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PokemonDetailView), typeof(PokemonDetailView));
        }
    }
}