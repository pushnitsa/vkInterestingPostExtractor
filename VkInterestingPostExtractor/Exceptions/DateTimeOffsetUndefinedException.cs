using System;

namespace VkInterestingPostExtractor.Exceptions
{
    public class DateTimeOffsetUndefinedException : Exception
    {
        public DateTimeOffsetUndefinedException()
            : base()
        {
            
        }

        public DateTimeOffsetUndefinedException(string message)
            : base(message)
        {
            
        }
    }
}