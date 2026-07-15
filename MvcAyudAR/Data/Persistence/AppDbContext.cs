using Microsoft.EntityFrameworkCore;
using MvcAyudAR.Models;

namespace MvcAyudAR.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<UserChat> UserChats { get; set; }
    public DbSet<UserType> UserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FullName).IsRequired().HasColumnType("varchar(50)");
            entity.Property(e => e.Dni).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.BirthDate).IsRequired();
            entity.Property(e => e.Email).IsRequired().HasColumnType("varchar(50)");
            entity.Property(e => e.UserTypeId).IsRequired();
            entity.Property(e => e.Phone).IsRequired();

            entity.HasMany(e => e.Publications)
                .WithOne(e => e.Publisher)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.UserChats)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.UserType)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.UserTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.ToTable("Publication");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired().HasColumnType("varchar(100)");
            entity.Property(e => e.Description).IsRequired().HasColumnType("varchar(200)");
            entity.Property(e => e.Photos).IsRequired();
            entity.Property(e => e.TTR).IsRequired().HasColumnType("decimal(10,2)");

            entity.HasMany(e => e.Payments)
                .WithOne(e => e.Publication)
                .HasForeignKey(e => e.PublicationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PublicationId).IsRequired();
            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(e => e.Publication)
                .WithMany(e => e.Payments)
                .HasForeignKey(e => e.PublicationId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(e => e.Donor)
                .WithMany(e => e.Payments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            
        });

        
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.ToTable("Chat");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasMany(e => e.Messages)
                .WithOne(e => e.Chat)
                .HasForeignKey(e => e.ChatId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasMany(e => e.UserChats)
                .WithOne(e => e.Chat)
                .HasForeignKey(e => e.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

        });
        
        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("Message");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.ChatId).IsRequired();
            entity.Property(e => e.Content).HasMaxLength(250);
            
            entity.HasOne(e => e.User)
                .WithMany(e => e.Messages)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
       
        modelBuilder.Entity<UserChat>(entity =>
        {
            entity.ToTable("UserChat");

            entity.HasKey(e => new { e.UserId, e.ChatId });

            entity.Property(e => e.JoinedAt).IsRequired();
        });
        
        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name);

            entity.HasData(new UserType{Id = 1,Name = "Admin"});
            
            entity.HasData(new UserType{Id = 2,Name = "User"});
            
            entity.HasData(new UserType{Id = 3,Name = "ONG"});
        });




        
    }
}