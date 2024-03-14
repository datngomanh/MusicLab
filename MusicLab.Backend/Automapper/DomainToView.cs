using AutoMapper;
using MusicLab.Repository.Models;
using MusicLab.Repository.Models.RequestModel;
using MusicLab.Repository.Models.ResponseModel;

namespace MusicLab.Backend.Automapper
{
    public class DomainToView : Profile
    {
        public DomainToView()
        {
            CreateMap<Song, SongResponseModel>();
            CreateMap<Artist, ArtistResponseModel>();
            CreateMap<SongArtist, SongArtistResponseModel>();
            CreateMap<Album, AlbumResponseModel>();
            CreateMap<Playlist, PlaylistResponseModel>();
            CreateMap<PlaylistSong, PlaylistSongResponseModel>();

        }
    }
}
