using Marten;
using Wolverine.Http;

namespace WolverineMarten.Comments;

public static class StartTopicHandler
{
    [WolverinePost("/topic")]
    public static async Task<IResult> PostComment(StartTopic startTopic, IDocumentSession session)
    {
        var eventStream = session.Events.StartStream<Thread>(startTopic);
        await session.SaveChangesAsync();
        return Results.Accepted($"/topic/{eventStream.Id:D}");
    }
}