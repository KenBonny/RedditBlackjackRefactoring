using Marten;
using Wolverine.Http;

namespace WolverineMarten.Comments;

public static class GetThreadHandler
{
    [WolverineGet("/topic/{topicId}")]
    public static async Task<IResult> GetTopic(Guid topicId, IDocumentSession session)
    {
        var topic = await session.Events.AggregateStreamAsync<Thread>(topicId);
        return Results.Ok(topic);
    }
}