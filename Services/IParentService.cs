using BadeePlatform.DTOs;

namespace BadeePlatform.Services
{
    public interface IParentService
    {
        public Task<ServiceResult> RegisterParentAsync(RegisterParentDTO dto);
        public Task<ServiceResult> LoginParentAsync(LoginParentDTO dto);


    }
}
