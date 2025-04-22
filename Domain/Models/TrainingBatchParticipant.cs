namespace Domain.Models;

public class TrainingBatchParticipant
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User? User { get; set; }

    public int TrainingBatchId { get; set; }
    public virtual TrainingBatch? TrainingBatch { get; set; }
}