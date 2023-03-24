using Pokedex.Commons.Identifiers;

using System.Collections.Generic;
using Xamarin.Forms;

namespace Pokedex.Commons.Dictionaries
{
    public static class ColorDicctionary
    {
        public static Dictionary<string, Color> ColorType => colorType;
        public static Dictionary<string, Color> SecondaryColor => secondaryColor;

        private static Dictionary<string, Color> colorType = new Dictionary<string, Color>
        {
            { PokemonTypes.Normal, (Color) Application.Current.Resources[ColorKey.YellowTertiary] },
            { PokemonTypes.Dragon, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Dark, (Color) Application.Current.Resources[ColorKey.DarkPrimary] },
            { PokemonTypes.Fairy, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Bug, (Color) Application.Current.Resources[ColorKey.BrownPrimary] },
            { PokemonTypes.Electric, (Color) Application.Current.Resources[ColorKey.YellowTertiary] },
            { PokemonTypes.Flying, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Ghost, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Poison, (Color) Application.Current.Resources[ColorKey.PurpleTertiary] },
            { PokemonTypes.Ice, (Color) Application.Current.Resources[ColorKey.BlueTertiary] },
            { PokemonTypes.Psychic, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Water, (Color) Application.Current.Resources[ColorKey.BluePrimary] },
            { PokemonTypes.Unknown, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Steel, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Shadow, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Fire, (Color) Application.Current.Resources[ColorKey.Tertiary] },
            { PokemonTypes.Rock, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Grass, (Color) Application.Current.Resources[ColorKey.GreenTertiary] },
            { PokemonTypes.Ground, (Color) Application.Current.Resources[ColorKey.BrownTertiary] }
        };
        private static Dictionary<string, Color> secondaryColor = new Dictionary<string, Color>
        {
            { PokemonTypes.Normal, (Color) Application.Current.Resources[ColorKey.YellowTertiary] },
            { PokemonTypes.Dragon, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Dark, (Color) Application.Current.Resources[ColorKey.DarkSecondary] },
            { PokemonTypes.Fairy, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Bug, (Color) Application.Current.Resources[ColorKey.BrownSecondary] },
            { PokemonTypes.Electric, (Color) Application.Current.Resources[ColorKey.YellowSecondary] },
            { PokemonTypes.Flying, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Ghost, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Poison, (Color) Application.Current.Resources[ColorKey.PurpleSecondary] },
            { PokemonTypes.Ice, (Color) Application.Current.Resources[ColorKey.BlueTertiary] },
            { PokemonTypes.Psychic, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Water, (Color) Application.Current.Resources[ColorKey.BlueSecondary] },
            { PokemonTypes.Unknown, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Steel, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Shadow, (Color) Application.Current.Resources[ColorKey.LightTertiary] },
            { PokemonTypes.Fire, (Color) Application.Current.Resources[ColorKey.Secondary] },
            { PokemonTypes.Rock, (Color) Application.Current.Resources[ColorKey.Secondary] },
            { PokemonTypes.Grass, (Color) Application.Current.Resources[ColorKey.GreenSecondary] },
            { PokemonTypes.Ground, (Color) Application.Current.Resources[ColorKey.BrownSecondary] }
        };

    }
}
