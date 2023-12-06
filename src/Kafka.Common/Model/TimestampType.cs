namespace Kafka.Common.Model
{
    public enum TimestampType : int
    {
        None = -1,
        CreateTime = 0,
        LogAppendTime = 16,
    }
}
