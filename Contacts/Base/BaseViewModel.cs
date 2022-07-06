using System.ComponentModel;

namespace Contacts
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}