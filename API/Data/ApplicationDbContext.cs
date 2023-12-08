using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
                    
public class ApplicationDbContext : DbContext
{
    public  DbSet<User>? Users { get; set; }
    public DbSet<Wallet>? Wallets { set; get; }
    public DbSet<Product>Products { set; get; }
    public DbSet<OderDetail>OderDetails { set; get; }
    public DbSet<Oder>Oders { set; get; }
    public DbSet<Department>Departments { set; get; }
    public DbSet<Employee>staffs { set; get; }
    


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OderDetail>()
            .HasMany(u => u.Products)
            .WithMany(w => w.OderDetails)
            .UsingEntity(j => j.ToTable("OderDetailProduct"));
    }
}
            