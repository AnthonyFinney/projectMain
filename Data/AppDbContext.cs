using Microsoft.EntityFrameworkCore;
using ProjectMain.Models;

namespace ProjectMain.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<UserTemplateAccess> UserTemplateAccesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Template>()
            .HasOne(t => t.User)
            .WithMany(u => u.Templates)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Template>()
            .HasMany(t => t.Questions)
            .WithOne(q => q.Template)
            .HasForeignKey(q => q.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Template>()
            .HasMany(t => t.Forms)
            .WithOne(f => f.Template)
            .HasForeignKey(f => f.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Template>()
            .HasMany(t => t.Comments)
            .WithOne(c => c.Template)
            .HasForeignKey(c => c.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Template>()
            .HasMany(t => t.Likes)
            .WithOne(l => l.Template)
            .HasForeignKey(l => l.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Template>()
            .HasMany(t => t.UserTemplateAccesses)
            .WithOne(uta => uta.Template)
            .HasForeignKey(uta => uta.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserTemplateAccess>()
            .HasKey(uta => new { uta.UserId, uta.TemplateId });

        modelBuilder.Entity<UserTemplateAccess>()
            .HasOne(uta => uta.User)
            .WithMany(u => u.UserTemplateAccesses)
            .HasForeignKey(uta => uta.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Form>()
            .HasOne(f => f.User)
            .WithMany(u => u.Forms)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Form>()
            .HasMany(f => f.Answers)
            .WithOne(a => a.Form)
            .HasForeignKey(a => a.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Answer>()
            .HasOne(a => a.Form)
            .WithMany(f => f.Answers)
            .HasForeignKey(a => a.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Like>()
            .HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Question>().HasIndex(q => q.TemplateId);
        modelBuilder.Entity<Answer>().HasIndex(a => a.FormId);
        modelBuilder.Entity<Like>().HasIndex(l => l.TemplateId);
        modelBuilder.Entity<Comment>().HasIndex(c => c.TemplateId);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }
}
