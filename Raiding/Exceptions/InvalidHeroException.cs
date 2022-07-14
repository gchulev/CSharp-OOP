using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Exceptions
{
    public class InvalidHeroException : Exception
    {
        public InvalidHeroException(string message) : base(message)
        {
            
        }
    }
}
