using CargaBR.Models.Enums;

namespace CargaBR.Models;

public class Freight
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string OriginCity { get; set; } = string.Empty;
    public string DestinationCity { get; set; } = string.Empty;
    public double WeightTons { get; set; }
    public DateOnly PeriodStart { get; set; }
    public DateOnly PeriodEnd { get; set; }
    public FreightStatus Status { get; set; }
}
