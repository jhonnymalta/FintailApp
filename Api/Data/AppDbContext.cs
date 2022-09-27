using Microsoft.EntityFrameworkCore;
using tailfinAPI.models;

namespace tailfinAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> categorias { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared");
}