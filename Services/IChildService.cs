namespace BadeePlatform.Services
{
    public interface IChildService
    {
        public Task<bool> DeleteChildProfileAsync(string parentId, string childId);
        public Task<string> GenerateUniqueLoginCodeAsync();
    }
}
