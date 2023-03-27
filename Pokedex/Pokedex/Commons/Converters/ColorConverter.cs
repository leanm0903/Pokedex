using Pokedex.Commons.Identifiers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Pokedex.Commons.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var position = (string)parameter;
            var actualValue = (int)value;
            var color = actualValue == int.Parse(position) ? (Color)Application.Current.Resources[ColorKey.DarkTertiary] : Color.Transparent;
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
