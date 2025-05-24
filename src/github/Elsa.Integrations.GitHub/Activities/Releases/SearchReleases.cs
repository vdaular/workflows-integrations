using Elsa.Integrations.GitHub.Activities;
using Elsa.Workflows;
using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using JetBrains.Annotations;
using Octokit;

namespace Elsa.Integrations.GitHub.Activities.Releases;

/// <summary>
/// Searches for releases in a GitHub repository.
/// </summary>
[Activity(
    "Elsa.GitHub.Releases",
    "GitHub Releases",
    "Searches for releases in a GitHub repository.",
    DisplayName = "Search Releases")]
[UsedImplicitly]
public class SearchReleases : GitHubActivity
{
    /// <summary>
    /// The owner of the repository.
    /// </summary>
    [Input(Description = "The owner of the repository.")]
    public Input<string> Owner { get; set; } = null!;

    /// <summary>
    /// The name of the repository.
    /// </summary>
    [Input(Description = "The name of the repository.")]
    public Input<string> Repository { get; set; } = null!;

    /// <summary>
    /// The page number to retrieve.
    /// </summary>
    [Input(Description = "The page number to retrieve.")]
    public Input<int?> Page { get; set; } = default!;

    /// <summary>
    /// The number of records per page.
    /// </summary>
    [Input(Description = "The number of records per page.")]
    public Input<int?> PageSize { get; set; } = default!;

    /// <summary>
    /// The retrieved releases.
    /// </summary>
    [Output(Description = "The retrieved releases.")]
    public Output<IReadOnlyList<Release>> Releases { get; set; } = default!;

    /// <summary>
    /// Executes the activity.
    /// </summary>
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var owner = context.Get(Owner)!;
        var repository = context.Get(Repository)!;
        var page = context.Get(Page);
        var pageSize = context.Get(PageSize);

        var client = GetClient(context);
        
        // Set the page and page size if provided
        var options = new ApiOptions();
        if (page.HasValue)
            options.StartPage = page.Value;

        if (pageSize.HasValue)
            options.PageSize = pageSize.Value;

        var releases = await client.Repository.Release.GetAll(owner, repository, options);
        context.Set(Releases, releases);
    }
}