namespace Kafka.Client.Clients
{
    /// <summary>
    /// Base client call parameters.
    /// </summary>
    /// <param name="TimeoutMs">Request time out in milliseconds.</param>
    /// <param name="Version">Api version to use.</param>
    /// <param name="ClientId">Client Id to associate to the request.</param>
    public abstract record ClientOptions(
        int TimeoutMs,
        short? Version,
        string ClientId
    );
}
