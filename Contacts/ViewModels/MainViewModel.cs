using System;

namespace Contacts
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties

        private ContactListViewModel contactListViewModel = new ContactListViewModel();

        public ContactListViewModel ContactListViewModel
        {
            get { return contactListViewModel; }
            set
            {
                contactListViewModel = value;
                OnPropertyChanged(nameof(ContactListViewModel));
            }
        }

        private ContactViewModel contactViewModel = new ContactViewModel();

        public ContactViewModel ContactViewModel
        {
            get { return contactViewModel; }
            set
            {
                contactViewModel = value;
                OnPropertyChanged(nameof(ContactViewModel));
            }
        }

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void UpdateView(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.ContactList:
                    CurrentViewModel = ContactListViewModel;
                    break;

                case ApplicationPage.Contact:
                    CurrentViewModel = ContactViewModel;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        #endregion Public Methods

        #region Constructor

        public MainViewModel()
        {
            CurrentViewModel = ContactListViewModel;
        }

        #endregion Constructor
    }
}