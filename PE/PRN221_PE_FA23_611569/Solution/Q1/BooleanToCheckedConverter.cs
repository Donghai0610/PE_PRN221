using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Q1
{
	public class BooleanToCheckedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool?)
			{
				bool? boolValue = (bool?)value;
				if (parameter is string param)
				{
					return boolValue.HasValue && boolValue.Value == (param == "True");
				}
			}
			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// Convert the checked state back to a bool?
			if (value is bool boolValue)
			{
				// Return true if the parameter is "True", otherwise return false
				return (parameter as string) == "True" ? boolValue : !boolValue;
			}
			return null; // Default case if the value is not a boolean
		}
	}
}
