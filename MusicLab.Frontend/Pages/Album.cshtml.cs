using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicLab.Frontend.Services.Interfaces;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.ResponseModel;
using Newtonsoft.Json;

namespace MusicLab.Frontend.Pages
{
    public class AlbumModel : PageModel
    {
        private readonly IApiCallerService apiCallerService;
        public AlbumResponseModel Album { get; set; }
        public List<SongResponseModel> Songs { get; set; }

        public List<SongResponseModel> FavoriteSongs { get; set; } = default!;
        public List<AlbumResponseModel> ListAlbums { get; set; }

        public AlbumModel(IApiCallerService apiCallerService)
        {
            this.apiCallerService = apiCallerService;
        }
        public async Task<IActionResult> OnGet(int albumId)
        {
            Album = await apiCallerService.GetApi<AlbumResponseModel>("https://localhost:7054/api/get-album-by-id?albumId=" + albumId, null);
            Songs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-songs-by-album?albumId=" + albumId, null);
            ListAlbums = await apiCallerService.GetApi<List<AlbumResponseModel>>("https://localhost:7054/api/get-album-by-artistid?artistId=" + Album.Artist.Id, null);
            var userJson = HttpContext.Session.GetString("User");
            if (!string.IsNullOrEmpty(userJson))
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var Token = HttpContext.Session.GetString("JwtToken");
                FavoriteSongs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-all-favourites?username=" + user.Username, Token);

            }
            return Page();
        }
        public string GetFormattedTime(long durationInSeconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(durationInSeconds);
            return $"{(int)timeSpan.TotalMinutes}:{timeSpan.Seconds:D2}";
        }
    }
}
