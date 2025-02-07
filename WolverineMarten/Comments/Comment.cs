namespace WolverineMarten.Comments;

public record Thread
{
    public Guid Id { get; init; }
    public required string Title { get; init; }
    public List<Comment> Comments { get; init; } = [];
}

public record Comment
{
    public int Id { get; init; }
    public required string Text { get; init; }
    public int? ParentId { get; init; }
    public Comment? Parent { get; init; }
    public int Upvotes { get; init; }
    public int Downvotes { get; init; }
}

public record StartTopic(string Title, string Text);

public record CloseTopic(int Id);

public record Reply(int ParentId, string Text);

public record Upvote(int Id);

public record Downvote(int Id);