using Marten;
using Wolverine.Http;
using Wolverine.Http.Marten;

namespace WolverineMarten.Users;

public static class GetUser
{
    [WolverineGet("/users")]
    public static async Task<IResult> Users(IDocumentStore store, int page, int? pageSize)
    {
        await using var session = store.QuerySession();
        var pageSizeValue = pageSize ?? 5;
        var users = await session.Query<User>()
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .Skip(page * pageSizeValue)
            .Take(pageSizeValue)
            .ToListAsync();
        return Results.Ok(users);
    }

    // [WolverineGet("/users/{id:int}")]
    // public static async Task<IResult> User(int id, IDocumentStore store)
    // {
    //     await using var session = store.QuerySession();
    //     var user = await session.LoadAsync<User>(id);
    //     return user is not null ? Results.Json(user) : Results.NotFound();
    // }

    [WolverineGet("/users/{id:int}")]
    public static User User([Document] User user) => user;
}