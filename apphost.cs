#:package Aspire.Hosting.Azure.Storage@13.1.0
#:sdk Aspire.AppHost.Sdk@13.1.0

var builder = DistributedApplication.CreateBuilder(args);

var storage = builder
    .AddAzureStorage("storage")
    .RunAsEmulator();

storage.AddBlobContainer("test-container");

var blobs = storage.AddBlobs("blobs");

builder.AddContainer("test-blob-api-container", "test-blob-api:latest")
    .WithReference(blobs)
    .WithHttpEndpoint(targetPort: 8080)
    .WithHttpHealthCheck("/health");

#pragma warning disable ASPIRECSHARPAPPS001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
builder.AddCSharpApp("test-blob-api", "api.cs")
    .WithReference(blobs)
    .WithHttpEndpoint(port: 8080)
    .WithHttpHealthCheck("/health");
#pragma warning restore ASPIRECSHARPAPPS001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

builder.Build().Run();
