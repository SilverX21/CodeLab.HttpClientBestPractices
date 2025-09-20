using System.Text.Json.Serialization;

namespace CodeLab.HttpClientBestPractices.Api.Contracts;

public class GitHubRepositoryResponse
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("full_name")]
    public string FullName { get; init; } = string.Empty;

    [JsonPropertyName("private")]
    public bool IsPrivate { get; init; }

    [JsonPropertyName("owner")]
    public OwnerResponse Owner { get; init; } = new();

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("fork")]
    public bool IsFork { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }

    [JsonPropertyName("pushed_at")]
    public DateTime PushedAt { get; init; }

    [JsonPropertyName("git_url")]
    public string GitUrl { get; init; } = string.Empty;

    [JsonPropertyName("ssh_url")]
    public string SshUrl { get; init; } = string.Empty;

    [JsonPropertyName("clone_url")]
    public string CloneUrl { get; init; } = string.Empty;

    [JsonPropertyName("svn_url")]
    public string SvnUrl { get; init; } = string.Empty;

    [JsonPropertyName("homepage")]
    public string? Homepage { get; init; }

    [JsonPropertyName("size")]
    public int Size { get; init; }

    [JsonPropertyName("stargazers_count")]
    public int StargazersCount { get; init; }

    [JsonPropertyName("watchers_count")]
    public int WatchersCount { get; init; }

    [JsonPropertyName("language")]
    public string? Language { get; init; }

    [JsonPropertyName("has_issues")]
    public bool HasIssues { get; init; }

    [JsonPropertyName("has_projects")]
    public bool HasProjects { get; init; }

    [JsonPropertyName("has_downloads")]
    public bool HasDownloads { get; init; }

    [JsonPropertyName("has_wiki")]
    public bool HasWiki { get; init; }

    [JsonPropertyName("has_pages")]
    public bool HasPages { get; init; }

    [JsonPropertyName("has_discussions")]
    public bool HasDiscussions { get; init; }

    [JsonPropertyName("forks_count")]
    public int ForksCount { get; init; }

    [JsonPropertyName("archived")]
    public bool IsArchived { get; init; }

    [JsonPropertyName("disabled")]
    public bool IsDisabled { get; init; }

    [JsonPropertyName("open_issues_count")]
    public int OpenIssuesCount { get; init; }

    [JsonPropertyName("license")]
    public LicenseResponse? License { get; init; }

    [JsonPropertyName("allow_forking")]
    public bool AllowForking { get; init; }

    [JsonPropertyName("is_template")]
    public bool IsTemplate { get; init; }

    [JsonPropertyName("web_commit_signoff_required")]
    public bool WebCommitSignoffRequired { get; init; }

    [JsonPropertyName("topics")]
    public List<string> Topics { get; init; } = [];

    [JsonPropertyName("visibility")]
    public string Visibility { get; init; } = string.Empty;

    [JsonPropertyName("default_branch")]
    public string DefaultBranch { get; init; } = string.Empty;

    [JsonPropertyName("permissions")]
    public PermissionsResponse Permissions { get; init; } = new();
}

/// <summary>
/// Represents the owner of a GitHub repository.
/// </summary>
public class OwnerResponse
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

    [JsonPropertyName("site_admin")]
    public bool IsSiteAdmin { get; init; }
}

/// <summary>
/// Represents the license information for a GitHub repository.
/// </summary>
public class LicenseResponse
{
    [JsonPropertyName("key")]
    public string Key { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("spdx_id")]
    public string SpdxId { get; init; } = string.Empty;

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = string.Empty;
}

/// <summary>
/// Represents the user's permissions for a GitHub repository.
/// </summary>
public class PermissionsResponse
{
    [JsonPropertyName("admin")]
    public bool IsAdmin { get; init; }

    [JsonPropertyName("maintain")]
    public bool HasMaintain { get; init; }

    [JsonPropertyName("push")]
    public bool HasPush { get; init; }

    [JsonPropertyName("triage")]
    public bool HasTriage { get; init; }

    [JsonPropertyName("pull")]
    public bool HasPull { get; init; }
}