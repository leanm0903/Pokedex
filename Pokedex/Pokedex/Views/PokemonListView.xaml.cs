using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pokedex.ViewModels;

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

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            await Navigation.PushAsync(new PokemonDetailView());

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}

