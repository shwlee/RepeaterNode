using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace DayOfWeekSelector
{
	public class DaySelectToggleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				if (!(value is ToggleButton toggle))
				{
					throw new Exception("The value is not ToggleButton type.");
				}

				var day = (DayOfWeek)toggle.Tag;
				var isChecked = toggle.IsChecked.HasValue && toggle.IsChecked.Value;

				return new DaySelection
				{
					Day = day,
					IsSelected = isChecked
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return DependencyProperty.UnsetValue;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				if (!(value is ToggleButton toggle))
				{
					throw new Exception("The value is not ToggleButton type.");
				}

				var day = (DayOfWeek)toggle.Tag;
				var isChecked = toggle.IsChecked.HasValue && toggle.IsChecked.Value;

				return new DaySelection
				{
					Day = day,
					IsSelected = isChecked
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return DependencyProperty.UnsetValue;
			}
		}
	}
}
