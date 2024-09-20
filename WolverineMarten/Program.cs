using Oakton;
using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();
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