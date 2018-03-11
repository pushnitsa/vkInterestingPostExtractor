using System;

namespace VkInterestingPostExtractor.Exceptions
{
    internal class DateTimeNullException : Exception
    {
        public DateTimeNullException()
            : base()
        {
            
        }
        
        public DateTimeNullException(string message)
            : base(message)
        {
            
        }
    }
}