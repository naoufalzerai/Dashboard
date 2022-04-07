namespace Entities.Model.Cron;

public class CronModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Script { get; set; }
    public string Occurrence { get; set; }
    public CronStatus Status { get; set; }
}