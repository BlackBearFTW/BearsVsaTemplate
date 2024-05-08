using Microsoft.AspNetCore.Mvc;

namespace BearsVsaTemplate.Web.Features.Todos.Endpoints.Create;

[ApiController, Route(Routes.Todos.Create)]
public class CreateEndpoint(Create.Handler handler) : ControllerBase
{
    [HttpPost]
    public async Task<Create.Response> HandleAsync(
        [FromBody] Create.Command request,
        CancellationToken cancellationToken = new()
    ) => await handler.HandleAsync(request, cancellationToken);
}