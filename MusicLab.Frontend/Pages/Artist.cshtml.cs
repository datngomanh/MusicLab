using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicLab.Frontend.Services.Interfaces;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.RequestModel;
using MusicLab.Repository.Models.ResponseModel;
using Newtonsoft.Json;

namespace MusicLab.Frontend.Pages
{
    public class ArtistModel : PageModel
    {
        private readonly IApiCallerService apiCallerService;

        public bool IsFollow = false;

        public int Followers;
        public int Listens;
        public ArtistResponseModel Artist;
        public List<SongResponseModel> Songs { get; set; }
        public List<SongResponseModel> FavoriteSongs { get; set; } = default!;
        public List<AlbumResponseModel> ListAlbums { get; set; } = default!;
        public IList<Artist> ListRecommendedArtists { get; set; } = default!;
        public IList<ArtistResponseModel> ListFollowArtists { get; set; } = default!;
        public ArtistModel(IApiCallerService apiCallerService)
        {
            this.apiCallerService = apiCallerService;
        }
        public async Task<IActionResult> OnGet(int artistId)
        {
            Artist = await apiCallerService.GetApi<ArtistResponseModel>("https://localhost:7054/api/get-artist-by-id?artistId=" + artistId, null);
            Songs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-songs-by-artist?artistId=" + artistId, null);
            ListAlbums = await apiCallerService.GetApi<List<AlbumResponseModel>>("https://localhost:7054/api/get-album-by-artistid?artistId=" + artistId, null);
            ListRecommendedArtists = await apiCallerService.GetApi<List<Artist>>("https://localhost:7054/api/get-recommend-artists", null);
            Followers = await apiCallerService.GetApi<int>("https://localhost:7054/api/get-follows-by-artist?artistId=" + artistId, null);
            Listens = await apiCallerService.GetApi<int>("https://localhost:7054/api/get-listens-by-artist?artistId=" + artistId, null);
            var userJson = HttpContext.Session.GetString("User");
            if (!string.IsNullOrEmpty(userJson))
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var Token = HttpContext.Session.GetString("JwtToken");
                ListFollowArtists = await apiCallerService.GetApi<List<ArtistResponseModel>>("https://localhost:7054/api/get-follow-artists?username=" + user.Username, Token);
                FavoriteSongs = await apiCallerService.GetApi<List<SongResponseModel>>("https://localhost:7054/api/get-all-favourites?username=" + user.Username, Token);
                foreach (var fl in ListFollowArtists)
                {
                    if(fl.Id == artistId)
                    {
                        IsFollow = true;
                    }
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostFollow(int artistId)
        {
            var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("User"));
            var token = HttpContext.Session.GetString("JwtToken");
            FollowArtistRequestModel entity = new FollowArtistRequestModel { Username = user.Username, ArtistId = artistId };
            var rs = await apiCallerService.PostApi("https://localhost:7054/api/follow-artist", entity, token);
            if (rs) return Page();
            else return null;
        }

        public async Task<IActionResult> OnPostUnfollow(int artistId)
        {
            var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("User"));
            var token = HttpContext.Session.GetString("JwtToken");
            var rs = await apiCallerService.DeleteApi($"https://localhost:7054/api/unfollow-artist?artistId={artistId}&username={user.Username}", token);
            if (rs) return Page();
            else return null;
        }

        public string GetFormattedTime(long durationInSeconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(durationInSeconds);
            return $"{(int)timeSpan.TotalMinutes}:{timeSpan.Seconds:D2}";
        }
    }
}
