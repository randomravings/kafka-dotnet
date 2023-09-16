using Kafka.Common.Model;

namespace Kafka.Common.Protocol
{
    public interface IMessageCodec
    {
        ApiKey ApiKey { get; }
        VersionRange Versions { get; }
        VersionRange FlexibleVersions { get; }
        ApiVersion ApiVersion { get; }
        bool Flexible { get; }
        void SetApiVersion(ApiVersion apiVersion);
    }
}
