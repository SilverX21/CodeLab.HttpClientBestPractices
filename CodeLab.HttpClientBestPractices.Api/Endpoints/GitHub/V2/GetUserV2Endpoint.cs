using CodeLab.HttpClientBestPractices.Api.Clients;

namespace CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub.V2;

public static class GetUserV2Endpoint
{
    public static IEndpointRouteBuilder MapGetUserV2Endpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/user/v2", async (
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

        return app;
    }
}