namespace its.gamify.infras.Datas;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(its.gamify.infras.AssemblyReference.Assembly);
    }
}