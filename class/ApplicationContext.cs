using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Store;

public class ApplicationContext : DbContext
{
    public static ApplicationContext _context;
    public static ApplicationContext GetContext()
    {
        if (_context == null)
            _context = new ApplicationContext();

        return _context;
    }

    public DbSet<User> user { get; set; } = null!;
    public DbSet<Role> role { get; set; } = null!;
    public DbSet<client> buyer { get; set; } = null!;
    public DbSet<Glasses> glasses { get; set; } = null!;
    public DbSet<Material> material_type {get; set; } = null!;
    

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    
  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=185.26.122.80;user=host1849318_moskovkin;password=qwerty123!;database=host1849318_moskovkin;",
            new MySqlServerVersion(new Version(8, 0, 25)));
    }
}
