using Kafka.CodeGen.Models;
using Newtonsoft.Json;

namespace Kafka.CodeGen.UnitTest
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
           var x = JsonConvert.DeserializeObject<ApiRequestMessage>(KIP);
        }

        private const string KIP = @"
        {
          ""apiKey"": 25,
          ""type"": ""request"",
          ""listeners"": [""zkBroker"", ""broker""],
          ""name"": ""AddOffsetsToTxnRequest"",
          // Version 1 is the same as version 0.
          //
          // Version 2 adds the support for new error code PRODUCER_FENCED.
          //
          // Version 3 enables flexible versions.
          ""validVersions"": ""0-3"",
          ""flexibleVersions"": ""3+"",
          ""fields"": [
            { ""name"": ""TransactionalId"", ""type"": ""string"", ""versions"": ""0+"", ""entityType"": ""transactionalId"",
              ""about"": ""The transactional id corresponding to the transaction.""},
            { ""name"": ""ProducerId"", ""type"": ""int64"", ""versions"": ""0+"", ""entityType"": ""producerId"",
              ""about"": ""Current producer id in use by the transactional id."" },
            { ""name"": ""ProducerEpoch"", ""type"": ""int16"", ""versions"": ""0+"",
              ""about"": ""Current epoch associated with the producer id."" },
            { ""name"": ""GroupId"", ""type"": ""string"", ""versions"": ""0+"", ""entityType"": ""groupId"",
              ""about"": ""The unique group identifier."" }
          ]
        }
        ";
    }
}