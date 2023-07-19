using Kafka.Client.Model;

namespace Kafka.Client.Clients.Admin
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
        TOptions Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOptinsBuilder"></typeparam>
    /// <typeparam name="TOptions"></typeparam>
    public abstract class AdminClientOptionsBuilder<TOptinsBuilder, TOptions> :
        IAdminOptionsBuilder<TOptinsBuilder, TOptions>
        where TOptinsBuilder : notnull, AdminClientOptionsBuilder<TOptinsBuilder, TOptions>
        where TOptions : notnull, ClientOptions
    {
        private AdminClientConfig _adminClientConfig = new();
        private int _timeoutMs;
        private short _version = -1;
        private string _clientId = "";
        protected AdminClientOptionsBuilder(AdminClientConfig adminClientConfig)
        {
            _adminClientConfig = adminClientConfig;
            _timeoutMs = _adminClientConfig.RequestTimeoutMs;
        }

        protected AdminClientConfig AdminClientConfig => _adminClientConfig;
        protected int TimeoutMs => _timeoutMs;
        protected short Version => _version;
        protected string ClientId => _clientId;

        /// <inheritdoc/>
        public TOptinsBuilder Timeout(int timeoutMs)
        {
            _timeoutMs = timeoutMs;
            return (TOptinsBuilder)this;
        }

        /// <inheritdoc/>
        public abstract TOptions Build();
    }
}
