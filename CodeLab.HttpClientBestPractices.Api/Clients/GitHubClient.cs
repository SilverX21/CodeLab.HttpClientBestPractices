using CodeLab.HttpClientBestPractices.Api.Contracts;

namespace CodeLab.HttpClientBestPractices.Api.Clients;

public class GitHubClient(HttpClient httpClient)
{
    public async Task<GitHubUserResponse?> GetUser(string apiKey, CancellationToken cancellationToken)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        try
        {
            var response = await httpClient.GetAsync("user", cancellationToken);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<GitHubUserResponse>();
            return content;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<object?> GetRepositories(string apiKey, CancellationToken cancellationToken)
    {
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        try
        {
            var response = await httpClient.GetAsync("user/repos?per_page=100&sort=created&direction=desc", cancellationToken);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<object>();
            return content;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}