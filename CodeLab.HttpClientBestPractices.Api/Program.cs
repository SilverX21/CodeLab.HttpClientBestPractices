using CodeLab.HttpClientBestPractices.Api.Clients;
using CodeLab.HttpClientBestPractices.Api.Endpoints;
using CodeLab.HttpClientBestPractices.Api.Helpers;
using CodeLab.HttpClientBestPractices.Api.Helpers.Refit;
using CodeLab.HttpClientBestPractices.Api.Models;
using Microsoft.Extensions.Options;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<HttpClientBestPracticesOptions>()
    .Bind(builder.Configuration)
    .ValidateDataAnnotations()
    .ValidateOnStart();

//here we need to add our delegating handler to use it in the requests and in the middleware
builder.Services.AddTransient<GitHubAuthenticationHandler>();

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
//this part here is adding resiliency to our http client, this here we can configure it as we wish
//.AddStandardResilienceHandler(); //this one is will configure the same way, but with Microsoft recomendations
//.AddResilienceHandler("custom", pipeline =>
//{
//    pipeline.AddRetry(new HttpRetryStrategyOptions
//    {
//        MaxRetryAttempts = 3, //here we are setting the max number of retries for a request
//        BackoffType = DelayBackoffType.Exponential, //this here will take even more time from one retry to another so the service can recover
//        UseJitter = true,
//        Delay = TimeSpan.FromMilliseconds(500)
//    });

//    pipeline.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
//    {
//        SamplingDuration = TimeSpan.FromSeconds(10),
//        FailureRatio = 0.9,
//        MinimumThroughput = 5,
//        BreakDuration = TimeSpan.FromSeconds(5),
//    });

//    pipeline.AddTimeout(TimeSpan.FromSeconds(1)); //here we define the timout, after 1 second it will timeout the call
//});

//we can up this with some configurations
//we are using the IOptions pattern to get the settings from configuration
builder.Services.AddHttpClient("gh-client3", (serviceProvider, httpClient) =>
{
    var gitHubSettings = serviceProvider.GetRequiredService<IOptions<HttpClientBestPracticesOptions>>().Value;

    httpClient.BaseAddress = new Uri(gitHubSettings.GitHubSettings.BaseUrl);
})
.AddHttpMessageHandler<GitHubAuthenticationHandler>(); //here we use the delegating handler to add the request headers that we need for our requests

//here we inject the refit client to our application
//we can basically pass the same that we defined in our HttpClient to configure it
builder.Services.AddRefitClient<IGitHubApi>()
    .ConfigureHttpClient((serviceProvider, httpClient) =>
    {
        var gitHubSettings = serviceProvider.GetRequiredService<IOptions<HttpClientBestPracticesOptions>>().Value;

        httpClient.BaseAddress = new Uri(gitHubSettings.GitHubSettings.BaseUrl);
    })
    .AddHttpMessageHandler<GitHubAuthenticationHandler>(); //we can also use it in refit because it uses HttpClient under the hood

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