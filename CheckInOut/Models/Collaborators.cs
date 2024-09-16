using System;

namespace CheckInOut.Models;

public class Collaborators
{
    public Collaborators()
    {
         CreatedAt = DateTime.Now;
        Id = Guid.NewGuid().ToString() ;
    }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Sector { get; set; }
    public string? Turn { get; set;}
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public DateTime CreatedAt { get; set; }
}
