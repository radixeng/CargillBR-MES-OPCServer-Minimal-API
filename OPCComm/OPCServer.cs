using MESOPCServerMinimalAPI.DTO;
using Newtonsoft.Json;
using Opc.Ua;
using Opc.Ua.Client;

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

        public async Task<string?> GetAllTagsAsync()
        {
            string? serverUrl = _config?.GetSection("OPCServerConfig:ServerUrl").Value;
            List<string>? tags = _config.GetSection("OPCServerConfig:Tags").Value.Split(",").ToList();

            try
            {
                var config = new ApplicationConfiguration

                {
                    ApplicationName = "OPC UA Client",
                    ApplicationType = ApplicationType.Client,
                    SecurityConfiguration = new SecurityConfiguration
                    {
                        ApplicationCertificate = new CertificateIdentifier(),
                        TrustedPeerCertificates = new CertificateTrustList(),
                        TrustedIssuerCertificates = new CertificateTrustList(),
                        RejectedCertificateStore = new CertificateTrustList(),
                        AutoAcceptUntrustedCertificates = true
                    },
                    TransportQuotas = new TransportQuotas { OperationTimeout = 60000 },
                    ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
                    TraceConfiguration = new TraceConfiguration(),

                };

                var endpointDescription = CoreClientUtils.SelectEndpoint(serverUrl, false);
                var endpointConfiguration = EndpointConfiguration.Create(config);
                var endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
                var session = await Session.Create(config, endpoint, false, "", 60000, null, null);


                if (session != null && session.Connected)
                {
                    _customLog.Log($"Information: Conectado ao servidor OPC UA: {serverUrl}");

                    var tagDataList = new List<TagData>();

                    foreach (string tag in tags)
                    {
                        try
                        {
                            ExpandedNodeId nodeId = ExpandedNodeId.Parse(tag);
                            var readResult = await session.ReadValueAsync((NodeId)nodeId);

                            tagDataList.Add(new TagData
                            {
                                Tag = tag,
                                Value = readResult.Value,
                                Timestamp = readResult.SourceTimestamp,
                                Quality = readResult.StatusCode.ToString()
                            });
                        }
                        catch (Exception ex)
                        {
                            _customLog.Log($"Error: Erro ao ler a tag {tag}: {ex.Message}");
                            tagDataList.Add(new TagData
                            {
                                Tag = tag,
                                Value = null,
                                Timestamp = null,
                                Quality = ex.Message
                            });
                        }
                    }

                    string json = JsonConvert.SerializeObject(tagDataList, Newtonsoft.Json.Formatting.Indented);

                    await session.CloseAsync();
                    _customLog.Log("Information: Desconectado do servidor OPC UA.");

                    return json;
                }
                else
                {
                    _customLog.Log($"Warning: Falha ao conectar ao servidor OPC UA: {serverUrl}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _customLog.Log($"Error: Ocorreu um erro inesperado durante a comunicação com o servidor OPC UA: {ex.Message}");
                return null;
            }
        }
    }
}
