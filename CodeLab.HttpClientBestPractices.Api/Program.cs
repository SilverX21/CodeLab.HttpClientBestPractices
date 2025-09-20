using CodeLab.HttpClientBestPractices.Api.Clients;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/user", async (
    string apiKey,
    IHttpClientFactory httpClientFactory,
    CancellationToken cancellationToken
    ) =>
{
    if (string.IsNullOrEmpty(apiKey))
    {
        return Results.BadRequest("API key is required");
    }

    //we should dispose the client after use
    //when we create a client with a name, when we create the client we can pass the name to use the settings we defined before
    using var client = httpClientFactory.CreateClient("gh-client");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

    try
    {
        var response = await client.GetAsync("user", cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<object>();
            return Results.Ok(content);
        }
        else
        {
            return Results.StatusCode((int)response.StatusCode);
        }
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapGet("/userv2", async (
    string apiKey,
    GitHubClient gitHubClient,
    CancellationToken cancellationToken
    ) =>
{
    if (string.IsNullOrEmpty(apiKey))
    {
        return Results.BadRequest("API key is required");
    }

    try
    {
        var response = await gitHubClient.GetUser(apiKey, cancellationToken);

        if (response is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapGet("/repositories", async (
    string apiKey,
    IHttpClientFactory httpClientFactory,
    CancellationToken cancellationToken
    ) =>
{
    if (string.IsNullOrEmpty(apiKey))
    {
        return Results.BadRequest("API key is required");
    }

    //we should dispose the client after use
    //when we create a client with a name, when we create the client we can pass the name to use the settings we defined before
    using var client = httpClientFactory.CreateClient("gh-client");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

    try
    {
        var response = await client.GetAsync("user/repos?per_page=100&sort=created&direction=desc", cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<object>();
            return Results.Ok(content);
        }
        else
        {
            return Results.StatusCode((int)response.StatusCode);
        }
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapGet("/repositoriesv2", async (
    string apiKey,
    GitHubClient gitHubClient,
    CancellationToken cancellationToken
    ) =>
{
    if (string.IsNullOrEmpty(apiKey))
    {
        return Results.BadRequest("API key is required");
    }

    try
    {
        var response = await gitHubClient.GetRepositories(apiKey, cancellationToken);

        if (response is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(response);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();