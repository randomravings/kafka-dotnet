namespace Kafka.Common.Records
{
    public enum TimestampType : short
    {
        None = -1,
        CreateTime = 0,
        LogAppendTime = 16,
    }
}
