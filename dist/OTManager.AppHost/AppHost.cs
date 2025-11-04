var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.OTManager_Api>("ot-manager-api");

builder.AddProject<Projects.OTManager_Web>("ot-manager-web")
    .WaitFor(api);

builder.Build().Run();
