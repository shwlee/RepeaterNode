using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DayOfWeekSelector
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private ScheduleTypes _scheduleType = ScheduleTypes.Interval;

		public DaysContext Days { get; } = new DaysContext();

		public IReadOnlyCollection<DaySelection> IntervalDaySelections { get; } = new List<DaySelection>
		{
			new DaySelection{Day = DayOfWeek.Sunday},
			new DaySelection{Day = DayOfWeek.Monday},
			new DaySelection{Day = DayOfWeek.Tuesday},
			new DaySelection{Day = DayOfWeek.Wednesday},
			new DaySelection{Day = DayOfWeek.Thursday},
			new DaySelection{Day = DayOfWeek.Friday},
			new DaySelection{Day = DayOfWeek.Saturday},
		}.AsReadOnly();
		
		public IReadOnlyCollection<DaySelection> TimeTriggerDaySelections { get; } = new List<DaySelection>
		{
			new DaySelection{Day = DayOfWeek.Sunday},
			new DaySelection{Day = DayOfWeek.Monday},
			new DaySelection{Day = DayOfWeek.Tuesday},
			new DaySelection{Day = DayOfWeek.Wednesday},
			new DaySelection{Day = DayOfWeek.Thursday},
			new DaySelection{Day = DayOfWeek.Friday},
			new DaySelection{Day = DayOfWeek.Saturday},
		}.AsReadOnly();

		public ObservableCollection<TimeSet> TimeSets { get; } = new ObservableCollection<TimeSet>
		{
			new TimeSet()
		};

		public ScheduleTypes ScheduleType
		{
			get => this._scheduleType;
			set
			{
				this._scheduleType = value;
				this.OnPropertyChanged();
			} 
		}

		public int Interval { get; set; }

		public TimeUnit SelectedTimeUnit { get; set; }

		public TimeSpan StartTime { get; set; }

		public TimeSpan EndTime { get; set; }



		#region Commands

		private RelayCommand _addTimeSetCommand;

		public ICommand AddTimeSetCommand => this._addTimeSetCommand ?? (this._addTimeSetCommand = new RelayCommand(this.AddTimeSet));

		private void AddTimeSet(object obj)
		{
			var newTimeSet = new TimeSet();
			this.TimeSets.Add(newTimeSet);
		}

		private RelayCommand _removeTimeSetCommand;

		public ICommand RemoveTimeSetCommand => 
			this._removeTimeSetCommand ?? (this._removeTimeSetCommand = new RelayCommand(this.RemoveTimeSet, this.CanExecuteRemove));

		private bool CanExecuteRemove(object obj)
		{
			return this.TimeSets.Count > 1;
		}

		private void RemoveTimeSet(object obj)
		{
			if (!(obj is TimeSet timeSet))
			{
				return;
			}

			this.TimeSets.Remove(timeSet);
		}


		private RelayCommand _setDaysCommand;

		public ICommand SetDaysCommand => this._setDaysCommand ?? (this._setDaysCommand = new RelayCommand(this.SetDays));

		private void SetDays(object obj)
		{


			if (!(obj is DaySelection daySelection))
			{
				return;
			}

			if (daySelection.IsSelected)
			{
				if (this.Days.DaysOfWeek.Any(d => d == daySelection.Day))
				{
					return;
				}

				this.Days.DaysOfWeek.Add(daySelection.Day);
			}
			else
			{
				this.Days.DaysOfWeek.Remove(daySelection.Day);
			}
		}

		private RelayCommand _saveCommand;
		
		public ICommand SaveCommand => this._saveCommand ?? (this._saveCommand = new RelayCommand(this.Save));

		private void Save(object obj)
		{
			
		}

		#endregion


		#region PropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}
