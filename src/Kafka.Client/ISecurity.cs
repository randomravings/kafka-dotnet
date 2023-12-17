using Kafka.Client.Model;

namespace Kafka.Client
{
    public interface ISecurity
    {
        /// <summary>
        /// Gets a list of acls.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<AclResource>> DescribeAcls(
            DescribeAclOptions options,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Creates new acls.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<CreateAclResult>> CreateAcls(
            CreateAclOptions options,
            CancellationToken cancellationToken
        );

        /// <summary>
        /// Deletes existing acls.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ValueTask<IReadOnlyList<DeleteAclResult>> DeleteAcls(
            DeleteAclOptions options,
            CancellationToken cancellationToken
        );
    }
}
