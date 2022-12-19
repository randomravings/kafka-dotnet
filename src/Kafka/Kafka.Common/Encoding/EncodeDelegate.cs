namespace Kafka.Common.Encoding
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public delegate int EncodeDelegate<TItem>(
        byte[] buffer,
        int offset,
        TItem item
    );
}
