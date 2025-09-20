using System.Text.Json.Serialization;

namespace CodeLab.HttpClientBestPractices.Api.Contracts;

public class GitHubUserResponse
{
    [JsonPropertyName("login")]
    public string Login { get; init; } = string.Empty;

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = string.Empty;

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; init; } = string.Empty;

    [JsonPropertyName("gravatar_id")]
    public string GravatarId { get; init; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = string.Empty;

    [JsonPropertyName("followers_url")]
    public string FollowersUrl { get; init; } = string.Empty;

    [JsonPropertyName("following_url")]
    public string FollowingUrl { get; init; } = string.Empty;

    [JsonPropertyName("gists_url")]
    public string GistsUrl { get; init; } = string.Empty;

    [JsonPropertyName("starred_url")]
    public string StarredUrl { get; init; } = string.Empty;

    [JsonPropertyName("subscriptions_url")]
    public string SubscriptionsUrl { get; init; } = string.Empty;

    [JsonPropertyName("organizations_url")]
    public string OrganizationsUrl { get; init; } = string.Empty;

    [JsonPropertyName("repos_url")]
    public string ReposUrl { get; init; } = string.Empty;

    [JsonPropertyName("events_url")]
    public string EventsUrl { get; init; } = string.Empty;

    [JsonPropertyName("received_events_url")]
    public string ReceivedEventsUrl { get; init; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("user_view_type")]
    public string? UserViewType { get; init; }

    [JsonPropertyName("site_admin")]
    public bool IsSiteAdmin { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("company")]
    public string? Company { get; init; }

    [JsonPropertyName("blog")]
    public string? Blog { get; init; }

    [JsonPropertyName("location")]
    public string? Location { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("hireable")]
    public bool? IsHireable { get; init; }

    [JsonPropertyName("bio")]
    public string? Bio { get; init; }

    [JsonPropertyName("twitter_username")]
    public string? TwitterUsername { get; init; }

    [JsonPropertyName("notification_email")]
    public string? NotificationEmail { get; init; }

    [JsonPropertyName("public_repos")]
    public int PublicRepos { get; init; }

    [JsonPropertyName("public_gists")]
    public int PublicGists { get; init; }

    [JsonPropertyName("followers")]
    public int Followers { get; init; }

    [JsonPropertyName("following")]
    public int Following { get; init; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }
}