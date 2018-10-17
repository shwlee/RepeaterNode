using System;
using System.Collections.Generic;

namespace DayOfWeekSelector
{
	public class TimeSet
	{
		public static IReadOnlyCollection<TimeSpan> Hours { get; }

		public static IReadOnlyCollection<TimeSpan> Minuiues { get; }

		public static IReadOnlyCollection<TimeSpan> Seconds { get; }

		public TimeSpan SelectedHour { get; set; }

		public TimeSpan SelectedMinuite { get; set; }

		public TimeSpan SelectedSecond { get; set; }

		public TimeSpan Value => this.SelectedHour + this.SelectedMinuite + this.SelectedSecond;

		static TimeSet()
		{
			// init hours
			var hours = new List<TimeSpan>();
			for (var i = 0; i < 24; i++)
			{
				hours.Add(TimeSpan.FromHours(i));
			}
			Hours = hours.AsReadOnly();

			// init minuites
			var minuites = new List<TimeSpan>();
			for (var i = 0; i < 60; i++)
			{
				minuites.Add(TimeSpan.FromMinutes(i));
			}
			Minuiues = minuites.AsReadOnly();

			// init seconds
			var seconds = new List<TimeSpan>();
			for (var i = 0; i < 60; i++)
			{
				seconds.Add(TimeSpan.FromSeconds(i));
			}

			Seconds = seconds.AsReadOnly();
		}
	}
}
