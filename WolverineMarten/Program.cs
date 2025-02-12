using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Oakton;
using Weasel.Core;
using Wolverine;
using Wolverine.Http;
using Wolverine.Marten;
using WolverineMarten.Comments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();
builder.Services.AddWolverineHttp()
    .AddMarten(
        options =>
        {
            // Establish the connection string to your Marten database
            options.Connection(builder.Configuration.GetConnectionString("Postgres")!);

            // Specify that we want to use STJ as our serializer
            options.UseSystemTextJsonForSerialization(enumStorage: EnumStorage.AsString);

            // Turn on the PostgreSQL table partitioning for
            // hot/cold storage on archived events
            options.Events.UseArchivedStreamPartitioning = true;

            // Use the *much* faster workflow for appending events
            // at the cost of *some* loss of metadata usage for
            // inline projections
            options.Events.AppendMode = EventAppendMode.Quick;

            // Little more involved, but this can reduce the number
            // of database queries necessary to process projections
            // during CQRS command handling with certain workflows
            options.Events.UseIdentityMapForAggregates = true;

            // Opts into a mode where Marten is able to rebuild single
            // stream projections faster by building one stream at a time
            // Does require new table migrations for Marten 7 users though
            options.Events.UseOptimizedProjectionRebuilds = true;

            // If we're running in development mode, let Marten just take care
            // of all necessary schema building and patching behind the scenes
            if (builder.Environment.IsDevelopment())
            {
                options.AutoCreateSchemaObjects = AutoCreate.All;
            }
            options.Projections.Add<ThreadProjection>(ProjectionLifecycle.Inline);
        })
    .UseLightweightSessions()
    .IntegrateWithWolverine();
builder.Host.UseWolverine(
    opts =>
    {
        // This middleware will apply to the HTTP
        // endpoints as well
        opts.Policies.AutoApplyTransactions();

        // Setting up the outbox on all locally handled
        // background tasks
        opts.Policies.UseDurableLocalQueues();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapWolverineEndpoints();

await app.RunOaktonCommands(args);