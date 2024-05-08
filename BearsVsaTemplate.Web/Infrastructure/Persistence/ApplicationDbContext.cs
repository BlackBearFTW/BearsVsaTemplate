using BearsVsaTemplate.Web.Common.Interfaces;
using BearsVsaTemplate.Web.Features.Todos.Domain;
using Microsoft.EntityFrameworkCore;

namespace BearsVsaTemplate.Web.Infrastructure.Persistence;

public partial class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos => Set<Todo>();

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }
}