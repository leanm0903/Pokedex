using Pokedex.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Views
{
    [QueryProperty(nameof(Name), "Name")]
    public partial class PokemonDetailView : ContentPage
    {
        public string Name
        {
            set
            {
                LoadPokemon(value);
            }
        }

    void LoadPokemon(string name)
        {
            try
            {
                var context = (PokemonDetailViewModel)this.content.Content.BindingContext;
                context.Detail = null;
                context.Name = name;
                context.GetDetail.Execute(null);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load animal.");
            }
        }
        public PokemonDetailView()
        {
            InitializeComponent();
        }

        private void OnNavTapped(object sender, EventArgs e)
        {
            var events = e;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}