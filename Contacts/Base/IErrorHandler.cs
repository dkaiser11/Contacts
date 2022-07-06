using System;

namespace Contacts
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}