using CodeLab.HttpClientBestPractices.Api.Contracts;
using Refit;

namespace CodeLab.HttpClientBestPractices.Api.Helpers.Refit;

public interface IGitHubApi
{
    //here we are defining a refit endpoint
    //the {username} in the endpoint will be replace by the username param in the signature
    [Get("/users/{username}")]
    Task<GitHubUserResponse> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);

    //here we are setting a body attribute so we can send a body to the request
    [Patch("/user")]
    Task<HttpResponseMessage> UpdateBioAsync([Body] UpdateBioRequest request, CancellationToken cancellationToken = default);
}