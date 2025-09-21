using CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub;

namespace CodeLab.HttpClientBestPractices.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGitHubEndpoints();
        return app;
    }
}