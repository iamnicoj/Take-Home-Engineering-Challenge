using System;

namespace TripsAPI.Exceptions
{
    public class TripsQueryException : Exception
    {
        public TripsQueryException()
        {
        }

        public TripsQueryException(string message)
            : base(message)
        {
        }

        public TripsQueryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}