using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts
{
    public class ContactListViewModel : BaseViewModel
    {
        #region Private Members

        private ContactListModel contactListModel = new ContactListModel();

        #endregion Private Members

        #region Public Properties

        public List<ContactDataModel> Contacts
        {
            get { return contactListModel.Contacts.ToList(); }
        }

        #endregion Public Properties

        #region Commands

        public IAsyncCommand<string> OpenContactCommand { get; set; }

        public IAsyncCommand NewContactCommand { get; set; }

        #endregion Commands

        #region Command Methods

        public async Task OpenContactAsync(string contactName)
        {
            Task loadTask = Task.Run(() =>
            {
                ViewModelLocator.Instance.MainViewModel.ContactViewModel.LoadContact(Contacts.Find(contact => contact.Name == contactName));
            });

            ViewModelLocator.Instance.MainViewModel.UpdateView(ApplicationPage.Contact);

            await loadTask;
        }

        public async Task NewContactAsync()
        {
            Task loadTask = Task.Run(() =>
            {
                ViewModelLocator.Instance.MainViewModel.ContactViewModel.Clear();
            });

            ViewModelLocator.Instance.MainViewModel.UpdateView(ApplicationPage.Contact);

            await loadTask;
        }

        #endregion Command Methods

        #region Public Methods

        public void RemoveContact(string name)
        {
            contactListModel.RemoveContact(name);
            OnPropertyChanged(nameof(Contacts));
        }

        public void AddContact(ContactDataModel contact)
        {
            contactListModel.AddContact(contact);
            OnPropertyChanged(nameof(Contacts));
        }

        #endregion Public Methods

        #region Constructor

        public ContactListViewModel()
        {
            OpenContactCommand = new AsyncCommand<string>(OpenContactAsync, (s) => true);
            NewContactCommand = new AsyncCommand(NewContactAsync, () => true);
        }

        #endregion Constructor
    }
}