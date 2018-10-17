using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DayOfWeekSelector
{
	public class DaySelection : INotifyPropertyChanged
	{
		private bool _isSelected;

		public DayOfWeek Day { get; set; }

		public bool IsSelected
		{
			get => this._isSelected;
			set
			{
				this._isSelected = value;
				this.OnPropertyChanged();
			} 
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
