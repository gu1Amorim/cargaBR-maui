using CargaBR.Models;
using CargaBR.Models.Enums;

namespace CargaBR.Services.Api.Fake;

public class FakeFreightService : IFreightService
{
    private readonly List<Freight> _freights =
    [
        new Freight
        {
            Id = 1,
            Description = "Grãos",
            Value = 8500m,
            OriginCity = "Curitiba - PR",
            DestinationCity = "São Paulo - SP",
            WeightTons = 25,
            PeriodStart = new DateOnly(2026, 4, 15),
            PeriodEnd = new DateOnly(2026, 4, 17),
            Status = FreightStatus.Concluido
        },
        new Freight
        {
            Id = 2,
            Description = "Fertilizantes",
            Value = 12300m,
            OriginCity = "Santos - SP",
            DestinationCity = "Goiânia - GO",
            WeightTons = 20,
            PeriodStart = new DateOnly(2026, 4, 5),
            PeriodEnd = new DateOnly(2026, 4, 8),
            Status = FreightStatus.Concluido
        }
    ];

    public async Task<IReadOnlyList<Freight>> GetMyFreightsAsync()
    {
        await Task.Delay(900); // TODO: substituir por chamada HTTP real (GET /freights/me)
        return _freights;
    }
}
