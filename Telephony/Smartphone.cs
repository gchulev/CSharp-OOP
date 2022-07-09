using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string BrowseURL(string url)
        {
            return $"Browsing: {url}!";
        }

        public string CallNumber(string number)
        {
            return $"Calling... {number}";
        }
    }
}
