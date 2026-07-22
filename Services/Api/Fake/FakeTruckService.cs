using CargaBR.Models;
using CargaBR.Models.Enums;

namespace CargaBR.Services.Api.Fake;

public class FakeTruckService : ITruckService
{
    private readonly Truck _truck = new()
    {
        Id = 1,
        Model = "Scania R450",
        Type = "Cavalo Mecânico",
        Plate = "ABC-1234",
        TrailerPlate = "DEF-5678",
        Size = TruckSize.Grande
    };

    private readonly List<Trailer> _trailers =
    [
        new Trailer { Id = 1, Description = "Carreta 1 - Baú", Plate = "DEF-5678" }
    ];

    public async Task<Truck?> GetMyTruckAsync()
    {
        await Task.Delay(600); // TODO: substituir por chamada HTTP real (GET /trucks/me)
        return _truck;
    }

    public async Task<IReadOnlyList<Trailer>> GetTrailersAsync()
    {
        await Task.Delay(600); // TODO: substituir por chamada HTTP real (GET /trucks/me/trailers)
        return _trailers;
    }

    public async Task<bool> AddTrailerAsync(Trailer trailer)
    {
        await Task.Delay(800); // TODO: substituir por chamada HTTP real (POST /trucks/me/trailers)
        trailer.Id = _trailers.Count + 1;
        _trailers.Add(trailer);
        return true;
    }
}
