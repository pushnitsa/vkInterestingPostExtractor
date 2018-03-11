using System;
using VkInterestingPostExtractor.Exceptions;

namespace VkInterestingPostExtractor
{
    internal class DateTimeOffsetFetcher
    {
        private readonly int _daysToOffset; 
        
        public DateTimeOffsetFetcher(int offsetDays)
        {
            _daysToOffset = offsetDays;
        }

        public DateTime GetDateTime()
        {
            if (_daysToOffset == 0)
            {
                throw new DateTimeOffsetUndefinedException();
            }
            
            return DateTime.UtcNow.AddDays(- _daysToOffset);
        }
    }
}