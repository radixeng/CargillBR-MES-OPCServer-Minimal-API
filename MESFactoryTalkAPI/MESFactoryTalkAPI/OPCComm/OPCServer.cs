using System.Xml;
using Opc.UaFx.Client;
using Newtonsoft.Json;
using MESOPCServerMinimalAPI.DTO;
using System.Net.Sockets;

namespace MESOPCServerMinimalAPI.OPCServer
{
    class OPCServer
    {
        public static string GetAllTags()
        {
            // Endereço do servidor OPC UA
            string serverUrl = "opc.tcp://NXPE09EKKM.radixengrj.matriz:49320";

            // Lista de tags a serem lidas
            string[] tags = new string[] {
            "ns=2;s=Simulation Examples._System._Description",
            "ns=2;s=Simulation Examples._System._EnableDiagnostics",
            "ns=2;s=Simulation Examples._System._WriteOptimizationDutyCycle",
            "ns=2;s=_System._DateTimeLocal"
        };

            {
                // Cria uma instância do cliente OPC UA
                using (var client = new OpcClient(serverUrl))
                {
                    // Conecta ao servidor OPC UA
                    client.Connect();

                    Console.WriteLine("Conectado ao servidor OPC UA.");

                    var tagDataList = new List<TagData>();

                    foreach (string tag in tags)
                    {
                        // Lê o valor da tag atual
                        var OPCServerResponse = client.ReadNode(tag);

                        if (OPCServerResponse != null)
                        {
                           
                            TagData tagData = new TagData();

                            // Adiciona os dados da tag à lista
                            tagDataList.Add(new TagData { Tag = tag, Value = OPCServerResponse.Value, Timestamp = OPCServerResponse.SourceTimestamp, Quality = OPCServerResponse.Status.Code.ToString() });
                        }
                        else
                        {
                            Console.WriteLine($"Falha ao ler a tag {tag}.");
                        }
                    }

                    // Serializa os dados para JSON
                    string json = JsonConvert.SerializeObject(tagDataList, Newtonsoft.Json.Formatting.Indented);


                    // Desconecta do servidor OPC UA
                    client.Disconnect();
                    return json;
                }

            }

        }
    }
}
