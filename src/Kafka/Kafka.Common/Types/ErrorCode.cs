namespace Kafka.Common.Types
{
    ///<summary>
    /// We use numeric codes to indicate what problem occurred on the server. These can be translated by the client into exceptions or whatever the appropriate error handling mechanism in the client language. Here is a table of the error codes currently in use:
    ///<summary>
    public enum ErrorCode
    {
        ///<summary>
        /// The server experienced an unexpected error when processing the request.
        /// <para>Retriable: False</para>
        ///</summary>
        UNKNOWN_SERVER_ERROR = -1,
        ///<summary>
        /// 
        /// <para>Retriable: False</para>
        ///</summary>
        NONE = 0,
        ///<summary>
        /// The requested offset is not within the range of offsets maintained by the server.
        /// <para>Retriable: False</para>
        ///</summary>
        OFFSET_OUT_OF_RANGE = 1,
        ///<summary>
        /// This message has failed its CRC checksum, exceeds the valid size, has a null key for a compacted topic, or is otherwise corrupt.
        /// <para>Retriable: True</para>
        ///</summary>
        CORRUPT_MESSAGE = 2,
        ///<summary>
        /// This server does not host this topic-partition.
        /// <para>Retriable: True</para>
        ///</summary>
        UNKNOWN_TOPIC_OR_PARTITION = 3,
        ///<summary>
        /// The requested fetch size is invalid.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_FETCH_SIZE = 4,
        ///<summary>
        /// There is no leader for this topic-partition as we are in the middle of a leadership election.
        /// <para>Retriable: True</para>
        ///</summary>
        LEADER_NOT_AVAILABLE = 5,
        ///<summary>
        /// For requests intended only for the leader, this error indicates that the broker is not the current leader. For requests intended for any replica, this error indicates that the broker is not a replica of the topic partition.
        /// <para>Retriable: True</para>
        ///</summary>
        NOT_LEADER_OR_FOLLOWER = 6,
        ///<summary>
        /// The request timed out.
        /// <para>Retriable: True</para>
        ///</summary>
        REQUEST_TIMED_OUT = 7,
        ///<summary>
        /// The broker is not available.
        /// <para>Retriable: False</para>
        ///</summary>
        BROKER_NOT_AVAILABLE = 8,
        ///<summary>
        /// The replica is not available for the requested topic-partition. Produce/Fetch requests and other requests intended only for the leader or follower return NOT_LEADER_OR_FOLLOWER if the broker is not a replica of the topic-partition.
        /// <para>Retriable: True</para>
        ///</summary>
        REPLICA_NOT_AVAILABLE = 9,
        ///<summary>
        /// The request included a message larger than the max message size the server will accept.
        /// <para>Retriable: False</para>
        ///</summary>
        MESSAGE_TOO_LARGE = 10,
        ///<summary>
        /// The controller moved to another broker.
        /// <para>Retriable: False</para>
        ///</summary>
        STALE_CONTROLLER_EPOCH = 11,
        ///<summary>
        /// The metadata field of the offset request was too large.
        /// <para>Retriable: False</para>
        ///</summary>
        OFFSET_METADATA_TOO_LARGE = 12,
        ///<summary>
        /// The server disconnected before a response was received.
        /// <para>Retriable: True</para>
        ///</summary>
        NETWORK_EXCEPTION = 13,
        ///<summary>
        /// The coordinator is loading and hence can't process requests.
        /// <para>Retriable: True</para>
        ///</summary>
        COORDINATOR_LOAD_IN_PROGRESS = 14,
        ///<summary>
        /// The coordinator is not available.
        /// <para>Retriable: True</para>
        ///</summary>
        COORDINATOR_NOT_AVAILABLE = 15,
        ///<summary>
        /// This is not the correct coordinator.
        /// <para>Retriable: True</para>
        ///</summary>
        NOT_COORDINATOR = 16,
        ///<summary>
        /// The request attempted to perform an operation on an invalid topic.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_TOPIC_EXCEPTION = 17,
        ///<summary>
        /// The request included message batch larger than the configured segment size on the server.
        /// <para>Retriable: False</para>
        ///</summary>
        RECORD_LIST_TOO_LARGE = 18,
        ///<summary>
        /// Messages are rejected since there are fewer in-sync replicas than required.
        /// <para>Retriable: True</para>
        ///</summary>
        NOT_ENOUGH_REPLICAS = 19,
        ///<summary>
        /// Messages are written to the log, but to fewer in-sync replicas than required.
        /// <para>Retriable: True</para>
        ///</summary>
        NOT_ENOUGH_REPLICAS_AFTER_APPEND = 20,
        ///<summary>
        /// Produce request specified an invalid value for required acks.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_REQUIRED_ACKS = 21,
        ///<summary>
        /// Specified group generation id is not valid.
        /// <para>Retriable: False</para>
        ///</summary>
        ILLEGAL_GENERATION = 22,
        ///<summary>
        /// The group member's supported protocols are incompatible with those of existing members or first group member tried to join with empty protocol type or empty protocol list.
        /// <para>Retriable: False</para>
        ///</summary>
        INCONSISTENT_GROUP_PROTOCOL = 23,
        ///<summary>
        /// The configured groupId is invalid.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_GROUP_ID = 24,
        ///<summary>
        /// The coordinator is not aware of this member.
        /// <para>Retriable: False</para>
        ///</summary>
        UNKNOWN_MEMBER_ID = 25,
        ///<summary>
        /// The session timeout is not within the range allowed by the broker (as configured by group.min.session.timeout.ms and group.max.session.timeout.ms).
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_SESSION_TIMEOUT = 26,
        ///<summary>
        /// The group is rebalancing, so a rejoin is needed.
        /// <para>Retriable: False</para>
        ///</summary>
        REBALANCE_IN_PROGRESS = 27,
        ///<summary>
        /// The committing offset data size is not valid.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_COMMIT_OFFSET_SIZE = 28,
        ///<summary>
        /// Topic authorization failed.
        /// <para>Retriable: False</para>
        ///</summary>
        TOPIC_AUTHORIZATION_FAILED = 29,
        ///<summary>
        /// Group authorization failed.
        /// <para>Retriable: False</para>
        ///</summary>
        GROUP_AUTHORIZATION_FAILED = 30,
        ///<summary>
        /// Cluster authorization failed.
        /// <para>Retriable: False</para>
        ///</summary>
        CLUSTER_AUTHORIZATION_FAILED = 31,
        ///<summary>
        /// The timestamp of the message is out of acceptable range.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_TIMESTAMP = 32,
        ///<summary>
        /// The broker does not support the requested SASL mechanism.
        /// <para>Retriable: False</para>
        ///</summary>
        UNSUPPORTED_SASL_MECHANISM = 33,
        ///<summary>
        /// Request is not valid given the current SASL state.
        /// <para>Retriable: False</para>
        ///</summary>
        ILLEGAL_SASL_STATE = 34,
        ///<summary>
        /// The version of API is not supported.
        /// <para>Retriable: False</para>
        ///</summary>
        UNSUPPORTED_VERSION = 35,
        ///<summary>
        /// Topic with this name already exists.
        /// <para>Retriable: False</para>
        ///</summary>
        TOPIC_ALREADY_EXISTS = 36,
        ///<summary>
        /// Number of partitions is below 1.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_PARTITIONS = 37,
        ///<summary>
        /// Replication factor is below 1 or larger than the number of available brokers.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_REPLICATION_FACTOR = 38,
        ///<summary>
        /// Replica assignment is invalid.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_REPLICA_ASSIGNMENT = 39,
        ///<summary>
        /// Configuration is invalid.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_CONFIG = 40,
        ///<summary>
        /// This is not the correct controller for this cluster.
        /// <para>Retriable: True</para>
        ///</summary>
        NOT_CONTROLLER = 41,
        ///<summary>
        /// This most likely occurs because of a request being malformed by the client library or the message was sent to an incompatible broker. See the broker logs for more details.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_REQUEST = 42,
        ///<summary>
        /// The message format version on the broker does not support the request.
        /// <para>Retriable: False</para>
        ///</summary>
        UNSUPPORTED_FOR_MESSAGE_FORMAT = 43,
        ///<summary>
        /// Request parameters do not satisfy the configured policy.
        /// <para>Retriable: False</para>
        ///</summary>
        POLICY_VIOLATION = 44,
        ///<summary>
        /// The broker received an out of order sequence number.
        /// <para>Retriable: False</para>
        ///</summary>
        OUT_OF_ORDER_SEQUENCE_NUMBER = 45,
        ///<summary>
        /// The broker received a duplicate sequence number.
        /// <para>Retriable: False</para>
        ///</summary>
        DUPLICATE_SEQUENCE_NUMBER = 46,
        ///<summary>
        /// Producer attempted to produce with an old epoch.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_PRODUCER_EPOCH = 47,
        ///<summary>
        /// The producer attempted a transactional operation in an invalid state.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_TXN_STATE = 48,
        ///<summary>
        /// The producer attempted to use a producer id which is not currently assigned to its transactional id.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_PRODUCER_ID_MAPPING = 49,
        ///<summary>
        /// The transaction timeout is larger than the maximum value allowed by the broker (as configured by transaction.max.timeout.ms).
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_TRANSACTION_TIMEOUT = 50,
        ///<summary>
        /// The producer attempted to update a transaction while another concurrent operation on the same transaction was ongoing.
        /// <para>Retriable: False</para>
        ///</summary>
        CONCURRENT_TRANSACTIONS = 51,
        ///<summary>
        /// Indicates that the transaction coordinator sending a WriteTxnMarker is no longer the current coordinator for a given producer.
        /// <para>Retriable: False</para>
        ///</summary>
        TRANSACTION_COORDINATOR_FENCED = 52,
        ///<summary>
        /// Transactional Id authorization failed.
        /// <para>Retriable: False</para>
        ///</summary>
        TRANSACTIONAL_ID_AUTHORIZATION_FAILED = 53,
        ///<summary>
        /// Security features are disabled.
        /// <para>Retriable: False</para>
        ///</summary>
        SECURITY_DISABLED = 54,
        ///<summary>
        /// The broker did not attempt to execute this operation. This may happen for batched RPCs where some operations in the batch failed, causing the broker to respond without trying the rest.
        /// <para>Retriable: False</para>
        ///</summary>
        OPERATION_NOT_ATTEMPTED = 55,
        ///<summary>
        /// Disk error when trying to access log file on the disk.
        /// <para>Retriable: True</para>
        ///</summary>
        KAFKA_STORAGE_ERROR = 56,
        ///<summary>
        /// The user-specified log directory is not found in the broker config.
        /// <para>Retriable: False</para>
        ///</summary>
        LOG_DIR_NOT_FOUND = 57,
        ///<summary>
        /// SASL Authentication failed.
        /// <para>Retriable: False</para>
        ///</summary>
        SASL_AUTHENTICATION_FAILED = 58,
        ///<summary>
        /// This exception is raised by the broker if it could not locate the producer metadata associated with the producerId in question. This could happen if, for instance, the producer's records were deleted because their retention time had elapsed. Once the last records of the producerId are removed, the producer's metadata is removed from the broker, and future appends by the producer will return this exception.
        /// <para>Retriable: False</para>
        ///</summary>
        UNKNOWN_PRODUCER_ID = 59,
        ///<summary>
        /// A partition reassignment is in progress.
        /// <para>Retriable: False</para>
        ///</summary>
        REASSIGNMENT_IN_PROGRESS = 60,
        ///<summary>
        /// Delegation Token feature is not enabled.
        /// <para>Retriable: False</para>
        ///</summary>
        DELEGATION_TOKEN_AUTH_DISABLED = 61,
        ///<summary>
        /// Delegation Token is not found on server.
        /// <para>Retriable: False</para>
        ///</summary>
        DELEGATION_TOKEN_NOT_FOUND = 62,
        ///<summary>
        /// Specified Principal is not valid Owner/Renewer.
        /// <para>Retriable: False</para>
        ///</summary>
        DELEGATION_TOKEN_OWNER_MISMATCH = 63,
        ///<summary>
        /// Delegation Token requests are not allowed on PLAINTEXT/1-way SSL channels and on delegation token authenticated channels.
        /// <para>Retriable: False</para>
        ///</summary>
        DELEGATION_TOKEN_REQUEST_NOT_ALLOWED = 64,
        ///<summary>
        /// Delegation Token authorization failed.
        /// <para>Retriable: False</para>
        ///</summary>
        DELEGATION_TOKEN_AUTHORIZATION_FAILED = 65,
        ///<summary>
        /// Delegation Token is expired.
        /// <para>Retriable: False</para>
        ///</summary>
        DELEGATION_TOKEN_EXPIRED = 66,
        ///<summary>
        /// Supplied principalType is not supported.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_PRINCIPAL_TYPE = 67,
        ///<summary>
        /// The group is not empty.
        /// <para>Retriable: False</para>
        ///</summary>
        NON_EMPTY_GROUP = 68,
        ///<summary>
        /// The group id does not exist.
        /// <para>Retriable: False</para>
        ///</summary>
        GROUP_ID_NOT_FOUND = 69,
        ///<summary>
        /// The fetch session ID was not found.
        /// <para>Retriable: True</para>
        ///</summary>
        FETCH_SESSION_ID_NOT_FOUND = 70,
        ///<summary>
        /// The fetch session epoch is invalid.
        /// <para>Retriable: True</para>
        ///</summary>
        INVALID_FETCH_SESSION_EPOCH = 71,
        ///<summary>
        /// There is no listener on the leader broker that matches the listener on which metadata request was processed.
        /// <para>Retriable: True</para>
        ///</summary>
        LISTENER_NOT_FOUND = 72,
        ///<summary>
        /// Topic deletion is disabled.
        /// <para>Retriable: False</para>
        ///</summary>
        TOPIC_DELETION_DISABLED = 73,
        ///<summary>
        /// The leader epoch in the request is older than the epoch on the broker.
        /// <para>Retriable: True</para>
        ///</summary>
        FENCED_LEADER_EPOCH = 74,
        ///<summary>
        /// The leader epoch in the request is newer than the epoch on the broker.
        /// <para>Retriable: True</para>
        ///</summary>
        UNKNOWN_LEADER_EPOCH = 75,
        ///<summary>
        /// The requesting client does not support the compression type of given partition.
        /// <para>Retriable: False</para>
        ///</summary>
        UNSUPPORTED_COMPRESSION_TYPE = 76,
        ///<summary>
        /// Broker epoch has changed.
        /// <para>Retriable: False</para>
        ///</summary>
        STALE_BROKER_EPOCH = 77,
        ///<summary>
        /// The leader high watermark has not caught up from a recent leader election so the offsets cannot be guaranteed to be monotonically increasing.
        /// <para>Retriable: True</para>
        ///</summary>
        OFFSET_NOT_AVAILABLE = 78,
        ///<summary>
        /// The group member needs to have a valid member id before actually entering a consumer group.
        /// <para>Retriable: False</para>
        ///</summary>
        MEMBER_ID_REQUIRED = 79,
        ///<summary>
        /// The preferred leader was not available.
        /// <para>Retriable: True</para>
        ///</summary>
        PREFERRED_LEADER_NOT_AVAILABLE = 80,
        ///<summary>
        /// The consumer group has reached its max size.
        /// <para>Retriable: False</para>
        ///</summary>
        GROUP_MAX_SIZE_REACHED = 81,
        ///<summary>
        /// The broker rejected this static consumer since another consumer with the same group.instance.id has registered with a different member.id.
        /// <para>Retriable: False</para>
        ///</summary>
        FENCED_INSTANCE_ID = 82,
        ///<summary>
        /// Eligible topic partition leaders are not available.
        /// <para>Retriable: True</para>
        ///</summary>
        ELIGIBLE_LEADERS_NOT_AVAILABLE = 83,
        ///<summary>
        /// Leader election not needed for topic partition.
        /// <para>Retriable: True</para>
        ///</summary>
        ELECTION_NOT_NEEDED = 84,
        ///<summary>
        /// No partition reassignment is in progress.
        /// <para>Retriable: False</para>
        ///</summary>
        NO_REASSIGNMENT_IN_PROGRESS = 85,
        ///<summary>
        /// Deleting offsets of a topic is forbidden while the consumer group is actively subscribed to it.
        /// <para>Retriable: False</para>
        ///</summary>
        GROUP_SUBSCRIBED_TO_TOPIC = 86,
        ///<summary>
        /// This record has failed the validation on broker and hence will be rejected.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_RECORD = 87,
        ///<summary>
        /// There are unstable offsets that need to be cleared.
        /// <para>Retriable: True</para>
        ///</summary>
        UNSTABLE_OFFSET_COMMIT = 88,
        ///<summary>
        /// The throttling quota has been exceeded.
        /// <para>Retriable: True</para>
        ///</summary>
        THROTTLING_QUOTA_EXCEEDED = 89,
        ///<summary>
        /// There is a newer producer with the same transactionalId which fences the current one.
        /// <para>Retriable: False</para>
        ///</summary>
        PRODUCER_FENCED = 90,
        ///<summary>
        /// A request illegally referred to a resource that does not exist.
        /// <para>Retriable: False</para>
        ///</summary>
        RESOURCE_NOT_FOUND = 91,
        ///<summary>
        /// A request illegally referred to the same resource twice.
        /// <para>Retriable: False</para>
        ///</summary>
        DUPLICATE_RESOURCE = 92,
        ///<summary>
        /// Requested credential would not meet criteria for acceptability.
        /// <para>Retriable: False</para>
        ///</summary>
        UNACCEPTABLE_CREDENTIAL = 93,
        ///<summary>
        /// Indicates that the either the sender or recipient of a voter-only request is not one of the expected voters
        /// <para>Retriable: False</para>
        ///</summary>
        INCONSISTENT_VOTER_SET = 94,
        ///<summary>
        /// The given update version was invalid.
        /// <para>Retriable: False</para>
        ///</summary>
        INVALID_UPDATE_VERSION = 95,
        ///<summary>
        /// Unable to update finalized features due to an unexpected server error.
        /// <para>Retriable: False</para>
        ///</summary>
        FEATURE_UPDATE_FAILED = 96,
        ///<summary>
        /// Request principal deserialization failed during forwarding. This indicates an internal error on the broker cluster security setup.
        /// <para>Retriable: False</para>
        ///</summary>
        PRINCIPAL_DESERIALIZATION_FAILURE = 97,
        ///<summary>
        /// Requested snapshot was not found
        /// <para>Retriable: False</para>
        ///</summary>
        SNAPSHOT_NOT_FOUND = 98,
        ///<summary>
        /// Requested position is not greater than or equal to zero, and less than the size of the snapshot.
        /// <para>Retriable: False</para>
        ///</summary>
        POSITION_OUT_OF_RANGE = 99,
        ///<summary>
        /// This server does not host this topic ID.
        /// <para>Retriable: True</para>
        ///</summary>
        UNKNOWN_TOPIC_ID = 100,
        ///<summary>
        /// This broker ID is already in use.
        /// <para>Retriable: False</para>
        ///</summary>
        DUPLICATE_BROKER_REGISTRATION = 101,
        ///<summary>
        /// The given broker ID was not registered.
        /// <para>Retriable: False</para>
        ///</summary>
        BROKER_ID_NOT_REGISTERED = 102,
        ///<summary>
        /// The log's topic ID did not match the topic ID in the request
        /// <para>Retriable: True</para>
        ///</summary>
        INCONSISTENT_TOPIC_ID = 103,
        ///<summary>
        /// The clusterId in the request does not match that found on the server
        /// <para>Retriable: False</para>
        ///</summary>
        INCONSISTENT_CLUSTER_ID = 104,
        ///<summary>
        /// The transactionalId could not be found
        /// <para>Retriable: False</para>
        ///</summary>
        TRANSACTIONAL_ID_NOT_FOUND = 105,
        ///<summary>
        /// The fetch session encountered inconsistent topic ID usage
        /// <para>Retriable: True</para>
        ///</summary>
        FETCH_SESSION_TOPIC_ID_ERROR = 106,
    }
}
