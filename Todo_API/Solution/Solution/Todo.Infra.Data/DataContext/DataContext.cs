using Microsoft.EntityFrameworkCore;
using Todo.Domain;

namespace Todo.Infra.Data.DataContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    public DbSet<User> Usuarios { get; set; }
}