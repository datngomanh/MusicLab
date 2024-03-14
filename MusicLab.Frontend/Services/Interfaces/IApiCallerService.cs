namespace MusicLab.Frontend.Services.Interfaces
{
    public interface IApiCallerService
    {
        public Task<T?> GetApi<T>(string url, string jwtToken);
        public Task<bool> PostApi<T>(string url, T requestObject, string jwtToken);
        public Task<bool> PostApiFormData(string url, FormUrlEncodedContent formContent, string jwtToken);
        public Task<bool> DeleteApi(string url, string jwtToken);
        public Task<bool> PutApi<T>(string url, T objectRequest, string jwtToken);
        public Task<T?> PostApiWithReturn<T>(string url, object requestObject, string jwtToken);
    }
}
