using System;

namespace CarPark.Exceptions
{
    [Serializable]
    public class UpdateAutoException  : Exception
    {
        public UpdateAutoException () { }
        public UpdateAutoException (string message) : base(message) { }
        public UpdateAutoException (string message, Exception inner) : base(message, inner) { }
        protected UpdateAutoException (
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
