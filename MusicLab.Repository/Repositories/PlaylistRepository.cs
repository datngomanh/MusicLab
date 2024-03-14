using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLab.Repository.Repositories
{
    public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
    {
        private readonly MusicLabContext _context;
        public PlaylistRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
