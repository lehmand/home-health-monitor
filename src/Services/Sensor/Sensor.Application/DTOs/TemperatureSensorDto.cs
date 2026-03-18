namespace Sensor.Application.DTOs;
public class TemperatureSensorDto
{
    public Guid Id { get; set; }
    public required string DeviceName { get; set; }
    public decimal Temperature { get; set; }
    public string? Room { get; set; }
    public string? Location { get; set; }
    public bool IsOnline { get; set; }
    public bool IsEnabled { get; set; }
}