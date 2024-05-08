using System.Runtime.InteropServices.JavaScript;
using Immediate.Handlers.Shared;

namespace BearsVsaTemplate.Web.Features.Todos.Endpoints.Create;

[Handler]
public static partial class Create
{
    public record Command(string Content);

    public record Response;

    private static async ValueTask<Response> HandleAsync(
        Command request,
        CancellationToken cancellationToken)
    {
        
        return new Response();
    }
}