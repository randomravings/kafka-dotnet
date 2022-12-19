using Kafka.Client.Clients.Admin;

namespace Kafka.Client.Clients
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOptinsBuilder"></typeparam>
    /// <typeparam name="TOptions"></typeparam>
    public interface IAdminOptionsBuilder<TOptinsBuilder, TOptions>
        where TOptinsBuilder : notnull, IAdminOptionsBuilder<TOptinsBuilder, TOptions>
        where TOptions : notnull, ClientOptions
    {
        /// <summary>
        /// Sets the request timeout for the request.
        /// If not set the value will be taken from 'default.api.timeout.ms' in client config.
        /// </summary>
        /// <param name="timeoutMs">Request timeout in milliseconds.</param>
        /// <returns>Instance of <typeparamref name="TOptinsBuilder"/></returns>
        TOptinsBuilder Timeout(int timeoutMs);
        /// <summary>
        /// Sets the version to be used for the underlying Api call.
        /// The valid range depends on the union set of client and version.
        /// If the range is outside said range an exception will be thrown by the client.
        /// If not set, the version selection is deferred to the client.
        /// </summary>
        /// <param name="version">Desired version to be used. -1 defaults to latest supported version.</param>
        /// <returns>Instance of <typeparamref name="TOptinsBuilder"/></returns>
        TOptinsBuilder Version(short version);
        /// <summary>
        /// Sets the client id for the request.
        /// If not set the value will be taken from 'client.id' in client config.
        /// </summary>
        /// <param name="version">Desired version to be used.</param>
        /// <returns>Instance of <typeparamref name="TOptinsBuilder"/></returns>
        TOptinsBuilder ClientId(string clientId);
        /// <summary>
        /// Builds the options instance to pass to client.
        /// </summary>
        /// <returns>Instance of <typeparamref name="TOptions"/></returns>
        TOptions Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOptinsBuilder"></typeparam>
    /// <typeparam name="TOptions"></typeparam>
    public abstract class ClientOptionsBuilder<TOptinsBuilder, TOptions> :
        IAdminOptionsBuilder<TOptinsBuilder, TOptions>
        where TOptinsBuilder : notnull, ClientOptionsBuilder<TOptinsBuilder, TOptions>
        where TOptions : notnull, ClientOptions
    {
        protected readonly AdminClientConfig _adminClientConfig;
        protected int _timeoutMs = 0;
        protected short _version = -1;
        protected string _clientId = "";
        protected ClientOptionsBuilder(AdminClientConfig adminClientConfig)
        {
            _adminClientConfig = adminClientConfig;
            _timeoutMs = _adminClientConfig.RequestTimeoutMs;
            _clientId = adminClientConfig.ClientId;
        }

        /// <inheritdoc/>
        public TOptinsBuilder Timeout(int timeoutMs)
        {
            _timeoutMs = timeoutMs;
            return (TOptinsBuilder)this;
        }

        /// <inheritdoc/>
        public TOptinsBuilder Version(short version)
        {
            _version = version;
            return (TOptinsBuilder)this;
        }

        /// <inheritdoc/>
        public TOptinsBuilder ClientId(string clientId)
        {
            _clientId = clientId;
            return (TOptinsBuilder)this;
        }

        /// <inheritdoc/>
        public abstract TOptions Build();
    }
}
