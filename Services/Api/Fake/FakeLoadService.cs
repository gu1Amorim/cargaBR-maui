using CargaBR.Models;
using CargaBR.Models.Enums;

namespace CargaBR.Services.Api.Fake;

public class FakeLoadService : ILoadService
{
    private readonly List<Load> _loads =
    [
        new Load
        {
            Id = 1,
            Description = "Alimentos Não Perecíveis",
            Value = 9200m,
            OriginCity = "Campinas - SP",
            DestinationCity = "Belo Horizonte - MG",
            WeightTons = 22,
            DistanceKm = 580,
            PickupDate = new DateTime(2026, 4, 22),
            Status = LoadStatus.Disponivel
        },
        new Load
        {
            Id = 2,
            Description = "Equipamentos Industriais",
            Value = 15500m,
            OriginCity = "Porto Alegre - RS",
            DestinationCity = "Curitiba - PR",
            WeightTons = 18,
            DistanceKm = 710,
            PickupDate = new DateTime(2026, 4, 25),
            Status = LoadStatus.Disponivel
        }
    ];

    public async Task<IReadOnlyList<Load>> GetAvailableLoadsAsync()
    {
        await Task.Delay(900); // TODO: substituir por chamada HTTP real (GET /loads)
        return _loads.Where(l => l.Status == LoadStatus.Disponivel).ToList();
    }

    public async Task<Load?> GetByIdAsync(int id)
    {
        await Task.Delay(400); // TODO: substituir por chamada HTTP real (GET /loads/{id})
        return _loads.FirstOrDefault(l => l.Id == id);
    }

    public async Task<bool> AcceptLoadAsync(int loadId)
    {
        await Task.Delay(700); // TODO: substituir por chamada HTTP real (POST /loads/{id}/accept)
        var load = _loads.FirstOrDefault(l => l.Id == loadId);
        if (load is null) return false;

        load.Status = LoadStatus.Aceita;
        return true;
    }
}
