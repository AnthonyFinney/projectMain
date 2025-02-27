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
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Templates)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Forms)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Likes)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserTemplateAccesses)
            .WithOne(uta => uta.User)
            .HasForeignKey(uta => uta.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Template>()
            .HasKey(t => t.Id);

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
            .HasMany(t => t.UserTemplateAccesses)
            .WithOne(uta => uta.Template)
            .HasForeignKey(uta => uta.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Question>()
            .HasKey(q => q.Id);

        modelBuilder.Entity<Question>()
            .HasOne(q => q.Template)
            .WithMany(t => t.Questions)
            .HasForeignKey(q => q.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Form>()
            .HasKey(f => f.Id);

        modelBuilder.Entity<Form>()
            .HasMany(f => f.Answers)
            .WithOne(a => a.Form)
            .HasForeignKey(a => a.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Form>()
            .HasMany(f => f.Comments)
            .WithOne(c => c.Form)
            .HasForeignKey(c => c.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Form>()
            .HasMany(f => f.Likes)
            .WithOne(l => l.Form)
            .HasForeignKey(l => l.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Form>()
            .HasMany(f => f.FormQuestions)
            .WithOne(fq => fq.Form)
            .HasForeignKey(fq => fq.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<FormQuestion>()
            .HasKey(fq => new { fq.FormId, fq.QuestionId });

        modelBuilder.Entity<FormQuestion>()
            .HasOne(fq => fq.Form)
            .WithMany(f => f.FormQuestions)
            .HasForeignKey(fq => fq.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<FormQuestion>()
            .HasMany(fq => fq.Answers)
            .WithOne(a => a.FormQuestion)
            .HasForeignKey(a => new { a.FormId, a.QuestionId })
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Answer>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Answer>()
            .HasOne(a => a.Form)
            .WithMany(f => f.Answers)
            .HasForeignKey(a => a.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Answer>()
            .HasOne(a => a.FormQuestion)
            .WithMany(fq => fq.Answers)
            .HasForeignKey(a => new { a.FormId, a.QuestionId });

        modelBuilder.Entity<Comment>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Form)
            .WithMany(f => f.Comments)
            .HasForeignKey(c => c.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Like>()
            .HasKey(l => l.Id);

        modelBuilder.Entity<Like>()
            .HasOne(l => l.Form)
            .WithMany(f => f.Likes)
            .HasForeignKey(l => l.FormId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Like>()
            .HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserTemplateAccess>()
            .HasKey(uta => new { uta.UserId, uta.TemplateId });

        modelBuilder.Entity<UserTemplateAccess>()
            .HasOne(uta => uta.User)
            .WithMany(u => u.UserTemplateAccesses)
            .HasForeignKey(uta => uta.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserTemplateAccess>()
            .HasOne(uta => uta.Template)
            .WithMany(t => t.UserTemplateAccesses)
            .HasForeignKey(uta => uta.TemplateId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
