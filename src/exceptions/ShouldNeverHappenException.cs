using System;

namespace Exceptions
{

    public class ShouldNeverHappenException : Exception
    {
        public ShouldNeverHappenException(string message)
            : base(message)
        {
        }

    }
}