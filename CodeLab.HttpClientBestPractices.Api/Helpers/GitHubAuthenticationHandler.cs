using CodeLab.HttpClientBestPractices.Api.Models;
using Microsoft.Extensions.Options;

namespace CodeLab.HttpClientBestPractices.Api.Helpers;

//A delegating handler is like a middleware but only for the outgoing (output) http requests
public class GitHubAuthenticationHandler : DelegatingHandler
{
    private readonly HttpClientBestPracticesOptions _options;

    public GitHubAuthenticationHandler(IOptions<HttpClientBestPracticesOptions> options)
    {
        _options = options.Value;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Authorization", $"Bearer {_options.GitHubSettings.ApiKey}");
        request.Headers.Add("User-Agent", _options.GitHubSettings.UserAgent);
        request.Headers.Add("Accept", "application/vnd.github+json");

        return base.SendAsync(request, cancellationToken);
    }
}