using Marten;
using Wolverine.Http;
using Wolverine.Http.Marten;

namespace WolverineMarten.Comments;

public static class GetThreadHandler
{
    [WolverineGet("/topic")]
    public static Task<IReadOnlyList<Thread>> GetTopics(IQuerySession session) => session.Query<Thread>().ToListAsync();

    [WolverineGet("/topic/{topicId}")]
    public static IResult GetTopic([Aggregate("topicId")] Thread thread) => Results.Ok(thread);
}