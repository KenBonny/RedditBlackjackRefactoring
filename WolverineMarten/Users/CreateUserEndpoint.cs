using Marten;
using Microsoft.AspNetCore.Mvc;
using Wolverine.Http;

namespace WolverineMarten.Users;

public static class CreateUserEndpoint
{
    public record Request(string FirstName, string LastName);

    [WolverinePost("/users")]
    public static async Task<IResult> CreateUser(Request body, [FromServices] IDocumentStore store)
    {
        await using var session = store.LightweightSession();
        var user = new User
        {
            FirstName = body.FirstName,
            LastName = body.LastName
        };
        session.Store(user);
        await session.SaveChangesAsync();

        return Results.Created($"/users/{user.Id}", user);
    }
}