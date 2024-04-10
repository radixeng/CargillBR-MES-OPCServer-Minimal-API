using MESOPCServerMinimalAPI.DTO;
using MESOPCServerMinimalAPI.OPCServer;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Opc.UaFx.Client;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();

// Endpoint para retornar as tags do servidor OPC UA
app.MapGet("/opcservertags", () =>

{
    var OPCTags = OPCServer.GetAllTags();

    return OPCTags;

});

app.UseSwaggerUI();

app.Run();
