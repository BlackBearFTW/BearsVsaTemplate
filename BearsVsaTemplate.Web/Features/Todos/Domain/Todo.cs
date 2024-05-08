using BearsVsaTemplate.Web.Common.Domain;
using BearsVsaTemplate.Web.Features.Todos.Domain.Events;

namespace BearsVsaTemplate.Web.Features.Todos.Domain;

public class Todo : BaseEntity
{
    public Todo()
    {
        Events.Add(new CreatedTodoEvent(Id, Content));
    }
    
    public Guid Id { get; init; }
    public string Content { get; set; }

}