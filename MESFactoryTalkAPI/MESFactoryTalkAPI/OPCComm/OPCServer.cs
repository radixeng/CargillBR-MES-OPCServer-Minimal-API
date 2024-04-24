using MESOPCServerMinimalAPI.DTO;
using Opc.UaFx.Client;
using Newtonsoft.Json;

namespace MESOPCServerMinimalAPI.OPCServer
{
public class OPCServer
{
    private readonly IConfiguration? _config;
    private readonly CustomLog _customLog;
    public OPCServer(IConfiguration? config, CustomLog customLog)
    {
        _config = config;
        _customLog = customLog;
    }

    public string? GetAllTags()
    {
        // Endereço do servidor OPC UA
        string? serverUrl = _config?.GetSection("OPCServerConfig:ServerUrl").Value;

        // Lista de tags a serem lidas
        List<string>? tags = _config.GetSection("OPCServerConfig:Tags").Value.Split(",").ToList();

        try
        {
            using (var client = new OpcClient(serverUrl))
            {
                // Iniciando conexão com o OPC Server.
                client.Connect();
                if (client.State == OpcClientState.Connected)
                {
                    _customLog.Log($"Information: Conectado ao servidor OPC UA: {serverUrl}");

                    var tagDataList = new List<TagData>();

                    foreach (string tag in tags)
                    {
                        var OPCServerResponse = client.ReadNode(tag);

                        tagDataList.Add(new TagData
                        {
                            Tag = tag,
                            Value = OPCServerResponse.Value,
                            Timestamp = OPCServerResponse.SourceTimestamp,
                            Quality = OPCServerResponse.Status.Code.ToString()
                        });

                        if (!OPCServerResponse.Status.IsGood)
                        {
                            // Se houver erro na tag, será registrado no log
                            _customLog.Log($"Error: Erro ao ler a tag {tag}: {OPCServerResponse.Value}");
                        }
                    }

                    // Serializa os dados para JSON
                    string json = JsonConvert.SerializeObject(tagDataList, Newtonsoft.Json.Formatting.Indented);

                    // Desconecta do servidor OPC UA
                    client.Disconnect();
                    _customLog.Log("Information: Desconectado do servidor OPC UA.");

                    return json;
                }
                else
                {
                    _customLog.Log($"Information: Status da conexão ao servidor OPC UA: {client.State.ToString()}");
                }
                return "";
            }
        }
        catch (Exception ex)
        {
            _customLog.Log($"Error: Erro ao conectar ao servidor OPC UA: {ex.Message}");
            return null;
        }
    }
}
}