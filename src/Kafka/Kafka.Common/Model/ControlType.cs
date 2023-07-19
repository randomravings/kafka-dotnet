using System.ComponentModel;

namespace Kafka.Common.Model
{
    [DefaultValue(None)]
    public enum ControlType : short
    {
        None = -1,
        Abort = 0,
        Commit = 1
    }
}
