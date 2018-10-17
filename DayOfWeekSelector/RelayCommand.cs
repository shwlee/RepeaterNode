﻿using System;
using System.Windows.Input;

namespace DayOfWeekSelector
{
	public class RelayCommand : ICommand
	{
		private readonly Predicate<object> _canExecute;

		private readonly Action<object> _execute;

		public RelayCommand(Action<object> execute) : this(execute, null)
		{
			this._execute = execute;
		}

		public RelayCommand(Action<object> execute, Predicate<object> canExecute)
		{
			this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
			this._canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return this._canExecute == null || this._canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			this._execute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}
	}
}
