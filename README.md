# Introduction

The goal of this project is to create a native .Net Client library and commandline utility for Kafka.
Additionally it serves to provide a new approach to the existing interfaces.
> Disclaimer: This is an experimental project and while public is provided as-is without any warranties.
> The interfaces are still worked on so breaking changes are the norm...

## Design

The current kafka client libraries are split into Producer, Consumer and Admin clients, which means that there will be an indepentand set of connections for each of them.
Further with the introduction of serialization that introduced generic arguments into the Producer and Consumer interfaces has the consequence of the need to instantiate different clients for each type.
While it makes sense to separate Producer and Consumer connections, it is not strictly neccessary, but having ditterent conections per type can become excessive, the only option is to fall back to only using bytes and do the serialization outside of the Producer and consumer clients.

This implementation aims to remove the above mentioned constraints by combining the interfaces into one client and thereby allowing the developer to orchestrate the separation if required.
The way this is done is to treat the Kafka Client as a Kafka Cluster proxy which maintains at most one connection per node and enables the [kafka protocol APIs](https://kafka.apache.org/protocol.html#protocol_api_keys) to perform the operations required by Producer, Consumer and Admin interfaces.

The Producer and Consumer interfaces in this implementation are also renamed to match the notion of Kafka being a stream processing data platform. Most modern programming languages have a notion of a stream (File, Bytes, Socket, etc.) that are intuitive to most developers so the experiment is to borrow those concepts here. This means that rather than a Producer, we have an WriteStream, and instread of the a Consumer we have a ReadStream. The interfaces are still kepts separate beause the function very differently under the covers, but we are emphasizeing the concept of a Stream. Both Read and Write Streams are raw interfaces supporting operatrions that we know from the Producer and Consumer interfaces but are only working with bytes. The idea is that one _can_ have any number of Input and Output stream per Kafka Client. An example use case is to optimize the batching for Write/Produce operations to the cluster which can be fragmented quite a lot for large clusters serving a large number of Client instances.

To support an interface for wrapping some of the more common operations such as serialization we introduce the concept of a StreamWriter and StreamReader that can operate on the Read and Write streams respectively. The idea is that we _can_ have more that one instance per Stream to suport the notion of running differently typed data on the same Stream.

In summary, the idea is to provide flexibility and leverage the ability to pack any combintion of topics (or topic partitions) and types into the same [Produce](https://kafka.apache.org/protocol.html#The_Messages_Produce) and [Fetch](https://kafka.apache.org/protocol.html#The_Messages_Fetch) intuitively through the new interfaces. Here is a high level overview of the design idea:

![High level overview](/img/kafka-dotnet-L0.png)

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
./kafka-cli.exe consumer --bootstrap-server localhost:9092 --topics test --group-id test-cg
```
