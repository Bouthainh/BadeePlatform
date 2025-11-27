using BadeePlatform.Data;
using Microsoft.EntityFrameworkCore;

namespace BadeePlatform.Services
{
    public class ChildService : IChildService
    {
        private readonly BadeeDbContext _db;
        public ChildService(BadeeDbContext db) 
        {
            _db = db;
        }

        public async Task<bool> DeleteChildProfileAsync(string parentId, string childId)
        {

            var parentChildRecord = await _db.ParentChildren
                .FirstOrDefaultAsync(pc => pc.ParentId == parentId && pc.ChildId == childId);

            if (parentChildRecord == null)
            {
                return false;
            }

            try
            {
                _db.ParentChildren.Remove(parentChildRecord);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GenerateUniqueLoginCodeAsync()
        {
            const int codeLength = 8;
            string loginCode;
            bool isUnique;
            Random random = new Random();

            do
            {
                int min = (int)Math.Pow(10, codeLength - 1);
                int max = (int)Math.Pow(10, codeLength) - 1;

                loginCode = random.Next(min, max).ToString();

                isUnique = !await _db.Children.AnyAsync(c => c.LoginCode == loginCode);

            } while (!isUnique);

            return loginCode;
        }


    }
}
