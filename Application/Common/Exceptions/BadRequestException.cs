using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    class BadRequestException : Exception 
    {
        public BadRequestException(string message)
           : base(message)
        {

        }

    }
}
