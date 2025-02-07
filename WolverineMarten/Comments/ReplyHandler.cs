using Marten;
using Wolverine.Http;

namespace WolverineMarten.Comments;

public record ReplyText(string Text)
{
    public static implicit operator string(ReplyText reply) => reply.Text;
}

public static class ReplyHandler
{
    [WolverinePost("/topic/{topicId}/reply/{replyId}")]
    public static async Task<IResult> Reply(Guid topicId, int replyId, ReplyText text, IDocumentSession session)
    {
        session.Events.Append(topicId, new Reply(0, replyId, text));
        await session.SaveChangesAsync();
        return Results.Ok();
    }
}