using System.ComponentModel;

namespace Kafka.Common.Records
{
    [DefaultValue(None)]
    public enum ControlType : short
    {
        None = -1,
        Abort = 0,
        Commit = 1
    }
}
