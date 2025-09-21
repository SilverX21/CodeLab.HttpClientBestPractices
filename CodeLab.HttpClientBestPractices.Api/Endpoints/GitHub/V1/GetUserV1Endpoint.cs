namespace CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub.V1;

public static class GetUserV1Endpoint
{
    public static IEndpointRouteBuilder MapGetUserV1Endpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/user/v1", async (
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

        return app;
    }
}