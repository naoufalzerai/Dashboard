namespace Entities.Entity;

public class CronConfiguration:IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Script { get; set; }
    public string Occurrence { get; set; }
    public int Status { get; set; }
    public Guid Id { get; set; }
}
