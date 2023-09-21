using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region?> SPSelectAsync();
        Task<bool> SPAddAsync(string region);
        Task<bool> SPUpdateAsync(string region, int id);
        Task<bool> SPDeleteAsync(int id);
    }
}