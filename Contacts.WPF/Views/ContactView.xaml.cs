using System.Windows.Controls;

namespace Contacts.WPF.Views
{
    /// <summary>
    /// Interaktionslogik für ContactView.xaml
    /// </summary>
    public partial class ContactView : UserControl
    {
        public ContactView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Name.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            PhoneNumber.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            Email.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            Address.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}