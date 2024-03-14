using MusicLab.Repository.Models;
using MusicLab.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLab.Repository.Repositories
{
    public class SongArtistRepository : BaseRepository<SongArtist>, ISongArtistRepository
    {
        private readonly MusicLabContext _context;
        public SongArtistRepository(MusicLabContext context) : base(context)
        {
            _context = context;
        }
    }
}
