using MusicLab.Repository.Models;

namespace MusicLab.Repository
{
    public static class InitDatabase
    {
        private static MusicLabContext context = new MusicLabContext();

        public static void DummyData()
        {
            //Add artist
            if (context.Artists.Count() == 0)
            {
                context.Artists.Add(new Artist("MCK", "Nghiêm Vũ Hoàng Long (sinh ngày 2 tháng 3 năm 1999 tại Hà Nội), thường được biết đến với nghệ danh MCK, RPT MCK, Nger, hay Ngơ (khi còn theo đuổi thể loại nhạc indie) là một nam rapper, ca sĩ kiêm sáng tác nhạc người Việt Nam.", "img/artists/mck.jpg", "img/artists/mck_cover.jpg"));
                context.Artists.Add(new Artist("Đen Vâu", "Nguyễn Đức Cường, thường được biết đến với nghệ danh Đen Vâu hay Đen, là một nam rapper và nhạc sĩ người Việt Nam. Đen Vâu từng giành được giải Cống hiến và là một trong số ít nghệ sĩ thành công từ làn sóng underground và âm nhạc indie của Việt Nam.", "img/artists/den.jpg", "img/artists/den_cover.jpg"));
                context.Artists.Add(new Artist("Avicii", "Tim Bergling, được biết đến với nghệ danh Avicii, là nam nhạc sĩ, DJ, nhà sản xuất âm nhạc người Thuỵ Điển.", "img/artists/avicii.jpg", "img/artists/avicii_cover.jpg"));
                context.Artists.Add(new Artist("Olew", "O.lew là một trong những ca sĩ hiện tượng trẻ cực viral cộng đồng mạng thời gian qua. Olew tên thật là Phan Thị Thùy Linh sinh ngày 27/09/1999. Ca khúc debut Rồi ta sẽ ngắm pháo hoa cùng nhau đã gây được tiếng vang lớn và là thành công đầu tiên của cô", "img/artists/olew.jpg", "img/artists/olew_cover.jpg"));
                context.Artists.Add(new Artist("Tlinh", "Tlinh tên thật là Nguyễn Thảo Linh sinh  ngày 7 tháng 10 năm 2000. Tlinh là nữ rapper trẻ đầy tiềm năng và triển vọng của làng rap Việt Nam. Cô có tầm ảnh hưởng rất lớn đến trào lưu âm nhạc hiện đại. Tlinh sở hữu cá tính và phong cách đôc đáo không lẫn vào đâu được.", "img/artists/tlinh.jpg", "img/artists/tlinh_cover.jpg"));
                context.Artists.Add(new Artist("Bruno Mars", "Peter Gene Hernandez, được biết đến với nghệ danh Bruno Mars, là một ca sĩ-nhạc sĩ và nhà sản xuất thu âm người Mỹ. Mars lớn lên trong một gia đình nghệ sĩ ở Honolulu, Hawaii và anh đã bắt đầu ca hát từ khi còn nhỏ.", "img/artists/bruno-mars.jpg", "img/artists/bruno-mars_cover.jpeg"));
                context.Artists.Add(new Artist("Alan Walker", "Alan Olav Walker, thường được biết đến với nghệ danh Alan Walker là một nam DJ và nhà sản xuất thu âm người Anh gốc Na Uy Vào năm 2015, Alan bắt đầu trở nên nổi tiếng trên phạm vi quốc tế sau khi phát hành đĩa đơn Faded và nhận được chứng nhận bạch kim tại 14 quốc gia.", "img/artists/alan-walker.jfif", "img/artists/alan-walker_cover.jpg"));
                context.Artists.Add(new Artist("Marshmello", "Christopher Comstock, được biết đến nhiều hơn với nghệ danh Marshmello, là một nhà sản xuất nhạc dance điện tử và DJ người Mỹ.", "img/artists/marshmello.jpg", "img/artists/marshmello_cover.jpg"));
                context.Artists.Add(new Artist("Black Pink", "Blackpink là một nhóm nhạc nữ Hàn Quốc do công ty YG Entertainment thành lập và quản lý. Nhóm gồm 4 thành viên bao gồm Jisoo, Jennie, Rosé và Lisa. Blackpink chính thức ra mắt với album đĩa đơn đầu tay mang tên Square One gồm hai ca khúc Boombayah và Whistle.", "img/artists/black-pink.jpg", "img/artists/black-pink_cover.jpg"));
                context.SaveChanges();
            }

            //Add album
            if (context.Albums.Count() == 0)
            {
                context.Albums.Add(new Album("99%", DateTime.Parse("2023-03-14"), 1, "img/albums/99%.png", 2000000));
                context.Albums.Add(new Album("World of Walker", DateTime.Parse("2023-01-14"), 7, "img/albums/walker.jpg", 50000000));
                context.Albums.Add(new Album("The Spectre", DateTime.Parse("2012-01-14"), 7, "img/albums/spectre.jpg", 5000000));
                context.Albums.Add(new Album("Different World", DateTime.Parse("2023-02-14"), 7, "img/albums/different-world.jpg", 300230000));
                context.Albums.Add(new Album("24K Magic", DateTime.Parse("2016-03-01"), 6, "img/albums/24kmagic.jfif", 31500000));

                context.Albums.Add(new Album("Born Pink", DateTime.Parse("2023-03-01"), 9, "img/albums/bornpink.jpg", 20500000));
                context.Albums.Add(new Album("Kill This Love", DateTime.Parse("2020-03-01"), 9, "img/albums/killthislove.jpeg", 20500000));
                context.Albums.Add(new Album("The Lost Planet", DateTime.Parse("2015-01-01"), 6, "img/albums/lostplanet.jpg", 100000));
                context.Albums.Add(new Album("Show Của Đen", DateTime.Parse("2023-06-01"), 2, "img/albums/showcuaden.jpg", 1000000));
                context.Albums.Add(new Album("AVICII", DateTime.Parse("2023-01-01"), 3, "img/albums/avicii.jpg", 1000000));
                context.SaveChanges();
            }

            //Add user
            if (context.Users.Count() == 0)
            {
                context.Users.Add(new User("datbgfa", "123", "Ngo Manh Dat", "datbgfa@gmail.com", "img/avatar.jpg", true));
                context.SaveChanges();
            }

            //Add follow
            if (context.FollowArtists.Count() == 0)
            {
                context.FollowArtists.Add(new FollowArtist("datbgfa", 1, DateTime.Now.AddDays(-90)));
                context.FollowArtists.Add(new FollowArtist("datbgfa", 2, DateTime.Now.AddYears(-1)));
                context.FollowArtists.Add(new FollowArtist("datbgfa", 3, DateTime.Now.AddYears(-2)));
                context.SaveChanges();
            }

            //Add song
            if (context.Songs.Count() == 0)
            {
                context.Songs.Add(new Song("Chỉ một đêm nữa thôi", "ChiMotDemNuaThoi.mp3", 141, DateTime.Parse("2023-02-16"), 1, "img/songs/chi-mot-dem-nua-thoi.jpg", 1350000));
                context.Songs.Add(new Song("Anh đã ổn hơn", "AnhDaOnHon.mp3", 194, DateTime.Parse("2023-03-14"), 1, "img/songs/anh-da-on-hon.jpg", 3250000));
                context.Songs.Add(new Song("Rồi ta sẽ ngắm pháo hoa cùng nhau", "RoiTaSeNgamPhaoHoaCungNhau.mp3", 278, DateTime.Parse("2023-01-15"), null, "img/songs/roi-ta-se-ngam-phao-hoa-cung-nhau.jfif", 150300));
                context.Songs.Add(new Song("Wake Me Up", "WakeMeUp.mp3", 251, DateTime.Parse("2012-01-10"), 10, "img/songs/wake-me-up.jpg", 22000000));

                context.Songs.Add(new Song("Tại Vì Sao", "TaiViSao.mp3", 203, DateTime.Parse("2023-01-12"), 1, "img/songs/mck.png", 1000000));
                context.Songs.Add(new Song("Thôi Em Đừng Đi", "ThoiEmDungDi.mp3", 173, DateTime.Parse("2023-01-10"), 1, "img/songs/mck.png", 10000));
                context.Songs.Add(new Song("Va Vào Giai Điệu Này", "VaVaoGiaiDieuNay.mp3", 190, DateTime.Parse("2023-01-14"), 1, "img/songs/mck.png", 10000));
                context.Songs.Add(new Song("Ai Mới Là Kẻ Xấu Xa", "AiMoiLaKeXauXa.mp3", 192, DateTime.Parse("2023-01-13"), 1, "img/songs/mck.png", 1000));
                
                context.Songs.Add(new Song("Alone", "Alone.mp3", 163, DateTime.Parse("2012-01-10"), 2, "img/songs/alanwalker.jpg", 25000000));
                context.Songs.Add(new Song("Darkside", "Darkside.mp3", 237, DateTime.Parse("2015-01-10"), 2, "img/songs/alanwalker.jpg", 27000000));
                context.Songs.Add(new Song("Faded", "Faded.mp3", 212, DateTime.Parse("2015-01-10"), 2, "img/songs/alanwalker.jpg", 1000000000));
                context.Songs.Add(new Song("On My Way", "OnMyWay.mp3", 217, DateTime.Parse("2022-01-10"), 4, "img/songs/alanwalker.jpg", 2000000));
                
                context.Songs.Add(new Song("The Spectre", "TheSpectre.mp3", 206, DateTime.Parse("2012-05-10"), 2, "img/songs/alanwalker.jpg", 2000000));
                context.Songs.Add(new Song("DDU-DU-DDU-DU", "DDU-DU-DDU-DU.mp3", 78, DateTime.Parse("2015-03-20"), 6, "img/songs/blackpink.jpg", 15000000));
                context.Songs.Add(new Song("Kill This Love", "KillThisLove.mp3", 193, DateTime.Parse("2022-06-16"), 6, "img/songs/blackpink.jpg", 18000000));
                context.Songs.Add(new Song("Happier", "Happier.mp3", 234, DateTime.Parse("2019-07-08"), null, "img/songs/marshmello.jpg", 250000));
                
                context.Songs.Add(new Song("Wolves", "Wolves.mp3", 213, DateTime.Parse("2023-02-12"), null, "img/songs/marshmello.jpg", 5000000));
                context.Songs.Add(new Song("Leave The Door Open", "LeaveTheDoorOpen.mp3", 248, DateTime.Parse("2015-08-16"), 5, "img/songs/brunomars.jfif", 820000));
                context.Songs.Add(new Song("The Lazy Song", "TheLazySong.mp3", 199, DateTime.Parse("2016-01-01"), 5, "img/songs/brunomars.jfif", 300000));
                context.Songs.Add(new Song("Talking To The Moon", "TalkingToTheMoon.mp3", 215, DateTime.Parse("2015-03-08"), 5, "img/songs/brunomars.jfif", 900000));

                context.Songs.Add(new Song("Đưa Nhau Đi Trốn", "DuaNhauDiTron.mp3", 241, DateTime.Parse("2015-02-13"), 9, "img/songs/den.jpg", 3200000));
                context.Songs.Add(new Song("Bài Này Chill Phết", "BaiNayChillPhet.mp3", 273, DateTime.Parse("2023-04-26"), 9, "img/songs/den.jpg", 1600000));

                context.SaveChanges();
            }

            //Add category
            if (context.Categories.Count() == 0)
            {
                context.Categories.Add(new Category("Rap", "Rap là một hình thức nghệ thuật trong văn hóa hip hop xuất phát từ Âu Mỹ và được đặc trưng bằng việc trình diễn thông qua việc nói hoặc hô vang lời bài hát, ca từ một cách có vần điệu, kết hợp với động tác nhảy nhót, tạo hình.", true, "img/categories/rap.jpg"));
                context.Categories.Add(new Category("Pop", "Nhạc pop là một thể loại của nhạc đương đại và rất phổ biến trong làng nhạc đại chúng. Nhạc pop khởi đầu từ thập niên 1950 và có nguồn gốc từ dòng nhạc rock and roll.", true, "img/categories/pop.jpg"));
                context.Categories.Add(new Category("K-Pop", "K-pop, viết tắt của cụm từ tiếng Anh Korean popular music tức nhạc pop tiếng Hàn hay nhạc pop Hàn Quốc, là một thể loại âm nhạc bắt nguồn từ Hàn Quốc như một phần của văn hóa Hàn Quốc.", true, "img/categories/kpop.jpg"));
                context.Categories.Add(new Category("Indie", "Nhạc indie là nhạc được sản xuất độc lập mà không có sự can thiệp của các hãng đĩa thương mại hoặc các chi nhánh của họ, loại nhạc này có thể thực hiện bằng hình thức DIY để thu âm và xuất bản.", true, "img/categories/indie.jpg"));
                context.Categories.Add(new Category("EDM", "Nhạc nhảy điện tử được mô tả như một thể loại nhạc có tiết tấu mạnh kế thừa từ nhạc disco của những năm 1970 và ở một vài khía cạnh nào đó, nó cũng là những thể nghiệm của nhạc Pop.", true, "img/categories/edm.jpg"));
                context.Categories.Add(new Category("Top 10 Billboard", "Top 10 bài hát hot nhất trên bảng xếp hạng.", false, "img/categories/billboard.jpg"));
                context.Categories.Add(new Category("Trending Songs", "Những bài hát mới nhất và nhiều lượt nghe nhất.", false, "img/categories/trending.jpg"));
                context.SaveChanges();
            }

            //Add song category
            if (context.SongCategories.Count() == 0)
            {
                context.SongCategories.Add(new SongCategory(1, 1, DateTime.Now));
                context.SongCategories.Add(new SongCategory(2, 1, DateTime.Now));
                context.SongCategories.Add(new SongCategory(3, 2, DateTime.Now));
                context.SongCategories.Add(new SongCategory(3, 4, DateTime.Now));
                context.SongCategories.Add(new SongCategory(4, 5, DateTime.Now));

                context.SongCategories.Add(new SongCategory(5, 1, DateTime.Now));
                context.SongCategories.Add(new SongCategory(6, 1, DateTime.Now));
                context.SongCategories.Add(new SongCategory(7, 1, DateTime.Now));
                context.SongCategories.Add(new SongCategory(8, 1, DateTime.Now));

                context.SongCategories.Add(new SongCategory(9, 5, DateTime.Now));
                context.SongCategories.Add(new SongCategory(10, 5, DateTime.Now));
                context.SongCategories.Add(new SongCategory(11, 5, DateTime.Now));
                context.SongCategories.Add(new SongCategory(12, 5, DateTime.Now));

                context.SongCategories.Add(new SongCategory(13, 5, DateTime.Now));
                context.SongCategories.Add(new SongCategory(14, 3, DateTime.Now));
                context.SongCategories.Add(new SongCategory(15, 3, DateTime.Now));
                context.SongCategories.Add(new SongCategory(16, 2, DateTime.Now));
                context.SongCategories.Add(new SongCategory(16, 5, DateTime.Now));

                context.SongCategories.Add(new SongCategory(17, 2, DateTime.Now));
                context.SongCategories.Add(new SongCategory(17, 5, DateTime.Now));
                context.SongCategories.Add(new SongCategory(18, 2, DateTime.Now));
                context.SongCategories.Add(new SongCategory(19, 2, DateTime.Now));
                context.SongCategories.Add(new SongCategory(20, 2, DateTime.Now));

                context.SongCategories.Add(new SongCategory(21, 4, DateTime.Now));
                context.SongCategories.Add(new SongCategory(22, 4, DateTime.Now));
                context.SongCategories.Add(new SongCategory(21, 2, DateTime.Now));
                context.SongCategories.Add(new SongCategory(22, 2, DateTime.Now));

                context.SongCategories.Add(new SongCategory(4, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(9, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(10, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(11, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(12, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(13, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(15, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(16, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(18, 6, DateTime.Now));
                context.SongCategories.Add(new SongCategory(20, 6, DateTime.Now));

                context.SongCategories.Add(new SongCategory(2, 7, DateTime.Now));
                context.SongCategories.Add(new SongCategory(5, 7, DateTime.Now));
                context.SongCategories.Add(new SongCategory(6, 7, DateTime.Now));
                context.SongCategories.Add(new SongCategory(15, 7, DateTime.Now));
                context.SongCategories.Add(new SongCategory(12, 7, DateTime.Now));
                context.SongCategories.Add(new SongCategory(20, 7, DateTime.Now));
                context.SongCategories.Add(new SongCategory(22, 7, DateTime.Now));
                context.SongCategories.Add(new SongCategory(19, 7, DateTime.Now));
                context.SongCategories.Add(new SongCategory(10, 7, DateTime.Now));
                context.SaveChanges();
            }

            //Add favourite
            if (context.Favourites.Count() == 0)
            {
                context.Favourites.Add(new Favourite("datbgfa", 1, DateTime.Now));
                context.Favourites.Add(new Favourite("datbgfa", 4, DateTime.Now));
                context.Favourites.Add(new Favourite("datbgfa", 9, DateTime.Now));
                context.Favourites.Add(new Favourite("datbgfa", 10, DateTime.Now));
                context.Favourites.Add(new Favourite("datbgfa", 11, DateTime.Now));
                context.Favourites.Add(new Favourite("datbgfa", 12, DateTime.Now));
                context.SaveChanges();
            }

            //Add playlist
            if (context.Playlists.Count() == 0)
            {
                context.Playlists.Add(new Playlist("My first playlist", "datbgfa", DateTime.Now));
                context.Playlists.Add(new Playlist("Chill playlist", "datbgfa", DateTime.Now));
                context.SaveChanges();
            }

            //Add playlist song
            if (context.PlaylistSongs.Count() == 0)
            {
                context.PlaylistSongs.Add(new PlaylistSong(1, 1, DateTime.Now));
                context.PlaylistSongs.Add(new PlaylistSong(1, 2, DateTime.Now));
                context.PlaylistSongs.Add(new PlaylistSong(1, 3, DateTime.Now));
                context.PlaylistSongs.Add(new PlaylistSong(1, 4, DateTime.Now));
                context.PlaylistSongs.Add(new PlaylistSong(1, 10, DateTime.Now));
                context.PlaylistSongs.Add(new PlaylistSong(1, 12, DateTime.Now));
                context.PlaylistSongs.Add(new PlaylistSong(1, 14, DateTime.Now));
                context.PlaylistSongs.Add(new PlaylistSong(1, 15, DateTime.Now));
                context.PlaylistSongs.Add(new PlaylistSong(2, 2, DateTime.Now));
                context.SaveChanges();
            }

            //Add play history
            if (context.PlayHistories.Count() == 0)
            {
                context.PlayHistories.Add(new PlayHistory("datbgfa", 1, DateTime.Now.AddDays(-20), 0));
                context.PlayHistories.Add(new PlayHistory("datbgfa", 2, DateTime.Now.AddDays(-2), 0));
                context.PlayHistories.Add(new PlayHistory("datbgfa", 3, DateTime.Now.AddDays(-14), 0));
                context.PlayHistories.Add(new PlayHistory("datbgfa", 5, DateTime.Now.AddDays(-30), 0));
                context.PlayHistories.Add(new PlayHistory("datbgfa", 9, DateTime.Now.AddDays(-3), 0));
                context.PlayHistories.Add(new PlayHistory("datbgfa", 10, DateTime.Now.AddDays(-5), 0));
                context.PlayHistories.Add(new PlayHistory("datbgfa", 11, DateTime.Now.AddDays(-50), 0));
                context.SaveChanges();
            }

            //Add song artist
            if (context.SongArtists.Count() == 0)
            {
                context.SongArtists.Add(new SongArtist(1, 1, DateTime.Now));
                context.SongArtists.Add(new SongArtist(1, 2, DateTime.Now));
                context.SongArtists.Add(new SongArtist(1, 5, DateTime.Now));
                context.SongArtists.Add(new SongArtist(1, 6, DateTime.Now));
                context.SongArtists.Add(new SongArtist(1, 7, DateTime.Now));
                context.SongArtists.Add(new SongArtist(1, 8, DateTime.Now));

                context.SongArtists.Add(new SongArtist(2, 21, DateTime.Now));
                context.SongArtists.Add(new SongArtist(2, 22, DateTime.Now));

                context.SongArtists.Add(new SongArtist(3, 4, DateTime.Now));

                context.SongArtists.Add(new SongArtist(4, 3, DateTime.Now));
                context.SongArtists.Add(new SongArtist(5, 1, DateTime.Now));

                context.SongArtists.Add(new SongArtist(6, 18, DateTime.Now));
                context.SongArtists.Add(new SongArtist(6, 19, DateTime.Now));
                context.SongArtists.Add(new SongArtist(6, 20, DateTime.Now));

                context.SongArtists.Add(new SongArtist(7, 9, DateTime.Now));
                context.SongArtists.Add(new SongArtist(7, 10, DateTime.Now));
                context.SongArtists.Add(new SongArtist(7, 11, DateTime.Now));
                context.SongArtists.Add(new SongArtist(7, 12, DateTime.Now));
                context.SongArtists.Add(new SongArtist(7, 13, DateTime.Now));

                context.SongArtists.Add(new SongArtist(8, 16, DateTime.Now));
                context.SongArtists.Add(new SongArtist(8, 17, DateTime.Now));
                context.SongArtists.Add(new SongArtist(9, 14, DateTime.Now));
                context.SongArtists.Add(new SongArtist(9, 15, DateTime.Now));
                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }

    //function secondsToMinutesText(seconds) {
//    const minutes = Math.floor(seconds / 60);
//    const remainingSeconds = seconds % 60;

//    const minutesText = minutes > 0 ? `${minutes
//}
//minute${ minutes !== 1 ? 's' : ''}` : '';
//const secondsText = remainingSeconds > 0 ? `${remainingSeconds} second${ remainingSeconds !== 1 ? 's' : ''}` : '';

//return `${ minutesText} ${ secondsText}`.trim();
//}
}
