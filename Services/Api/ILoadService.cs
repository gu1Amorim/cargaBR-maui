using CargaBR.Models;

namespace CargaBR.Services.Api;

public interface ILoadService
{
    Task<IReadOnlyList<Load>> GetAvailableLoadsAsync();

    Task<Load?> GetByIdAsync(int id);

    Task<bool> AcceptLoadAsync(int loadId);
}
