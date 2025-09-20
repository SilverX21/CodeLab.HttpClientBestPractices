var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

    var client = httpClientFactory.CreateClient();
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    client.DefaultRequestHeaders.Add("user-agent", "GitHub-Integration-App");

    try
    {
        var response = await client.GetAsync("https://api.github.com/user", cancellationToken);

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

    var client = httpClientFactory.CreateClient();
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    client.DefaultRequestHeaders.Add("user-agent", "GitHub-Integration-App");

    try
    {
        var response = await client.GetAsync("https://api.github.com/user/repos?sort=updated&per_page=100&sort=created&direction=desc", cancellationToken);

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

app.Run();