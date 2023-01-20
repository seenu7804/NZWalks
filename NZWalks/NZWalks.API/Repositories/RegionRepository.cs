using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext nZWalkDbContext;
        public RegionRepository(NZWalkDbContext nZWalksDbContext)
        {
            this.nZWalkDbContext = nZWalksDbContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalkDbContext.Regions.ToListAsync();
        }
    }

   }
