using Kafka.Common.Model;
using Kafka.Common.Model.Extensions;

namespace Kafka.Common.Protocol
{
    public abstract class MessageCodec :
        IMessageCodec
    {
        protected MessageCodec(
            ApiKey apiKey,
            VersionRange versions,
            VersionRange flexibleVersions
        )
        {
            ApiKey = apiKey;
            Versions = versions;
            FlexibleVersions = flexibleVersions;
            ApiVersion = Versions.Constrain(0);
            Flexible = FlexibleVersions.Includes(ApiVersion);
        }

        public ApiKey ApiKey { get; private set; }

        public VersionRange Versions { get; private set; }
        public VersionRange FlexibleVersions { get; private set; }
        public ApiVersion ApiVersion { get; private set; }
        public bool Flexible { get; private set; }

        public void SetApiVersion(ApiVersion apiVersion)
        {
            ApiVersion = Versions.Constrain(apiVersion);
            Flexible = FlexibleVersions.Includes(apiVersion);
            NewApiVersion(ApiVersion);
        }

        protected abstract void NewApiVersion(short apiVersion);
    }
}
