using CargaBR.Models.Enums;

namespace CargaBR.Models;

public class Load
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string OriginCity { get; set; } = string.Empty;
    public string DestinationCity { get; set; } = string.Empty;
    public double WeightTons { get; set; }
    public double DistanceKm { get; set; }
    public DateTime PickupDate { get; set; }
    public LoadStatus Status { get; set; }
}
