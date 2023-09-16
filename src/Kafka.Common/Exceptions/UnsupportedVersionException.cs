using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Common.Exceptions
{
    public class UnsupportedVersionException :
        Exception
    {
        public UnsupportedVersionException()
        {
        }

        public UnsupportedVersionException(string? message) : base(message)
        {
        }

        public UnsupportedVersionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnsupportedVersionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
