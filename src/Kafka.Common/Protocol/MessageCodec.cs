using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;

namespace Kafka.Common.Protocol
{
    public abstract class MessageCodec :
        IMessageCodec
    {
        protected readonly ApiKey _apiKey;
        protected readonly VersionRange _versions;
        protected readonly VersionRange _flexibleVersions;
        protected ApiVersion _apiVersion;
        protected bool _flexible;

        public MessageCodec(
            ApiKey apiKey,
            VersionRange versions,
            VersionRange flexibleVersions
        )
        {
            _apiKey = apiKey;
            _versions = versions;
            _flexibleVersions = flexibleVersions;
            _apiVersion = _versions.Constrain(0);
            _flexible = _flexibleVersions.Includes(_apiVersion);
        }

        ApiKey IMessageCodec.ApiKey => _apiKey;
        VersionRange IMessageCodec.Versions => _versions;
        VersionRange IMessageCodec.FlexibleVersions => _flexibleVersions;
        ApiVersion IMessageCodec.ApiVersion => _apiVersion;
        bool IMessageCodec.Flexible => _flexible;

        void IMessageCodec.SetApiVersion(ApiVersion apiVersion)
        {
            apiVersion = _versions.Constrain(apiVersion);
            _apiVersion = apiVersion;
            _flexible = _flexibleVersions.Includes(_apiVersion);
            SetApiVersion(_apiVersion);
        }

        protected abstract void SetApiVersion(short apiVersion);
    }
}
