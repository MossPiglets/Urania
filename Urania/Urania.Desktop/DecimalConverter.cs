using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Urania.Desktop {
	public class DecimalConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter,
		                      System.Globalization.CultureInfo culture) {
			return value?.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter,
		                          System.Globalization.CultureInfo culture) {
			if (value == null) return null;
			var input = (string) value;
			var decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
			return input.EndsWith(decimalSeparator) ? decimalSeparator : value;
		}
	}
}