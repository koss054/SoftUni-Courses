using System;
using System.Collections.Generic;
using System.Linq;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class Smarthphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(c => Char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.UrlMessage);
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {

            if (!number.All(c => Char.IsDigit(c)))
            {
                throw new ArgumentException(ExceptionMessages.NumberMessage);
            }

            return number.Length > 7 ? $"Calling... {number}" :
                $"Dialing... {number}";
        }
    }
}
