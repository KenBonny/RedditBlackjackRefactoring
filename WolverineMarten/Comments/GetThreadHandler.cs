using Wolverine.Http;
using Wolverine.Http.Marten;

namespace WolverineMarten.Comments;

public static class GetThreadHandler
{
    [WolverineGet("/topic/{topicId}")]
    public static IResult GetTopic([Aggregate("topicId")] Thread thread) => Results.Ok(thread);
}