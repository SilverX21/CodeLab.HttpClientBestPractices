using CodeLab.HttpClientBestPractices.Api.Contracts;
using CodeLab.HttpClientBestPractices.Api.Helpers.Refit;

namespace CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub.V4;

public static class UpdateBioV4Endpoint
{
    public static IEndpointRouteBuilder MapUpdateBioV4Endpoint(this IEndpointRouteBuilder app)
    {
        app.MapPatch("user/v4/bio", async (
            UpdateBioRequest request,
            IGitHubApi gitHubService,
            CancellationToken cancellationToken
            ) =>
        {
            var response = await gitHubService.UpdateBioAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            return Results.Ok(response);
        });
        return app;
    }
}