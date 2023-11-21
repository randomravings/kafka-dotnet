# Introduction

The goal of this project is to create a native .Net Client library and commandline utility for Kafka.
> Disclaimer: This is early days so do expect a bit of randomness ...

## Getting Started

This project required [.Net 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or higher on your machine.

To run the Cli:

- Clone the repository and run `dotnet build`
- This should output a `kafka-cli` executable in directory `src/Kafka.Cli/bin/Debug/net8.0`
- Run the `kafka-cli` executable

Creating a topic:

```bash
./kafka-cli.exe topics create --bootstrap-server localhost:9092 --topic test
```

Producing to a topic:

```bash
./kafka-cli.exe producer --bootstrap-server localhost:9092 --topic test
```

The produce command only accepts comma separated key value pairs eg. "some_key,some_value".

Consuming from a topic:

```bash
./kafka-cli.exe consumer --bootstrap-server localhost:9092 --topic test --group-id test-cg
```
