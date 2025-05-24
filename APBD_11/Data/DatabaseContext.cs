using Microsoft.EntityFrameworkCore;

namespace APBD_11.Data;

public class DatabaseContext : DbContext
{
    
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}