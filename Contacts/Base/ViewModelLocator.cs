namespace Contacts
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public MainViewModel MainViewModel { get; set; } = new MainViewModel();
    }
}