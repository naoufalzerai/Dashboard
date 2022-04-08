namespace Entities.Entity;

public class SmbConfiguration:IEntity
{
    public string Address { get; set; }
    public string Username { get; set;}
    public string Password { get; set;}
    public Guid Id { get; set; }
}