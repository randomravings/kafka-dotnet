using System.ComponentModel;

namespace Kafka.Common.Model
{
    [DefaultValue(None)]
    public enum ControlType : int
    {
        None = -1,
        Abort = 0,
        Commit = 1
    }
}
