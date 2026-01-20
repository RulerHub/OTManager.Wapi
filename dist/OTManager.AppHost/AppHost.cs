var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.OTManager_Api>("OTManager-Api");

builder.AddProject<Projects.OTManager_Web>("OTManager-Web");

builder.Build().Run();
