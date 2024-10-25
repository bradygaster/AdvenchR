var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AdvenchR>("frontend");

builder.Build().Run();
