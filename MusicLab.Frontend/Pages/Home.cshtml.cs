using AutoMapper.Execution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicLab.Frontend.Services.Interfaces;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.ResponseModel;
using Newtonsoft.Json;

namespace MusicLab.Frontend.Pages
{
    public class HomeModel : PageModel
    {
        private readonly IApiCallerService apiCallerService;

        public HomeModel(IApiCallerService apiCallerService)
        {
            this.apiCallerService = apiCallerService;
        }

        public IList<Playlist> ListPlaylists { get; set; } = default!;
        public IList<SongResponseModel> ListFavoriteSongs { get; set; } = default!;
        public IList<SongResponseModel> ListHistorySongs { get; set; } = default!;
        public IList<SongResponseModel> ListRecommendedSongs { get; set; } = default!;
        public IList<SongResponseModel> ListTrendingSongs { get; set; } = default!;
        public IList<AlbumResponseModel> ListRecommendedAlbums { get; set; } = default!;
        public IList<Artist> ListRecommendedArtists { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var userJson = HttpContext.Session.GetString("User");
            if (!string.IsNullOrEmpty(userJson)) {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var Token = HttpContext.Session.GetString("JwtToken");
                ListPlaylists = await apiCallerService.GetApi<List<Playlist>>("https://localhost:7054/api/get-top-6-playlists?username=" + user.Username, Token);
                ListHistorySongs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-top-6-last-played-songs?username=" + user.Username, Token);
                ListRecommendedSongs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-top-6-recommended-songs?username=" + user.Username, Token);
                ListFavoriteSongs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-all-favourites?username=" + user.Username, Token);
            }
            ListTrendingSongs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-trending-songs", null);
            ListRecommendedAlbums = await apiCallerService.GetApi<List<AlbumResponseModel>>("https://localhost:7054/api/get-recommend-albums", null);
            ListRecommendedArtists = await apiCallerService.GetApi<List<Artist>>("https://localhost:7054/api/get-recommend-artists", null);
            return Page();
        }
    }
}
