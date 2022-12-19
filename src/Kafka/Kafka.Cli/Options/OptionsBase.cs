﻿using CommandLine;

namespace Kafka.Cli.Options
{
    public abstract class OptionsBase
    {
        [Option("bootstrap-server", Required = true)]
        public string BootstrapServer { get; set; } = "";

        [Option("client-id")]
        public string ClientId { get; set; } = "";

        [Option("apiversion", Required = false)]
        public short ApiVersion { get; set; } = -1;
    }
}