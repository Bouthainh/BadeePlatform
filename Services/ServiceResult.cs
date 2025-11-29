namespace BadeePlatform.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ParentId { get; set; }
        public string? Data { get; set; }


        public ServiceResult(bool success, string message, string parentId = null, string data = null)
        {
            Success = success;
            Message = message;
            ParentId = parentId;
            Data = data;
        }

    }
}
