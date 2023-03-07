using Pokedex.Commons.Dictionaries;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Pokedex.Models
{
    public class Pokemon
	{
        public string Name { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
        public PokemonDetail Detail { get; set; }

		public Color PrimaryColor
		{
            get { return GetColor(); }
		}

        public Color SecondaryColor
        {
            get { return GetSecondaryColor(); }
        }

        private Color GetColor()
		{
            var type = this.Detail.Types[0].Type.Name ?? string.Empty;

            var color = ColorDicctionary.ColorType.ContainsKey(type) ? (Color) ColorDicctionary.ColorType[type] : Color.Gray;

            return color;
        }

        private Color GetSecondaryColor()
        {
            var type = this.Detail.Types[0].Type.Name ?? string.Empty;

            var color = ColorDicctionary.ColorType.ContainsKey(type) ? (Color)ColorDicctionary.SecondaryColor[type] : Color.Black;

            return color;
        }
    }
}

