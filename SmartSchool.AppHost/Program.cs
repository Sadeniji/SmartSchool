var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SmartSchool_Web>("web");

builder.Build().Run();
