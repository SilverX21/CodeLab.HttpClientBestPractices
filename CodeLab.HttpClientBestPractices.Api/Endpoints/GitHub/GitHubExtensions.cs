using CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub.V1;
using CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub.V2;
using CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub.V3;

namespace CodeLab.HttpClientBestPractices.Api.Endpoints.GitHub;

public static class GitHubExtensions
{
    public static IEndpointRouteBuilder MapGitHubEndpoints(this IEndpointRouteBuilder app)
    {
        //v1
        app.MapGetUserV1Endpoint();
        app.MapGetRepositoriesV1Endpoint();

        //v2
        app.MapGetUserV2Endpoint();
        app.MapGetRepositoriesV2Endpoint();

        //v3
        app.MapGetUserV3Endpoint();

        return app;
    }
}