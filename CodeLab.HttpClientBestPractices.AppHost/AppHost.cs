var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CodeLab_HttpClientBestPractices_Api>("codelab-httpclientbestpractices-api");

builder.Build().Run();
