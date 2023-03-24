namespace Pokedex.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Ability
    {
        public AbilityType ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }
}

