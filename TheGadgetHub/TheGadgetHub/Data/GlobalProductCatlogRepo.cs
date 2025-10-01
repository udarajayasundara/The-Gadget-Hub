using Microsoft.EntityFrameworkCore;
using TheGadgetHub.Models;

namespace TheGadgetHub.Data
{
    public class GlobalProductCatlogRepo
    {
        private readonly AppDBContext dBContext;

        public GlobalProductCatlogRepo(AppDBContext appDBContext)
        {
            dBContext = appDBContext;
        }

        public async Task<GlobalProductCatlog?> Compare(int globalProductId)
        {
            return await dBContext.GlobalProductCatlogs.FirstOrDefaultAsync(g => g.Id == globalProductId);
        }
    }
}
