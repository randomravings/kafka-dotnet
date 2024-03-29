﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "Kafka is about Streaming", Scope = "namespaceanddescendants", Target = "~N:Kafka.Client")]

[assembly: SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Get is a universal concept", Scope = "namespaceanddescendants", Target = "~N:Kafka.Client")]
