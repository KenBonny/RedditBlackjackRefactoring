using Wolverine.Http;
using Wolverine.Http.Marten;

namespace WolverineMarten.Comments;

public static class VoteHandler
{
    [WolverinePost("/topic/{id}/upvote/{commentId}")]
    [EmptyResponse]
    public static Upvote Upvote(int commentId, [Aggregate] Thread thread) => new(commentId);

    [WolverinePost("/topic/{id}/downvote/{commentId}")]
    [EmptyResponse]
    public static Downvote Downvote(int commentId, [Aggregate] Thread thread) => new(commentId);
}