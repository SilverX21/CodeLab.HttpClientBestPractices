using CodeLab.HttpClientBestPractices.Api.Helpers.Refit;

namespace CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub.V4;

public static class GetUserV4Endpoint
{
    public static IEndpointRouteBuilder MapGetUserV4Endpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("users/v4/{username}", async (
            string username,
            IGitHubApi gitHubService,
            CancellationToken cancellationToken
            ) =>
        {
            //here we only need to call the github service that is using refit
            var user = await gitHubService.GetByUsernameAsync(username, cancellationToken);

            return Results.Ok(user);
        });

        return app;
    }
}