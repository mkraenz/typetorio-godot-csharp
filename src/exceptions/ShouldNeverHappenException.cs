using System;

namespace Exceptions
{
    public class ShouldNeverHappenException : Exception
    {
        public ShouldNeverHappenException(string message)
            : base(message) { }
    }

    public class CannotFindUnusedWordException : Exception
    {
        public CannotFindUnusedWordException()
            : base("Max recursion depth reached. Is your word pool too small?") { }
    }
}
