using System.ComponentModel.DataAnnotations;

namespace CodeLab.HttpClientBestPractices.Api.Models;

public class HttpClientBestPracticesOptions
{
    public GitHubSettings GitHubSettings { get; init; }
}

public class GitHubSettings
{
    [Required]
    public string BaseUrl { get; init; }

    [Required]
    public string ApiKey { get; init; }

    [Required]
    public string UserAgent { get; init; }
}