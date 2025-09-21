namespace CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub.V3;

public static class GetUserV3Endpoint
{
    public static IEndpointRouteBuilder MapGetUserV3Endpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("user/v3", async (
            IHttpClientFactory httpClientFactory,
            CancellationToken cancellationToken
            ) =>
        {
            using var client = httpClientFactory.CreateClient("gh-client3");
            var response = await client.GetAsync("user", cancellationToken);
            var content = await response.Content.ReadFromJsonAsync<object>(cancellationToken);

            return Results.Ok(content);
        });

        return app;
    }
}