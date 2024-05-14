var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AdvenchR>("advenchr");

builder.Build().Run();
