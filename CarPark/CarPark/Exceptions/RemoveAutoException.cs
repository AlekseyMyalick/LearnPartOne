using System;

namespace CarPark.Exceptions
{
    [Serializable]
    public class RemoveAutoExceptionException : Exception
    {
        public RemoveAutoExceptionException() { }
        public RemoveAutoExceptionException(string message) : base(message) { }
        public RemoveAutoExceptionException(string message, Exception inner) : base(message, inner) { }
        protected RemoveAutoExceptionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
