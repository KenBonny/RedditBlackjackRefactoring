namespace WolverineMarten.Comments;

public record Thread
{
    public Guid Id { get; init; }
    public required string Title { get; init; }
    public List<Comment> Comments { get; init; } = [];

    public static Thread Create(StartTopic start) =>
        new()
        {
            Id = Guid.NewGuid(),
            Title = start.Title,
            Comments =
            [
                new Comment
                {
                    Id = 0,
                    Text = start.Text,
                }
            ]
        };

    public static Thread Apply(Reply reply, Thread thread)
    {
        thread.Comments.Add(
            new()
            {
                Id = thread.Comments.Count,
                Text = reply.Text,
            });
        return thread;
    }

    public static Thread Apply(Upvote upvote, Thread thread)
    {
        var comment = thread.Comments.SingleOrDefault(c => c.Id == upvote.Id);
        if  (comment is not null)
            comment.Upvotes++;
        return thread;
    }

    public static Thread Apply(Downvote downvote, Thread thread)
    {
        var comment = thread.Comments.SingleOrDefault(c => c.Id == downvote.Id);
        if (comment is not null)
            comment.Downvotes++;
        return thread;
    }
}

public record Comment
{
    public int Id { get; init; }
    public required string Text { get; init; }
    public int? ParentId { get; init; }
    public Comment? Parent { get; init; }
    public int Upvotes { get; set; } = 0;
    public int Downvotes { get; set; } = 0;
}

public record StartTopic(string Title, string Text);

public record CloseTopic(int Id);

public record Reply(int Id, int ParentId, string Text);

public record Upvote(int Id);

public record Downvote(int Id);