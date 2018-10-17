using System;
using System.Globalization;
using System.Windows.Data;

namespace DayOfWeekSelector
{
	public class BoolFromSourceMatchConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				if (value == null)
				{
					return false; // or return parameter.Equals(YourEnumType.SomeDefaultValue);
				}

				return value.Equals(parameter);
			}
			catch (Exception ex)
			{
				return Binding.DoNothing;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				var boolean = (bool)value;

				return boolean ? parameter : Binding.DoNothing;
			}
			catch (Exception ex)
			{
				return Binding.DoNothing;
			}
		}
	}
}
