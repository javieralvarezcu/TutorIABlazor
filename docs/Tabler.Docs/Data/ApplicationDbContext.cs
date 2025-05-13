using Microsoft.EntityFrameworkCore;
using Tabler.Docs.Data;
using Tabler.Docs.Model.Auth;
using Tabler.Docs.Model.Questionnaire;

public class ApplicationDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<QuestionBase> QuestionBases { get; set; } = default!;
    public DbSet<AnswerOption> AnswerOptions { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().HasKey(x => x.Code);
        modelBuilder.Entity<Country>().OwnsOne(x => x.Medals);
        modelBuilder.Entity<QuestionBase>()
    .HasDiscriminator<string>("Discriminator")
    .HasValue<MultipleChoiceQuestion>("MultipleChoiceQuestion");

        modelBuilder.Entity<MultipleChoiceQuestion>()
            .HasMany(q => q.Options)
            .WithOne(o => o.Question)
            .HasForeignKey(o => o.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
