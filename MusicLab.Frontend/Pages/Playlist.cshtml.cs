using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicLab.Frontend.Services.Interfaces;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.ResponseModel;
using Newtonsoft.Json;

namespace MusicLab.Frontend.Pages
{
    public class PlaylistModel : PageModel
    {
        private readonly IApiCallerService apiCallerService;
        public PlaylistResponseModel playlist;
        public List<SongResponseModel> Songs { get; set; }
        public List<SongResponseModel> FavoriteSongs { get; set; } = default!;
        public PlaylistModel(IApiCallerService apiCallerService)
        {
            this.apiCallerService = apiCallerService;
        }

        public async Task<IActionResult> OnGet(int playlistId)
        {
            var userJson = HttpContext.Session.GetString("User");
            if (!string.IsNullOrEmpty(userJson))
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var Token = HttpContext.Session.GetString("JwtToken");
                playlist = await apiCallerService.GetApi<PlaylistResponseModel>("https://localhost:7054/api/get-playlist-by-id?id=" + playlistId, Token);
                Songs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-songs-by-playlist?playlistId=" + playlistId, Token);
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
