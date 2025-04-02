var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Clean2025_WebAPI>("clean2025-webapi");

builder.Build().Run();
