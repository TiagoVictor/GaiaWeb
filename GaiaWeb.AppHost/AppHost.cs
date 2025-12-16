var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.GaiaWeb_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.GaiaWeb_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
