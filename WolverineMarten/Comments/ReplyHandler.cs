using Wolverine.Http;
using Wolverine.Http.Marten;
using Wolverine.Marten;

namespace WolverineMarten.Comments;

public record ReplyText(string Text)
{
    public static implicit operator string(ReplyText reply) => reply.Text;
}

public static class ReplyHandler
{
    [WolverinePost("/topic/{id}/reply/{replyId}")]
    public static (IResult, Events) Reply(Guid id, int replyId, ReplyText text, [Aggregate] Thread thread)
    {
        var events = new Events();
        events.Add(new Reply(0, replyId, text));
        return (Results.Ok(), events);
    }
}