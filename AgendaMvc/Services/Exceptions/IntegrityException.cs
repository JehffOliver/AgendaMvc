using System;

namespace AgendaMvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base (message)
        {
        }
    }
}
