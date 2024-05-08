using BearsVsaTemplate.Web.Common.Interfaces;

namespace BearsVsaTemplate.Web.Common.Domain;

public class BaseEntity
{
    public readonly List<IEventMessage> Events = [];
}