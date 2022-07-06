using System.Threading.Tasks;

namespace Contacts
{
    public class ContactViewModel : BaseViewModel
    {
        #region Settings

        public int Name_MaxLength { get; } = 50;
        public int PhoneNumber_MaxLength { get; } = 30;
        public int Email_MaxLength { get; } = 50;
        public int Address_MaxLength { get; } = 100;

        #endregion Settings

        #region Private Members

        private bool isNew;

        private ContactDataModel contact = new ContactDataModel();

        private ContactDataModel oldContact = new ContactDataModel();

        #endregion Private Members

        #region Public Properties

        public string Name
        {
            get { return contact.Name; }
            set
            {
                contact.Name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Existing));
                try
                {
                    SaveCommand.RaiseCanExecuteChanged();
                }
                catch { }
            }
        }

        public string PhoneNumber
        {
            get { return contact.PhoneNumber; }
            set
            {
                contact.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Email
        {
            get { return contact.Email; }
            set
            {
                contact.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Address
        {
            get { return contact.Address; }
            set
            {
                contact.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public bool Existing
        {
            get
            {
                bool result = false;
                if (this.contact.Name != this.oldContact.Name)
                {
                    ViewModelLocator.Instance.MainViewModel.ContactListViewModel.Contacts.ForEach((contact) =>
                    {
                        if (contact.Name == this.contact.Name)
                        {
                            result = true;
                        }
                    });
                }
                return result;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void LoadContact(ContactDataModel contact)
        {
            oldContact = contact;
            Name = contact.Name;
            PhoneNumber = contact.PhoneNumber;
            Email = contact.Email;
            Address = contact.Address;
            isNew = false;
        }

        public void Clear()
        {
            oldContact = new ContactDataModel();
            Name = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            isNew = true;
        }

        #endregion Public Methods

        #region Commands

        public IAsyncCommand CancelCommand { get; set; }

        public IAsyncCommand SaveCommand { get; set; }

        public IAsyncCommand RemoveCommand { get; set; }

        #endregion Commands

        #region Command Methods

        public async Task CancelAsync()
        {
            Task clearTask = Task.Run(() =>
            {
                Clear();
            });

            ViewModelLocator.Instance.MainViewModel.UpdateView(ApplicationPage.ContactList);
            await clearTask;
        }

        public async Task SaveAsync()
        {
            switch (isNew)
            {
                case true:
                    Task addTask = Task.Run(() =>
                    {
                        ViewModelLocator.Instance.MainViewModel.ContactListViewModel.AddContact(new ContactDataModel(
                            Name,
                            PhoneNumber,
                            Email,
                            Address));
                    });

                    ViewModelLocator.Instance.MainViewModel.UpdateView(ApplicationPage.ContactList);
                    await addTask;
                    Clear();
                    break;

                case false:
                    Task saveTask = Task.Run(() =>
                    {
                        ViewModelLocator.Instance.MainViewModel.ContactListViewModel.RemoveContact(oldContact.Name);
                        ViewModelLocator.Instance.MainViewModel.ContactListViewModel.AddContact(new ContactDataModel(
                            Name,
                            PhoneNumber,
                            Email,
                            Address));
                    });

                    ViewModelLocator.Instance.MainViewModel.UpdateView(ApplicationPage.ContactList);
                    await saveTask;
                    Clear();
                    break;
            }
        }

        public async Task RemoveAsync()
        {
            switch (isNew)
            {
                case true:
                    Task clearTask = Task.Run(() =>
                    {
                        Clear();
                    });

                    ViewModelLocator.Instance.MainViewModel.UpdateView(ApplicationPage.ContactList);
                    await clearTask;
                    break;

                case false:
                    Task removeTask = Task.Run(() =>
                    {
                        ViewModelLocator.Instance.MainViewModel.ContactListViewModel.RemoveContact(oldContact.Name);
                    });

                    ViewModelLocator.Instance.MainViewModel.UpdateView(ApplicationPage.ContactList);
                    await removeTask;
                    Clear();
                    break;
            }
        }

        #endregion Command Methods

        #region Constructor

        public ContactViewModel()
        {
            CancelCommand = new AsyncCommand(CancelAsync, () => true);
            SaveCommand = new AsyncCommand(SaveAsync, () => !Existing);
            RemoveCommand = new AsyncCommand(RemoveAsync, () => true);
            OnPropertyChanged(nameof(Name));
        }

        #endregion Constructor
    }
}