namespace Pokedex.Models
{
    public class PokemonType
    {
        public int Slot { get; set; }
        public TypeDetail Type { get; set; }
    }
    
    public class TypeDetail
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}

