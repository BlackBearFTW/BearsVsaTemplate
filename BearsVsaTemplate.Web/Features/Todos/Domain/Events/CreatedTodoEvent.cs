using BearsVsaTemplate.Web.Common.Interfaces;

namespace BearsVsaTemplate.Web.Features.Todos.Domain.Events;

public record CreatedTodoEvent(Guid Id, string Content) : IEventMessage;