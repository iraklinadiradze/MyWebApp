using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Application.Common.Exceptions
{
    class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args):
            base(getLocalizedMessage(CultureInfo.CurrentCulture, message, args))
        {
//            String.Format()
        }

        private static string getLocalizedMessage(CultureInfo cultureInfo, string message, object[] args)
        {
            return "";
        }

    }
}
