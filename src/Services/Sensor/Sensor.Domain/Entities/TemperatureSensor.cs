namespace Sensor.Domain.Entities;

public class TemperatureSensor : SensorBase
{
    public decimal Temperature { get; set; }
    public decimal MaxTemp { get; set; }
    public decimal LowTemp { get; set; }

}