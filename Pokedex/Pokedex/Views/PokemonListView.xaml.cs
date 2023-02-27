using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pokedex.ViewModels;
using Pokedex.ViewModels.Base;

namespace Pokedex.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonListView : ContentPage
    {
        public PokemonListView()
        {
            InitializeComponent(); 
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

        private void pokemons_Scrolled(object sender, ScrolledEventArgs e)
        {
            Console.Write(e.ScrollX);
        }
    }
}

