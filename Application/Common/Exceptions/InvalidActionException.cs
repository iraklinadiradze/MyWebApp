using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class InvalidActionException : Exception
    {
        public InvalidActionException(string operation, string state , string entityType, string key)
            : base($"Can not make , because ({key}) was not found.")
        {
        }
    }

}
