namespace MusicLab.Backend.Services.Interfaces
{
    public interface IAWSS3Service
    {
        Task<string> GetURLAsync(string songName);
        Task<bool> UploadFileAsync(IFormFile file);
    }
}
