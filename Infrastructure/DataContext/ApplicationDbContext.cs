using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext;

public sealed class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<TrainingBatch> TrainingBatches => Set<TrainingBatch>();
    public DbSet<EvaluationSession> EvaluationSessions => Set<EvaluationSession>();
    public DbSet<EvaluationAssignment> EvaluationAssignments => Set<EvaluationAssignment>();
    public DbSet<ScoreboardEntry> ScoreboardEntries => Set<ScoreboardEntry>();
    public DbSet<TrainingBatchParticipant> TrainingBatchParticipants => Set<TrainingBatchParticipant>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Essential for Identity!
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}