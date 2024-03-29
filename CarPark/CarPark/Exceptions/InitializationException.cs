﻿using System;

namespace CarPark.Exceptions
{
    [Serializable]
    public class InitializationException : Exception
    {
        public InitializationException() { }
        public InitializationException(string message) : base(message) { }
        public InitializationException(string message, Exception inner) : base(message, inner) { }
        protected InitializationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
