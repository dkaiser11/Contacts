using System;
using System.Windows.Input;

namespace Contacts
{
    public class RelayCommand<T> : ICommand
        where T : class
    {
        #region Fields

        private Action<T> action;

        #endregion Fields

        #region Public Events

        public event EventHandler CanExecuteChanged;

        #endregion Public Events

        #region Constructor

        public RelayCommand(Action<T> action)
        {
            this.action = action;
        }

        #endregion Constructor

        #region Command Methods

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => this.action((T)parameter);

        #endregion Command Methods
    }

    public class RelayCommand : ICommand
    {
        #region Fields

        private Action action;

        #endregion Fields

        #region Public Events

        public event EventHandler CanExecuteChanged;

        #endregion Public Events

        #region Constructor

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        #endregion Constructor

        #region Command Methods

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => this.action();

        #endregion Command Methods
    }
}