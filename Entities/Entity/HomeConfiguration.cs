namespace Entities.Entity;

public class HomeConfiguration:IEntity
{
    public Guid Id { get; set; }
    public string? Url { get; set; }
    public string? Name { get; set; }
    public string? Icon { get; set; }
}