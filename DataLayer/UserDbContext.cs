using Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public partial class UserDbContext : DbContext
{
    public UserDbContext()
    {
    }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserModel> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-EPD77HF\\SQLEXPRESS;Database=UsersDB;uid=sa;pwd=1234;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.Property(e => e.FirstName)
                .HasMaxLength(150)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(150)
                .HasColumnName("lastName");
            entity.Ignore(e => e.FullName);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
