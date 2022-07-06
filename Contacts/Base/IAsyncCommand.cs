using System.Threading.Tasks;
using System.Windows.Input;

namespace Contacts
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();

        bool CanExecute();

        public void RaiseCanExecuteChanged();
    }

    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);

        bool CanExecute(T parameter);

        public void RaiseCanExecuteChanged();
    }
}