namespace Sensor.Application.Sensors.DTOs;

public class CreateTemperatureSensorDto
{
    public required string DeviceName { get; set; }
    public string? Room { get; set; }
    public string? Location { get; set; }
    
}