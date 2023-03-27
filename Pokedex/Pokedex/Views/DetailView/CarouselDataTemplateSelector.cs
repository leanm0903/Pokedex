
using System.Collections.Generic;
using Xamarin.Forms;

using Pokedex.Models.Interfaces;

namespace Pokedex.Views
{
    public class CarouselDataTemplateSelector : DataTemplateSelector
    {
        private Dictionary<string, DataTemplate> detailTemplate = new Dictionary<string, DataTemplate>
        {
            { "About", new DataTemplate(typeof(AboutView)) },
            { "BaseStats", new DataTemplate(typeof(BaseStatsView)) },
            { "Movie", new DataTemplate(typeof(MovieView)) },
            { "Evolution", new DataTemplate(typeof(EvolutionView)) },
        };

        public CarouselDataTemplateSelector()
        {

        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var detailService = item as IDetailModel;
            var name = detailService.Name;
            var template = detailTemplate[name];
            return template;
        }
    }
}
