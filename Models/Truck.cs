using CargaBR.Models.Enums;

namespace CargaBR.Models;

public class Truck
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Plate { get; set; } = string.Empty;
    public string TrailerPlate { get; set; } = string.Empty;
    public TruckSize Size { get; set; }
}
