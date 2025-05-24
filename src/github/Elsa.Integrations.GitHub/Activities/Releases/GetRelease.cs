using Elsa.Integrations.GitHub.Activities;
using Elsa.Workflows;
using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using JetBrains.Annotations;
using Octokit;

namespace Elsa.Integrations.GitHub.Activities.Releases;

/// <summary>
/// Retrieves details of a specific release from a GitHub repository.
/// </summary>
[Activity(
    "Elsa.GitHub.Releases",
    "GitHub Releases",
    "Retrieves details of a specific release from a GitHub repository.",
    DisplayName = "Get Release")]
[UsedImplicitly]
public class GetRelease : GitHubActivity
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
    /// The release ID.
    /// </summary>
    [Input(Description = "The release ID.")]
    public Input<int> ReleaseId { get; set; } = default!;

    /// <summary>
    /// The retrieved release.
    /// </summary>
    [Output(Description = "The retrieved release.")]
    public Output<Release> RetrievedRelease { get; set; } = default!;

    /// <summary>
    /// Executes the activity.
    /// </summary>
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var owner = context.Get(Owner)!;
        var repository = context.Get(Repository)!;
        var releaseId = context.Get(ReleaseId);

        var client = GetClient(context);
        var release = await client.Repository.Release.Get(owner, repository, releaseId);

        context.Set(RetrievedRelease, release);
    }
}