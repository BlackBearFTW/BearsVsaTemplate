using System.Runtime.InteropServices.JavaScript;
using BearsVsaTemplate.Web.Features.Todos.Domain;
using BearsVsaTemplate.Web.Features.Todos.Domain.Events;
using BearsVsaTemplate.Web.Infrastructure.Persistence;
using Immediate.Handlers.Shared;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace BearsVsaTemplate.Web.Features.Todos.Endpoints.Create;

[Handler]
public static partial class Create
{
    public record Command(string Content);

    public record Response(Guid Id);

    private static async ValueTask<Response> HandleAsync(
        Command request,
        IPublishEndpoint publisher,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        var todo = new Todo()
        {
            Content = request.Content
        };

        dbContext.Add(todo);
        await dbContext.SaveChangesAsync(cancellationToken);
        await publisher.Publish(new CreatedTodoEvent(todo.Id, todo.Content));

        return new Response(todo.Id);
    }
}