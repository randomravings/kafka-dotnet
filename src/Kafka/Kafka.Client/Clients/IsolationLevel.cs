using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Client
{
    public enum IsolationLevel : sbyte
    {
        [EnumMember(Value = "read_uncommitted")]
        ReadUncommitted = 0,
        [EnumMember(Value = "read_committed")]
        ReadCommitted = 1,
    }
}
