namespace Sensor.Domain.Entities;

public abstract class SensorBase
{
    public Guid Id { get; set; }
    public required string DeviceName { get; set; }
    public string? Room { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
    public bool IsOnline { get; set; } = false;
    public bool IsEnabled { get; set; } = false;
}