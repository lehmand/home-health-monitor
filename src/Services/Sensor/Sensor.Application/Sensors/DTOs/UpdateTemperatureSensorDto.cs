namespace Sensor.Application.Sensors.DTOs;

public class UpdateTemperatureSensorDto
{
    public string? DeviceName { get; set; }
    public string? Room { get; set; }
    public string? Location { get; set; }
    public bool? IsEnabled { get; set; }
}