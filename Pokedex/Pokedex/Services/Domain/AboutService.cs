using Pokedex.Models;
using Pokedex.Models.Interfaces;
using Pokedex.Services.Interfaces;

namespace Pokedex.Services.Domain
{
    public class AboutService : IDetailInfoService
    {
        public string NamePage => "About";
        public About About { get; set; }
        public PokemonDetail Detail { get; set; }

        public AboutService(PokemonDetail detail)
        {
            this.Detail = detail;
        }


        public IDetailModel CreateDetail()
        {
            var about = new About();
            about.Weight = this.Detail.Weight.ToString();
            about.Height = this.Detail.Height.ToString();
            about.Abilities = GetAbilities();
            about.Name = this.NamePage;

            return this.About = about;
        }

        private string GetAbilities()
        {
            var abilities = string.Empty;

            if (this.Detail?.Abilities != null)
            {
                foreach (var ability in this.Detail.Abilities)
                {
                    abilities = abilities + ability.ability.Name + ",";
                }
                abilities = abilities.Remove(abilities.Length - 1);

            }

            return abilities;
        }
    }
}
