#:sdk Microsoft.NET.Sdk.Web
//#:package AspNetCore.HealthChecks.Azure.Storage.Blobs@8.0.1
#:package Aspire.Azure.Storage.Blobs@13.1.0
#:property PublishContainer=true
#:property ContainerRepository=test-blob-api
#:property PublishAot=false

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddAzureBlobServiceClient("blobs");

WebApplication app = builder.Build();

app.MapHealthChecks("/health");

app.Run();