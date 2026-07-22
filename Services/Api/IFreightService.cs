using CargaBR.Models;

namespace CargaBR.Services.Api;

public interface IFreightService
{
    Task<IReadOnlyList<Freight>> GetMyFreightsAsync();
}
