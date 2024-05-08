namespace BearsVsaTemplate.Web.Features;

public static partial class Routes
{
    public static class Todos
    {
        private const string Prefix = "/api/todos";
        public const string GetAll = Prefix;
        public const string Create = Prefix;
        public const string GetById = Prefix + "/{Id}";
        public const string Update = GetById;
        public const string Delete = GetById;
    }
}