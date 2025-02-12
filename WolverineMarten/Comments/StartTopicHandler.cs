using Wolverine.Http;
using Wolverine.Marten;

namespace WolverineMarten.Comments;

public static class StartTopicHandler
{
    [WolverinePost("/topic")]
    public static (IResult, IStartStream) PostComment(StartTopic startTopic)
    {
        var stream = MartenOps.StartStream<Thread>(startTopic);
        return (Results.Accepted($"/topic/{stream.StreamId:D}"), stream);
    }
}