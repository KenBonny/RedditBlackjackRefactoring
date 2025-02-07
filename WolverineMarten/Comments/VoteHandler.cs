using Marten;
using Wolverine.Http;

namespace WolverineMarten.Comments;

public static class VoteHandler
{
    [WolverinePost("/topic/{topicId}/upvote/{commentId}")]
    [EmptyResponse]
    public static async Task Upvote(Guid topicId, int commentId, IDocumentSession session)
    {
        session.Events.Append(topicId, new Upvote(commentId));
        await session.SaveChangesAsync();
    }

    [WolverinePost("/topic/{topicId}/downvote/{commentId}")]
    [EmptyResponse]
    public static async Task Downvote(Guid topicId, int commentId, IDocumentSession session)
    {
        session.Events.Append(topicId, new Downvote(commentId));
        await session.SaveChangesAsync();
    }
}