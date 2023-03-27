using Pokedex.Models.Interfaces;

namespace Pokedex.Models
{
    public class About : IDetailModel
    {
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Abilities { get; set; }
        public string Species { get; set; }
        public string Name { get; set; }
    }
}
