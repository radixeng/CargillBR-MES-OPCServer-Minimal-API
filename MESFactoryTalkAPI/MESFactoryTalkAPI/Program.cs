using MESOPCServerMinimalAPI.OPCServer;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

string logPath = config["LogPath"];
var customLog = new CustomLog(logPath);

try
{

builder.Services.AddSingleton(customLog);

var app = builder.Build();

app.MapGet("/opcservertags", () =>
{
    var OCPObj = new OPCServer(config, customLog);
    var OPCTags = OCPObj.GetAllTags();

    return OPCTags;
});

    app.Run();

}

catch (Exception ex)
{
customLog.Log("Warning: Um erro inesperado ocorreu: {0}", ex.Message);
}


