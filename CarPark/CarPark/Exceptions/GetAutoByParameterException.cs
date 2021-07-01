using System;

namespace CarPark.Exceptions
{
    [Serializable]
    public class GetAutoByParameterException  : Exception
    {
        public GetAutoByParameterException () { }
        public GetAutoByParameterException (string message) : base(message) { }
        public GetAutoByParameterException (string message, Exception inner) : base(message, inner) { }
        protected GetAutoByParameterException (
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
