using CodeLab.HttpClientBestPractices.Api.Clients;
using CodeLab.HttpClientBestPractices.Api.Endpoints;
using CodeLab.HttpClientBestPractices.Api.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<HttpClientBestPracticesOptions>()
    .Bind(builder.Configuration)
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.AddServiceDefaults();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//here we can configure the HttpClient with default settings
//we are defining the base address and some default headers
builder.Services.AddHttpClient("gh-client", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");
    httpClient.DefaultRequestHeaders.Add("user-agent", "GitHub-Integration-App");
});

//this is a typed client, where we can specify a class to encapsulate the HttpClient
builder.Services.AddHttpClient<GitHubClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.github.com/");
    httpClient.DefaultRequestHeaders.Add("user-agent", "GitHub-Integration-App");
});

//we can up this with some configurations
//we are using the IOptions pattern to get the settings from configuration
builder.Services.AddHttpClient("gh-client3", (serviceProvider, httpClient) =>
{
    var gitHubSettings = serviceProvider.GetRequiredService<IOptions<HttpClientBestPracticesOptions>>().Value;

    httpClient.BaseAddress = new Uri(gitHubSettings.GitHubSettings.BaseUrl);
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {gitHubSettings.GitHubSettings.ApiKey}");
    httpClient.DefaultRequestHeaders.Add("user-agent", gitHubSettings.GitHubSettings.UserAgent);
});

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapApiEndpoints();

app.Run();