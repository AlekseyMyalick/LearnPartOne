using System;

namespace CarPark.Exceptions
{
    [Serializable]
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException() { }
        public RemoveAutoException(string message) : base(message) { }
        public RemoveAutoException(string message, Exception inner) : base(message, inner) { }
        protected RemoveAutoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
