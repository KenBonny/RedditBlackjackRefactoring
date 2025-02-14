using Wolverine.Http;
using Wolverine.Http.Marten;

namespace WolverineMarten.Comments;

public static class CloseTopicHandler
{
    [WolverineDelete("/topic/{id}")]
    [EmptyResponse]
    public static CloseTopic DeleteTopic(Guid id, [Aggregate] Thread thread) => new();
}