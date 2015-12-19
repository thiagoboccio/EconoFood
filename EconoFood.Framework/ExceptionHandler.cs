﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconoFood.Framework
{
    [Serializable]
    public class ExceptionHandler : Exception
    {
        public string BusinessMessage { get; set; }
        public ExceptionHandler() { }
        public ExceptionHandler(string message) : base(message) { }
        public ExceptionHandler(string message, Exception inner) : base(message, inner) { }
        protected ExceptionHandler(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
