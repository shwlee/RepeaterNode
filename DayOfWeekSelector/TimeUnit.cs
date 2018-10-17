using System;
using System.Collections.Generic;

namespace DayOfWeekSelector
{
	public class TimeUnit
	{
		private TimeUnit(TimeSpan value, string unitName)
		{
			this.Value = value;
			this.UnitName = unitName;
		}

		public TimeSpan Value { get; private set; }

		public string UnitName { get; }

		public static TimeSpan operator *(int amount, TimeUnit unit)
		{
			return new TimeSpan(amount * unit.Value.Ticks);
		}

		public static TimeSpan operator *(double amount, TimeUnit unit)
		{
			return TimeSpan.FromMilliseconds(amount * unit.Value.TotalMilliseconds);
		}

		public static class TimeUnits
		{
			public static TimeUnit MilliSecond { get; } = new TimeUnit(TimeSpan.FromMilliseconds(1), nameof(MilliSecond));

			public static TimeUnit Second { get; } = new TimeUnit(TimeSpan.FromSeconds(1), nameof(Second));

			public static TimeUnit Minuite { get; } = new TimeUnit(TimeSpan.FromMinutes(1), nameof(Minuite));

			public static TimeUnit Hour { get; } = new TimeUnit(TimeSpan.FromHours(1), nameof(Hour));

			public static TimeUnit Day { get; } = new TimeUnit(TimeSpan.FromDays(1), nameof(Day));

			public static IReadOnlyCollection<TimeUnit> UnitSet { get; } = new List<TimeUnit>
			{
				Second,
				Minuite,
				Hour,
				Day
			}.AsReadOnly();
		}
	}
}
