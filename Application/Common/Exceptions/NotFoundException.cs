using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        object _key;

        public NotFoundException(string messageTemplate, object key)
            : base(messageTemplate)
//            : base($"Entity \"{name}\" ({key}) was not found.")
        {
            _key = key;
        }

    }

}
