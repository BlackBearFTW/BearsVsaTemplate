using BearsVsaTemplate.Web.Features.Todos.Domain;
using Microsoft.EntityFrameworkCore;

namespace BearsVsaTemplate.Web.Infrastructure.Persistence;

public partial class ApplicationDbContext
{
    public DbSet<Todo> Todos { get; set; }
}