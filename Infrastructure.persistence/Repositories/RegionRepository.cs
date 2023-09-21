using Application.Interfaces;
using Domain.Entities;
using Infrastructure.persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationContext _dbContext;

        public RegionRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Region?> SPSelectAsync()
        {
            var resp = _dbContext.Regions.FromSqlRaw("sp_regions_selectAll").AsEnumerable();

            return resp;
        }

        public async Task<bool> SPAddAsync(string region)
        {
            int resp = await _dbContext.Database.ExecuteSqlRawAsync($"sp_regions_create {region}");

            return resp > 0;
        }


        public async Task<bool> SPUpdateAsync(string region, int id)
        {

            int resp = await _dbContext.Database
                .ExecuteSqlRawAsync("EXEC sp_regions_update @id, @name",
                new SqlParameter("@id", id),
                new SqlParameter("@name", region));

            return resp > 0;
        }

        public async Task<bool> SPDeleteAsync(int id)
        {
            int resp = await _dbContext.Database
                .ExecuteSqlRawAsync($"EXEC sp_regions_delete @id", new SqlParameter("@id", id));

            return resp > 0;
        }
    }
}
