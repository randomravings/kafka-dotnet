namespace Kafka.Common.Model
{
    public sealed record ApiError(
        short Code,
        string Label,
        bool Retriable,
        string Message
    )
    {
        public static readonly ApiError UnknownServerError = new(-1, "UNKNOWN_SERVER_ERROR", false, "The server experienced an unexpected error when processing the request.");
        public static readonly ApiError None = new(0, "NONE", false, "");
        public static readonly ApiError OffsetOutOfRange = new(1, "OFFSET_OUT_OF_RANGE", false, "The requested offset is not within the range of offsets maintained by the server.");
        public static readonly ApiError CorruptMessage = new(2, "CORRUPT_MESSAGE", true, "This message has failed its CRC checksum, exceeds the valid size, has a null key for a compacted topic, or is otherwise corrupt.");
        public static readonly ApiError UnknownTopicOrPartition = new(3, "UNKNOWN_TOPIC_OR_PARTITION", true, "This server does not host this topic-partition.");
        public static readonly ApiError InvalidFetchSize = new(4, "INVALID_FETCH_SIZE", false, "The requested fetch size is invalid.");
        public static readonly ApiError LeaderNotAvailable = new(5, "LEADER_NOT_AVAILABLE", true, "There is no leader for this topic-partition as we are in the middle of a leadership election.");
        public static readonly ApiError NotLeaderOrFollower = new(6, "NOT_LEADER_OR_FOLLOWER", true, "For requests intended only for the leader, this error indicates that the broker is not the current leader. For requests intended for any replica, this error indicates that the broker is not a replica of the topic partition.");
        public static readonly ApiError RequestTimedOut = new(7, "REQUEST_TIMED_OUT", true, "The request timed out.");
        public static readonly ApiError BrokerNotAvailable = new(8, "BROKER_NOT_AVAILABLE", false, "The broker is not available.");
        public static readonly ApiError ReplicaNotAvailable = new(9, "REPLICA_NOT_AVAILABLE", true, "The replica is not available for the requested topic-partition. Produce/Fetch requests and other requests intended only for the leader or follower return NOT_LEADER_OR_FOLLOWER if the broker is not a replica of the topic-partition.");
        public static readonly ApiError MessageTooLarge = new(10, "MESSAGE_TOO_LARGE", false, "The request included a message larger than the max message size the server will accept.");
        public static readonly ApiError StaleControllerEpoch = new(11, "STALE_CONTROLLER_EPOCH", false, "The controller moved to another broker.");
        public static readonly ApiError OffsetMetadataTooLarge = new(12, "OFFSET_METADATA_TOO_LARGE", false, "The metadata field of the offset request was too large.");
        public static readonly ApiError NetworkException = new(13, "NETWORK_EXCEPTION", true, "The server disconnected before a response was received.");
        public static readonly ApiError CoordinatorLoadInProgress = new(14, "COORDINATOR_LOAD_IN_PROGRESS", true, "The coordinator is loading and hence can't process requests.");
        public static readonly ApiError CoordinatorNotAvailable = new(15, "COORDINATOR_NOT_AVAILABLE", true, "The coordinator is not available.");
        public static readonly ApiError NotCoordinator = new(16, "NOT_COORDINATOR", true, "This is not the correct coordinator.");
        public static readonly ApiError InvalidTopicException = new(17, "INVALID_TOPIC_EXCEPTION", false, "The request attempted to perform an operation on an invalid topic.");
        public static readonly ApiError RecordListTooLarge = new(18, "RECORD_LIST_TOO_LARGE", false, "The request included message batch larger than the configured segment size on the server.");
        public static readonly ApiError NotEnoughReplicas = new(19, "NOT_ENOUGH_REPLICAS", true, "Messages are rejected since there are fewer in-sync replicas than required.");
        public static readonly ApiError NotEnoughReplicasAfterAppend = new(20, "NOT_ENOUGH_REPLICAS_AFTER_APPEND", true, "Messages are written to the log, but to fewer in-sync replicas than required.");
        public static readonly ApiError InvalidRequiredAcks = new(21, "INVALID_REQUIRED_ACKS", false, "Produce request specified an invalid value for required acks.");
        public static readonly ApiError IllegalGeneration = new(22, "ILLEGAL_GENERATION", false, "Specified group generation id is not valid.");
        public static readonly ApiError InconsistentGroupProtocol = new(23, "INCONSISTENT_GROUP_PROTOCOL", false, "The group member's supported protocols are incompatible with those of existing members or first group member tried to join with empty protocol type or empty protocol list.");
        public static readonly ApiError InvalidGroupId = new(24, "INVALID_GROUP_ID", false, "The configured groupId is invalid.");
        public static readonly ApiError UnknownMemberId = new(25, "UNKNOWN_MEMBER_ID", false, "The coordinator is not aware of this member.");
        public static readonly ApiError InvalidSessionTimeout = new(26, "INVALID_SESSION_TIMEOUT", false, "The session timeout is not within the range allowed by the broker (as configured by group.min.session.timeout.ms and group.max.session.timeout.ms).");
        public static readonly ApiError RebalanceInProgress = new(27, "REBALANCE_IN_PROGRESS", false, "The group is rebalancing, so a rejoin is needed.");
        public static readonly ApiError InvalidCommitOffsetSize = new(28, "INVALID_COMMIT_OFFSET_SIZE", false, "The committing offset data size is not valid.");
        public static readonly ApiError TopicAuthorizationFailed = new(29, "TOPIC_AUTHORIZATION_FAILED", false, "Topic authorization failed.");
        public static readonly ApiError GroupAuthorizationFailed = new(30, "GROUP_AUTHORIZATION_FAILED", false, "Group authorization failed.");
        public static readonly ApiError ClusterAuthorizationFailed = new(31, "CLUSTER_AUTHORIZATION_FAILED", false, "Cluster authorization failed.");
        public static readonly ApiError InvalidTimestamp = new(32, "INVALID_TIMESTAMP", false, "The timestamp of the message is out of acceptable range.");
        public static readonly ApiError UnsupportedSaslMechanism = new(33, "UNSUPPORTED_SASL_MECHANISM", false, "The broker does not support the requested SASL mechanism.");
        public static readonly ApiError IllegalSaslState = new(34, "ILLEGAL_SASL_STATE", false, "Request is not valid given the current SASL state.");
        public static readonly ApiError UnsupportedVersion = new(35, "UNSUPPORTED_VERSION", false, "The version of API is not supported.");
        public static readonly ApiError TopicAlreadyExists = new(36, "TOPIC_ALREADY_EXISTS", false, "Topic with this name already exists.");
        public static readonly ApiError InvalidPartitions = new(37, "INVALID_PARTITIONS", false, "Number of partitions is below 1.");
        public static readonly ApiError InvalidReplicationFactor = new(38, "INVALID_REPLICATION_FACTOR", false, "Replication factor is below 1 or larger than the number of available brokers.");
        public static readonly ApiError InvalidReplicaAssignment = new(39, "INVALID_REPLICA_ASSIGNMENT", false, "Replica assignment is invalid.");
        public static readonly ApiError InvalidConfig = new(40, "INVALID_CONFIG", false, "Configuration is invalid.");
        public static readonly ApiError NotController = new(41, "NOT_CONTROLLER", true, "This is not the correct controller for this cluster.");
        public static readonly ApiError InvalidRequest = new(42, "INVALID_REQUEST", false, "This most likely occurs because of a request being malformed by the client library or the message was sent to an incompatible broker. See the broker logs for more details.");
        public static readonly ApiError UnsupportedForMessageFormat = new(43, "UNSUPPORTED_FOR_MESSAGE_FORMAT", false, "The message format version on the broker does not support the request.");
        public static readonly ApiError PolicyViolation = new(44, "POLICY_VIOLATION", false, "Request parameters do not satisfy the configured policy.");
        public static readonly ApiError OutOfOrderSequenceNumber = new(45, "OUT_OF_ORDER_SEQUENCE_NUMBER", false, "The broker received an out of order sequence number.");
        public static readonly ApiError DuplicateSequenceNumber = new(46, "DUPLICATE_SEQUENCE_NUMBER", false, "The broker received a duplicate sequence number.");
        public static readonly ApiError InvalidProducerEpoch = new(47, "INVALID_PRODUCER_EPOCH", false, "Producer attempted to produce with an old epoch.");
        public static readonly ApiError InvalidTxnState = new(48, "INVALID_TXN_STATE", false, "The producer attempted a transactional operation in an invalid state.");
        public static readonly ApiError InvalidProducerIdMapping = new(49, "INVALID_PRODUCER_ID_MAPPING", false, "The producer attempted to use a producer id which is not currently assigned to its transactional id.");
        public static readonly ApiError InvalidTransactionTimeout = new(50, "INVALID_TRANSACTION_TIMEOUT", false, "The transaction timeout is larger than the maximum value allowed by the broker (as configured by transaction.max.timeout.ms).");
        public static readonly ApiError ConcurrentTransactions = new(51, "CONCURRENT_TRANSACTIONS", true, "The producer attempted to update a transaction while another concurrent operation on the same transaction was ongoing.");
        public static readonly ApiError TransactionCoordinatorFenced = new(52, "TRANSACTION_COORDINATOR_FENCED", false, "Indicates that the transaction coordinator sending a WriteTxnMarker is no longer the current coordinator for a given producer.");
        public static readonly ApiError TransactionalIdAuthorizationFailed = new(53, "TRANSACTIONAL_ID_AUTHORIZATION_FAILED", false, "Transactional Id authorization failed.");
        public static readonly ApiError SecurityDisabled = new(54, "SECURITY_DISABLED", false, "Security features are disabled.");
        public static readonly ApiError OperationNotAttempted = new(55, "OPERATION_NOT_ATTEMPTED", false, "The broker did not attempt to execute this operation. This may happen for batched RPCs where some operations in the batch failed, causing the broker to respond without trying the rest.");
        public static readonly ApiError KafkaStorageError = new(56, "KAFKA_STORAGE_ERROR", true, "Disk error when trying to access log file on the disk.");
        public static readonly ApiError LogDirNotFound = new(57, "LOG_DIR_NOT_FOUND", false, "The user-specified log directory is not found in the broker config.");
        public static readonly ApiError SaslAuthenticationFailed = new(58, "SASL_AUTHENTICATION_FAILED", false, "SASL Authentication failed.");
        public static readonly ApiError UnknownProducerId = new(59, "UNKNOWN_PRODUCER_ID", false, "This exception is raised by the broker if it could not locate the producer metadata associated with the producerId in question. This could happen if, for instance, the producer's records were deleted because their retention time had elapsed. Once the last records of the producerId are removed, the producer's metadata is removed from the broker, and future appends by the producer will return this exception.");
        public static readonly ApiError ReassignmentInProgress = new(60, "REASSIGNMENT_IN_PROGRESS", false, "A partition reassignment is in progress.");
        public static readonly ApiError DelegationTokenAuthDisabled = new(61, "DELEGATION_TOKEN_AUTH_DISABLED", false, "Delegation Token feature is not enabled.");
        public static readonly ApiError DelegationTokenNotFound = new(62, "DELEGATION_TOKEN_NOT_FOUND", false, "Delegation Token is not found on server.");
        public static readonly ApiError DelegationTokenOwnerMismatch = new(63, "DELEGATION_TOKEN_OWNER_MISMATCH", false, "Specified Principal is not valid Owner/Renewer.");
        public static readonly ApiError DelegationTokenRequestNotAllowed = new(64, "DELEGATION_TOKEN_REQUEST_NOT_ALLOWED", false, "Delegation Token requests are not allowed on PLAINTEXT/1-way SSL channels and on delegation token authenticated channels.");
        public static readonly ApiError DelegationTokenAuthorizationFailed = new(65, "DELEGATION_TOKEN_AUTHORIZATION_FAILED", false, "Delegation Token authorization failed.");
        public static readonly ApiError DelegationTokenExpired = new(66, "DELEGATION_TOKEN_EXPIRED", false, "Delegation Token is expired.");
        public static readonly ApiError InvalidPrincipalType = new(67, "INVALID_PRINCIPAL_TYPE", false, "Supplied principalType is not supported.");
        public static readonly ApiError NonEmptyGroup = new(68, "NON_EMPTY_GROUP", false, "The group is not empty.");
        public static readonly ApiError GroupIdNotFound = new(69, "GROUP_ID_NOT_FOUND", false, "The group id does not exist.");
        public static readonly ApiError FetchSessionIdNotFound = new(70, "FETCH_SESSION_ID_NOT_FOUND", true, "The fetch session ID was not found.");
        public static readonly ApiError InvalidFetchSessionEpoch = new(71, "INVALID_FETCH_SESSION_EPOCH", true, "The fetch session epoch is invalid.");
        public static readonly ApiError ListenerNotFound = new(72, "LISTENER_NOT_FOUND", true, "There is no listener on the leader broker that matches the listener on which metadata request was processed.");
        public static readonly ApiError TopicDeletionDisabled = new(73, "TOPIC_DELETION_DISABLED", false, "Topic deletion is disabled.");
        public static readonly ApiError FencedLeaderEpoch = new(74, "FENCED_LEADER_EPOCH", true, "The leader epoch in the request is older than the epoch on the broker.");
        public static readonly ApiError UnknownLeaderEpoch = new(75, "UNKNOWN_LEADER_EPOCH", true, "The leader epoch in the request is newer than the epoch on the broker.");
        public static readonly ApiError UnsupportedCompressionType = new(76, "UNSUPPORTED_COMPRESSION_TYPE", false, "The requesting client does not support the compression type of given partition.");
        public static readonly ApiError StaleBrokerEpoch = new(77, "STALE_BROKER_EPOCH", false, "Broker epoch has changed.");
        public static readonly ApiError OffsetNotAvailable = new(78, "OFFSET_NOT_AVAILABLE", true, "The leader high watermark has not caught up from a recent leader election so the offsets cannot be guaranteed to be monotonically increasing.");
        public static readonly ApiError MemberIdRequired = new(79, "MEMBER_ID_REQUIRED", false, "The group member needs to have a valid member id before actually entering a consumer group.");
        public static readonly ApiError PreferredLeaderNotAvailable = new(80, "PREFERRED_LEADER_NOT_AVAILABLE", true, "The preferred leader was not available.");
        public static readonly ApiError GroupMaxSizeReached = new(81, "GROUP_MAX_SIZE_REACHED", false, "The consumer group has reached its max size.");
        public static readonly ApiError FencedInstanceId = new(82, "FENCED_INSTANCE_ID", false, "The broker rejected this static consumer since another consumer with the same group.instance.id has registered with a different member.id.");
        public static readonly ApiError EligibleLeadersNotAvailable = new(83, "ELIGIBLE_LEADERS_NOT_AVAILABLE", true, "Eligible topic partition leaders are not available.");
        public static readonly ApiError ElectionNotNeeded = new(84, "ELECTION_NOT_NEEDED", true, "Leader election not needed for topic partition.");
        public static readonly ApiError NoReassignmentInProgress = new(85, "NO_REASSIGNMENT_IN_PROGRESS", false, "No partition reassignment is in progress.");
        public static readonly ApiError GroupSubscribedToTopic = new(86, "GROUP_SUBSCRIBED_TO_TOPIC", false, "Deleting offsets of a topic is forbidden while the consumer group is actively subscribed to it.");
        public static readonly ApiError InvalidRecord = new(87, "INVALID_RECORD", false, "This record has failed the validation on broker and hence will be rejected.");
        public static readonly ApiError UnstableOffsetCommit = new(88, "UNSTABLE_OFFSET_COMMIT", true, "There are unstable offsets that need to be cleared.");
        public static readonly ApiError ThrottlingQuotaExceeded = new(89, "THROTTLING_QUOTA_EXCEEDED", true, "The throttling quota has been exceeded.");
        public static readonly ApiError ProducerFenced = new(90, "PRODUCER_FENCED", false, "There is a newer producer with the same transactionalId which fences the current one.");
        public static readonly ApiError ResourceNotFound = new(91, "RESOURCE_NOT_FOUND", false, "A request illegally referred to a resource that does not exist.");
        public static readonly ApiError DuplicateResource = new(92, "DUPLICATE_RESOURCE", false, "A request illegally referred to the same resource twice.");
        public static readonly ApiError UnacceptableCredential = new(93, "UNACCEPTABLE_CREDENTIAL", false, "Requested credential would not meet criteria for acceptability.");
        public static readonly ApiError InconsistentVoterSet = new(94, "INCONSISTENT_VOTER_SET", false, "Indicates that the either the sender or recipient of a voter-only request is not one of the expected voters");
        public static readonly ApiError InvalidUpdateVersion = new(95, "INVALID_UPDATE_VERSION", false, "The given update version was invalid.");
        public static readonly ApiError FeatureUpdateFailed = new(96, "FEATURE_UPDATE_FAILED", false, "Unable to update finalized features due to an unexpected server error.");
        public static readonly ApiError PrincipalDeserializationFailure = new(97, "PRINCIPAL_DESERIALIZATION_FAILURE", false, "Request principal deserialization failed during forwarding. This indicates an internal error on the broker cluster security setup.");
        public static readonly ApiError SnapshotNotFound = new(98, "SNAPSHOT_NOT_FOUND", false, "Requested snapshot was not found");
        public static readonly ApiError PositionOutOfRange = new(99, "POSITION_OUT_OF_RANGE", false, "Requested position is not greater than or equal to zero, and less than the size of the snapshot.");
        public static readonly ApiError UnknownTopicId = new(100, "UNKNOWN_TOPIC_ID", true, "This server does not host this topic ID.");
        public static readonly ApiError DuplicateBrokerRegistration = new(101, "DUPLICATE_BROKER_REGISTRATION", false, "This broker ID is already in use.");
        public static readonly ApiError BrokerIdNotRegistered = new(102, "BROKER_ID_NOT_REGISTERED", false, "The given broker ID was not registered.");
        public static readonly ApiError InconsistentTopicId = new(103, "INCONSISTENT_TOPIC_ID", true, "The log's topic ID did not match the topic ID in the request");
        public static readonly ApiError InconsistentClusterId = new(104, "INCONSISTENT_CLUSTER_ID", false, "The clusterId in the request does not match that found on the server");
        public static readonly ApiError TransactionalIdNotFound = new(105, "TRANSACTIONAL_ID_NOT_FOUND", false, "The transactionalId could not be found");
        public static readonly ApiError FetchSessionTopicIdError = new(106, "FETCH_SESSION_TOPIC_ID_ERROR", true, "The fetch session encountered inconsistent topic ID usage");
        public static readonly ApiError IneligibleReplica = new(107, "INELIGIBLE_REPLICA", false, "The new ISR contains at least one ineligible replica.");
        public static readonly ApiError NewLeaderElected = new(108, "NEW_LEADER_ELECTED", false, "The AlterPartition request successfully updated the partition state but the leader has changed.");
        public static readonly ApiError OffsetMovedToTieredStorage = new(109, "OFFSET_MOVED_TO_TIERED_STORAGE", false, "The requested offset is moved to tiered storage.");
        public static readonly ApiError FencedMemberEpoch = new(110, "FENCED_MEMBER_EPOCH", false, "The member epoch is fenced by the group coordinator. The member must abandon all its partitions and rejoin.");
        public static readonly ApiError UnreleasedInstanceId = new(111, "UNRELEASED_INSTANCE_ID", false, "The instance ID is still used by another member in the consumer group. That member must leave first.");
        public static readonly ApiError UnsupportedAssignor = new(112, "UNSUPPORTED_ASSIGNOR", false, "The assignor or its version range is not supported by the consumer group.");
        public static readonly ApiError StaleMemberEpoch = new(113, "STALE_MEMBER_EPOCH", false, "The member epoch is stale. The member must retry after receiving its updated member epoch via the ConsumerGroupHeartbeat API.");

    }
}
