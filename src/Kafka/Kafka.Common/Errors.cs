using Kafka.Common.Types;
using System.Collections.Immutable;

namespace Kafka.Common
{
    public static class Errors
    {
        private static readonly ImmutableSortedDictionary<short, Error> ERRORS = new[]{
            new Error(ErrorCode.UNKNOWN_SERVER_ERROR, false, "The server experienced an unexpected error when processing the request."),
            new Error(ErrorCode.NONE, false, ""),
            new Error(ErrorCode.OFFSET_OUT_OF_RANGE, false, "The requested offset is not within the range of offsets maintained by the server."),
            new Error(ErrorCode.CORRUPT_MESSAGE, true, "This message has failed its CRC checksum, exceeds the valid size, has a null key for a compacted topic, or is otherwise corrupt."),
            new Error(ErrorCode.UNKNOWN_TOPIC_OR_PARTITION, true, "This server does not host this topic-partition."),
            new Error(ErrorCode.INVALID_FETCH_SIZE, false, "The requested fetch size is invalid."),
            new Error(ErrorCode.LEADER_NOT_AVAILABLE, true, "There is no leader for this topic-partition as we are in the middle of a leadership election."),
            new Error(ErrorCode.NOT_LEADER_OR_FOLLOWER, true, "For requests intended only for the leader, this error indicates that the broker is not the current leader. For requests intended for any replica, this error indicates that the broker is not a replica of the topic partition."),
            new Error(ErrorCode.REQUEST_TIMED_OUT, true, "The request timed out."),
            new Error(ErrorCode.BROKER_NOT_AVAILABLE, false, "The broker is not available."),
            new Error(ErrorCode.REPLICA_NOT_AVAILABLE, true, "The replica is not available for the requested topic-partition. Produce/Fetch requests and other requests intended only for the leader or follower return NOT_LEADER_OR_FOLLOWER if the broker is not a replica of the topic-partition."),
            new Error(ErrorCode.MESSAGE_TOO_LARGE, false, "The request included a message larger than the max message size the server will accept."),
            new Error(ErrorCode.STALE_CONTROLLER_EPOCH, false, "The controller moved to another broker."),
            new Error(ErrorCode.OFFSET_METADATA_TOO_LARGE, false, "The metadata field of the offset request was too large."),
            new Error(ErrorCode.NETWORK_EXCEPTION, true, "The server disconnected before a response was received."),
            new Error(ErrorCode.COORDINATOR_LOAD_IN_PROGRESS, true, "The coordinator is loading and hence can't process requests."),
            new Error(ErrorCode.COORDINATOR_NOT_AVAILABLE, true, "The coordinator is not available."),
            new Error(ErrorCode.NOT_COORDINATOR, true, "This is not the correct coordinator."),
            new Error(ErrorCode.INVALID_TOPIC_EXCEPTION, false, "The request attempted to perform an operation on an invalid topic."),
            new Error(ErrorCode.RECORD_LIST_TOO_LARGE, false, "The request included message batch larger than the configured segment size on the server."),
            new Error(ErrorCode.NOT_ENOUGH_REPLICAS, true, "Messages are rejected since there are fewer in-sync replicas than required."),
            new Error(ErrorCode.NOT_ENOUGH_REPLICAS_AFTER_APPEND, true, "Messages are written to the log, but to fewer in-sync replicas than required."),
            new Error(ErrorCode.INVALID_REQUIRED_ACKS, false, "Produce request specified an invalid value for required acks."),
            new Error(ErrorCode.ILLEGAL_GENERATION, false, "Specified group generation id is not valid."),
            new Error(ErrorCode.INCONSISTENT_GROUP_PROTOCOL, false, "The group member's supported protocols are incompatible with those of existing members or first group member tried to join with empty protocol type or empty protocol list."),
            new Error(ErrorCode.INVALID_GROUP_ID, false, "The configured groupId is invalid."),
            new Error(ErrorCode.UNKNOWN_MEMBER_ID, false, "The coordinator is not aware of this member."),
            new Error(ErrorCode.INVALID_SESSION_TIMEOUT, false, "The session timeout is not within the range allowed by the broker (as configured by group.min.session.timeout.ms and group.max.session.timeout.ms)."),
            new Error(ErrorCode.REBALANCE_IN_PROGRESS, false, "The group is rebalancing, so a rejoin is needed."),
            new Error(ErrorCode.INVALID_COMMIT_OFFSET_SIZE, false, "The committing offset data size is not valid."),
            new Error(ErrorCode.TOPIC_AUTHORIZATION_FAILED, false, "Topic authorization failed."),
            new Error(ErrorCode.GROUP_AUTHORIZATION_FAILED, false, "Group authorization failed."),
            new Error(ErrorCode.CLUSTER_AUTHORIZATION_FAILED, false, "Cluster authorization failed."),
            new Error(ErrorCode.INVALID_TIMESTAMP, false, "The timestamp of the message is out of acceptable range."),
            new Error(ErrorCode.UNSUPPORTED_SASL_MECHANISM, false, "The broker does not support the requested SASL mechanism."),
            new Error(ErrorCode.ILLEGAL_SASL_STATE, false, "Request is not valid given the current SASL state."),
            new Error(ErrorCode.UNSUPPORTED_VERSION, false, "The version of API is not supported."),
            new Error(ErrorCode.TOPIC_ALREADY_EXISTS, false, "Topic with this name already exists."),
            new Error(ErrorCode.INVALID_PARTITIONS, false, "Number of partitions is below 1."),
            new Error(ErrorCode.INVALID_REPLICATION_FACTOR, false, "Replication factor is below 1 or larger than the number of available brokers."),
            new Error(ErrorCode.INVALID_REPLICA_ASSIGNMENT, false, "Replica assignment is invalid."),
            new Error(ErrorCode.INVALID_CONFIG, false, "Configuration is invalid."),
            new Error(ErrorCode.NOT_CONTROLLER, true, "This is not the correct controller for this cluster."),
            new Error(ErrorCode.INVALID_REQUEST, false, "This most likely occurs because of a request being malformed by the client library or the message was sent to an incompatible broker. See the broker logs for more details."),
            new Error(ErrorCode.UNSUPPORTED_FOR_MESSAGE_FORMAT, false, "The message format version on the broker does not support the request."),
            new Error(ErrorCode.POLICY_VIOLATION, false, "Request parameters do not satisfy the configured policy."),
            new Error(ErrorCode.OUT_OF_ORDER_SEQUENCE_NUMBER, false, "The broker received an out of order sequence number."),
            new Error(ErrorCode.DUPLICATE_SEQUENCE_NUMBER, false, "The broker received a duplicate sequence number."),
            new Error(ErrorCode.INVALID_PRODUCER_EPOCH, false, "Producer attempted to produce with an old epoch."),
            new Error(ErrorCode.INVALID_TXN_STATE, false, "The producer attempted a transactional operation in an invalid state."),
            new Error(ErrorCode.INVALID_PRODUCER_ID_MAPPING, false, "The producer attempted to use a producer id which is not currently assigned to its transactional id."),
            new Error(ErrorCode.INVALID_TRANSACTION_TIMEOUT, false, "The transaction timeout is larger than the maximum value allowed by the broker (as configured by transaction.max.timeout.ms)."),
            new Error(ErrorCode.CONCURRENT_TRANSACTIONS, false, "The producer attempted to update a transaction while another concurrent operation on the same transaction was ongoing."),
            new Error(ErrorCode.TRANSACTION_COORDINATOR_FENCED, false, "Indicates that the transaction coordinator sending a WriteTxnMarker is no longer the current coordinator for a given producer."),
            new Error(ErrorCode.TRANSACTIONAL_ID_AUTHORIZATION_FAILED, false, "Transactional Id authorization failed."),
            new Error(ErrorCode.SECURITY_DISABLED, false, "Security features are disabled."),
            new Error(ErrorCode.OPERATION_NOT_ATTEMPTED, false, "The broker did not attempt to execute this operation. This may happen for batched RPCs where some operations in the batch failed, causing the broker to respond without trying the rest."),
            new Error(ErrorCode.KAFKA_STORAGE_ERROR, true, "Disk error when trying to access log file on the disk."),
            new Error(ErrorCode.LOG_DIR_NOT_FOUND, false, "The user-specified log directory is not found in the broker config."),
            new Error(ErrorCode.SASL_AUTHENTICATION_FAILED, false, "SASL Authentication failed."),
            new Error(ErrorCode.UNKNOWN_PRODUCER_ID, false, "This exception is raised by the broker if it could not locate the producer metadata associated with the producerId in question. This could happen if, for instance, the producer's records were deleted because their retention time had elapsed. Once the last records of the producerId are removed, the producer's metadata is removed from the broker, and future appends by the producer will return this exception."),
            new Error(ErrorCode.REASSIGNMENT_IN_PROGRESS, false, "A partition reassignment is in progress."),
            new Error(ErrorCode.DELEGATION_TOKEN_AUTH_DISABLED, false, "Delegation Token feature is not enabled."),
            new Error(ErrorCode.DELEGATION_TOKEN_NOT_FOUND, false, "Delegation Token is not found on server."),
            new Error(ErrorCode.DELEGATION_TOKEN_OWNER_MISMATCH, false, "Specified Principal is not valid Owner/Renewer."),
            new Error(ErrorCode.DELEGATION_TOKEN_REQUEST_NOT_ALLOWED, false, "Delegation Token requests are not allowed on PLAINTEXT/1-way SSL channels and on delegation token authenticated channels."),
            new Error(ErrorCode.DELEGATION_TOKEN_AUTHORIZATION_FAILED, false, "Delegation Token authorization failed."),
            new Error(ErrorCode.DELEGATION_TOKEN_EXPIRED, false, "Delegation Token is expired."),
            new Error(ErrorCode.INVALID_PRINCIPAL_TYPE, false, "Supplied principalType is not supported."),
            new Error(ErrorCode.NON_EMPTY_GROUP, false, "The group is not empty."),
            new Error(ErrorCode.GROUP_ID_NOT_FOUND, false, "The group id does not exist."),
            new Error(ErrorCode.FETCH_SESSION_ID_NOT_FOUND, true, "The fetch session ID was not found."),
            new Error(ErrorCode.INVALID_FETCH_SESSION_EPOCH, true, "The fetch session epoch is invalid."),
            new Error(ErrorCode.LISTENER_NOT_FOUND, true, "There is no listener on the leader broker that matches the listener on which metadata request was processed."),
            new Error(ErrorCode.TOPIC_DELETION_DISABLED, false, "Topic deletion is disabled."),
            new Error(ErrorCode.FENCED_LEADER_EPOCH, true, "The leader epoch in the request is older than the epoch on the broker."),
            new Error(ErrorCode.UNKNOWN_LEADER_EPOCH, true, "The leader epoch in the request is newer than the epoch on the broker."),
            new Error(ErrorCode.UNSUPPORTED_COMPRESSION_TYPE, false, "The requesting client does not support the compression type of given partition."),
            new Error(ErrorCode.STALE_BROKER_EPOCH, false, "Broker epoch has changed."),
            new Error(ErrorCode.OFFSET_NOT_AVAILABLE, true, "The leader high watermark has not caught up from a recent leader election so the offsets cannot be guaranteed to be monotonically increasing."),
            new Error(ErrorCode.MEMBER_ID_REQUIRED, false, "The group member needs to have a valid member id before actually entering a consumer group."),
            new Error(ErrorCode.PREFERRED_LEADER_NOT_AVAILABLE, true, "The preferred leader was not available."),
            new Error(ErrorCode.GROUP_MAX_SIZE_REACHED, false, "The consumer group has reached its max size."),
            new Error(ErrorCode.FENCED_INSTANCE_ID, false, "The broker rejected this static consumer since another consumer with the same group.instance.id has registered with a different member.id."),
            new Error(ErrorCode.ELIGIBLE_LEADERS_NOT_AVAILABLE, true, "Eligible topic partition leaders are not available."),
            new Error(ErrorCode.ELECTION_NOT_NEEDED, true, "Leader election not needed for topic partition."),
            new Error(ErrorCode.NO_REASSIGNMENT_IN_PROGRESS, false, "No partition reassignment is in progress."),
            new Error(ErrorCode.GROUP_SUBSCRIBED_TO_TOPIC, false, "Deleting offsets of a topic is forbidden while the consumer group is actively subscribed to it."),
            new Error(ErrorCode.INVALID_RECORD, false, "This record has failed the validation on broker and hence will be rejected."),
            new Error(ErrorCode.UNSTABLE_OFFSET_COMMIT, true, "There are unstable offsets that need to be cleared."),
            new Error(ErrorCode.THROTTLING_QUOTA_EXCEEDED, true, "The throttling quota has been exceeded."),
            new Error(ErrorCode.PRODUCER_FENCED, false, "There is a newer producer with the same transactionalId which fences the current one."),
            new Error(ErrorCode.RESOURCE_NOT_FOUND, false, "A request illegally referred to a resource that does not exist."),
            new Error(ErrorCode.DUPLICATE_RESOURCE, false, "A request illegally referred to the same resource twice."),
            new Error(ErrorCode.UNACCEPTABLE_CREDENTIAL, false, "Requested credential would not meet criteria for acceptability."),
            new Error(ErrorCode.INCONSISTENT_VOTER_SET, false, "Indicates that the either the sender or recipient of a voter-only request is not one of the expected voters"),
            new Error(ErrorCode.INVALID_UPDATE_VERSION, false, "The given update version was invalid."),
            new Error(ErrorCode.FEATURE_UPDATE_FAILED, false, "Unable to update finalized features due to an unexpected server error."),
            new Error(ErrorCode.PRINCIPAL_DESERIALIZATION_FAILURE, false, "Request principal deserialization failed during forwarding. This indicates an internal error on the broker cluster security setup."),
            new Error(ErrorCode.SNAPSHOT_NOT_FOUND, false, "Requested snapshot was not found"),
            new Error(ErrorCode.POSITION_OUT_OF_RANGE, false, "Requested position is not greater than or equal to zero, and less than the size of the snapshot."),
            new Error(ErrorCode.UNKNOWN_TOPIC_ID, true, "This server does not host this topic ID."),
            new Error(ErrorCode.DUPLICATE_BROKER_REGISTRATION, false, "This broker ID is already in use."),
            new Error(ErrorCode.BROKER_ID_NOT_REGISTERED, false, "The given broker ID was not registered."),
            new Error(ErrorCode.INCONSISTENT_TOPIC_ID, true, "The log's topic ID did not match the topic ID in the request"),
            new Error(ErrorCode.INCONSISTENT_CLUSTER_ID, false, "The clusterId in the request does not match that found on the server"),
            new Error(ErrorCode.TRANSACTIONAL_ID_NOT_FOUND, false, "The transactionalId could not be found"),
            new Error(ErrorCode.FETCH_SESSION_TOPIC_ID_ERROR, true, "The fetch session encountered inconsistent topic ID usage"),
            new Error(ErrorCode.INELIGIBLE_REPLICA, false, "The new ISR contains at least one ineligible replica."),
            new Error(ErrorCode.NEW_LEADER_ELECTED, false, "The AlterPartition request successfully updated the partition state but the leader has changed.")
        }.ToImmutableSortedDictionary(
            k => (short)k.ErrorCode,
            v => v
        );

        /// <summary>
        /// Returns a known <see cref="Error"/> instance.
        /// If the code is now known by the client, then it is translated into <see cref="ErrorCode.UNKNOWN_ERROR_CODE"/> with the translated code in the message.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static Error Translate(short errorCode)
        {
            if (ERRORS.TryGetValue(errorCode, out var error))
                return error;
            else
                return new Error(ErrorCode.UNKNOWN_ERROR_CODE, false, $"Unknown error code from server ({errorCode}).");
        }

        /// <summary>
        /// Returns an <see cref="Error"/> instance for the error code.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <exception cref="KeyNotFoundException">If the error code is not found.</exception>
        /// <returns></returns>
        public static Error Translate(ErrorCode errorCode) =>
            ERRORS[(short)errorCode]
        ;
    }
}
