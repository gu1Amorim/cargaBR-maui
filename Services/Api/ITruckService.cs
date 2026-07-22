using CargaBR.Models;

namespace CargaBR.Services.Api;

public interface ITruckService
{
    Task<Truck?> GetMyTruckAsync();

    Task<IReadOnlyList<Trailer>> GetTrailersAsync();

    Task<bool> AddTrailerAsync(Trailer trailer);
}
