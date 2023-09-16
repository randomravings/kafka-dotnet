namespace Kafka.Common.Model
{
    public enum TimestampType : short
    {
        None = -1,
        CreateTime = 0,
        LogAppendTime = 16,
    }
}
