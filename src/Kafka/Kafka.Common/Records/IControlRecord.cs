using Kafka.Common.Model;

namespace Kafka.Common.Records
{
    /// <summary>
    /// version: int16 (current version is 0)
    /// type: int16(0 indicates an abort marker, 1 indicates a commit)
    /// </summary>
    public interface IControlRecord :
        IRecord
    {
        short Version { get; }
        ControlType Type { get; }
    }
}
