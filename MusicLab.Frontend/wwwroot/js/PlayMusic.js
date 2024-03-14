$(document).ready(function () {
    $(".play-music-btn").on('click', function () {
        var itemDiv = $(this).closest(".btn-play");
        var songId = itemDiv.attr("id");
        songs.length = 0;
        ManagerSong.GetSongById(songId);
    });

    $('.main-container').on('click', '.play-music-btn-artist', function (event) {
        var songId = $(this).parent().attr('id');
        songs.length = 0;
        ManagerSong.GetSongById(songId);
    });

    $(".play-music-album-btn").on('click', function () {
        var albumId = $(this).parent().attr("id");
        songs.length = 0;
        ManagerSong.GetSongByAlbumId(albumId);
    });

    $(".play-music-artist-btn").on('click', function () {
        var artistId = $(this).parent().attr("id");
        songs.length = 0;
        ManagerSong.GetSongByArtistId(artistId);
    });

    $(".play-music-category-btn").on('click', function () {
        var categoryId = $(this).parent().attr("id");
        songs.length = 0;
        ManagerSong.GetSongByCategoryId(categoryId);
    });

    $(".play-music-playlist-btn").on('click', function () {
        var playlistId = $(this).parent().attr("id");
        var token = $(".jwt-token").val();
        songs.length = 0;
        ManagerSong.GetSongByPlaylistId(playlistId, token);
    });
    $(".play-music-favor-btn").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        songs.length = 0;
        ManagerSong.GetSongByFavorite(username, token);
    });
});

var songUrl;
var ManagerSong = {
    GetSongById: async function (id) {
        try {
            var serviceUrl = "https://localhost:7054/api/get-song-by-id?songId=" + id;
            var jsonData = await APIManager.GetAPIReturn(serviceUrl);

            var artists = '';
            await ManagerSong.GetSongUrl(jsonData.id);

            jsonData.songArtists.forEach(function (song) {
                if (song.artistId != jsonData.songArtists[jsonData.songArtists.length - 1].artistId) {
                    song.artist.name += ", ";
                }
                artists += song.artist.name;
            });

            const songList = {
                id: jsonData.id,
                title: jsonData.title,
                artist: artists,
                audioUrl: songUrl,
                cover: jsonData.image
            };
            songs.push(songList);

            loadSong(0);
            playSong();
        } catch (error) {
            window.alert(error);
        }
    },
    GetSongUrl: async function (id) {
        try {
            var serviceUrl = "https://localhost:7054/api/get-song-url?songId=" + id;
            const responseText = await APIManager.GetAPISongUrl(serviceUrl);
            songUrl = responseText;
        } catch (error) {
            window.alert(error);
        }
    },

    GetSongByAlbumId: async function (id) {
        try {
            var serviceUrl = "https://localhost:7054/api/get-songs-by-album?albumId=" + id;
            var jsonData = await APIManager.GetAPIReturn(serviceUrl);

            for (const eachsong of jsonData) {
                var artists = '';
                await ManagerSong.GetSongUrl(eachsong.id);

                eachsong.songArtists.forEach(function (song) {
                    if (song.artistId != eachsong.songArtists[eachsong.songArtists.length - 1].artistId) {
                        song.artist.name += ", ";
                    }
                    artists += song.artist.name;
                });

                const songList = {
                    id: eachsong.id,
                    title: eachsong.title,
                    artist: artists,
                    audioUrl: songUrl,
                    cover: eachsong.image
                };
                songs.push(songList);
            }

            loadSong(0);
            playSong();
        } catch (error) {
            window.alert(error);
        }
    },
    GetSongByArtistId: async function (id) {
        try {
            var serviceUrl = "https://localhost:7054/api/get-songs-by-artist?artistId=" + id;
            var jsonData = await APIManager.GetAPIReturn(serviceUrl);

            for (const eachsong of jsonData) {
                var artists = '';
                await ManagerSong.GetSongUrl(eachsong.id);

                eachsong.songArtists.forEach(function (song) {
                    if (song.artistId != eachsong.songArtists[eachsong.songArtists.length - 1].artistId) {
                        song.artist.name += ", ";
                    }
                    artists += song.artist.name;
                });

                const songList = {
                    id: eachsong.id,
                    title: eachsong.title,
                    artist: artists,
                    audioUrl: songUrl,
                    cover: eachsong.image
                };
                songs.push(songList);
            }

            loadSong(0);
            playSong();
        } catch (error) {
            window.alert(error);
        }
    },
    GetSongByCategoryId: async function (id) {
        try {
            var serviceUrl = "https://localhost:7054/api/get-songs-by-category?categoryId=" + id;
            var jsonData = await APIManager.GetAPIReturn(serviceUrl);

            for (const eachsong of jsonData) {
                var artists = '';
                await ManagerSong.GetSongUrl(eachsong.id);

                eachsong.songArtists.forEach(function (song) {
                    if (song.artistId != eachsong.songArtists[eachsong.songArtists.length - 1].artistId) {
                        song.artist.name += ", ";
                    }
                    artists += song.artist.name;
                });

                const songList = {
                    id: eachsong.id,
                    title: eachsong.title,
                    artist: artists,
                    audioUrl: songUrl,
                    cover: eachsong.image
                };
                songs.push(songList);
            }

            loadSong(0);
            playSong();
        } catch (error) {
            window.alert(error);
        }
    },
    GetSongByPlaylistId: async function (id, token) {
        try {
            var serviceUrl = "https://localhost:7054/api/get-songs-by-playlist?playlistId=" + id;
            var jsonData = await APIManagerSecurity.GetAPISecurityReturn(serviceUrl, token);

            for (const eachsong of jsonData) {
                var artists = '';
                await ManagerSong.GetSongUrl(eachsong.id);

                eachsong.songArtists.forEach(function (song) {
                    if (song.artistId != eachsong.songArtists[eachsong.songArtists.length - 1].artistId) {
                        song.artist.name += ", ";
                    }
                    artists += song.artist.name;
                });

                const songList = {
                    id: eachsong.id,
                    title: eachsong.title,
                    artist: artists,
                    audioUrl: songUrl,
                    cover: eachsong.image
                };
                songs.push(songList);
            }

            loadSong(0);
            playSong();
        } catch (error) {
            window.alert(error);
        }
    },
    GetSongByFavorite: async function (username, token) {
        try {
            var serviceUrl = "https://localhost:7054/api/get-all-favourites?username=" + username;
            var jsonData = await APIManagerSecurity.GetAPISecurityReturn(serviceUrl, token);

            for (const eachsong of jsonData) {
                var artists = '';
                await ManagerSong.GetSongUrl(eachsong.id);

                eachsong.songArtists.forEach(function (song) {
                    if (song.artistId != eachsong.songArtists[eachsong.songArtists.length - 1].artistId) {
                        song.artist.name += ", ";
                    }
                    artists += song.artist.name;
                });

                const songList = {
                    id: eachsong.id,
                    title: eachsong.title,
                    artist: artists,
                    audioUrl: songUrl,
                    cover: eachsong.image
                };
                songs.push(songList);
            }

            loadSong(0);
            playSong();
        } catch (error) {
            window.alert(error);
        }
    },
    UpdateListens: async function (songId) {

        var serviceUrl = "https://localhost:7054/api/update-number-of-listens?songId=" + songId;
        var data = {
            songId: songId
        };
        APIManager.PutAPI(serviceUrl, data, onSuccess, onFailed);
        function onSuccess(jsonData) {
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    }
}