$(document).ready(function () {
    $(".btn-follow-artist").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var artistId = $(this).attr("id");
        ManagerFollow.FollowArtist(username, artistId, token);
    });

    $(".btn-unfollow-artist").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var artistId = $(this).attr("id");
        ManagerFollow.UnFollowArtist(username, artistId, token);
    });

    $(".add-favorite-song-artist").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var songId = $(this).attr("id");
        var artistId = $(".search-favorite").attr("id");
        var page = "Artist";
        var parameter = "artistId";
        ManagerFavor.AddFavorSong(username, songId, artistId, token, page, parameter);
    });

    $(".del-favorite-song-artist").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var songId = $(this).attr("id");
        var artistId = $(".search-favorite").attr("id");
        var page = "Artist";
        var parameter = "artistId";
        ManagerFavor.DeleteFavorSong(username, songId, artistId, token,page, parameter);
    });

    $(".add-favorite-song-album").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var songId = $(this).attr("id");
        var albumId = $(".search-favorite").attr("id");
        var page = "Album";
        var parameter = "albumId";
        ManagerFavor.AddFavorSong(username, songId, albumId, token, page, parameter);
    });

    $(".del-favorite-song-album").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var songId = $(this).attr("id");
        var albumId = $(".search-favorite").attr("id");
        var page = "Album";
        var parameter = "albumId";
        ManagerFavor.DeleteFavorSong(username, songId, albumId, token, page, parameter);
    });

    $(".add-favorite-song-playlist").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var songId = $(this).attr("id");
        var playlistId = $(".search-favorite").attr("id");
        var page = "Playlist";
        var parameter = "playlistId";
        ManagerFavor.AddFavorSong(username, songId, playlistId, token, page, parameter);
    });

    $(".del-favorite-song-playlist").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var songId = $(this).attr("id");
        var playlistId = $(".search-favorite").attr("id");
        var page = "Playlist";
        var parameter = "playlistId";
        ManagerFavor.DeleteFavorSong(username, songId, playlistId, token, page, parameter);
    });

    $(".add-favorite-song-favor").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var songId = $(this).attr("id");
        ManagerFavor.AddPageFavorSong(username, songId, token);
    });

    $(".del-favorite-song-favor").on('click', function () {
        var username = $(".username-logged").val();
        var token = $(".jwt-token").val();
        var songId = $(this).attr("id");
        ManagerFavor.DeletePageFavorSong(username, songId, token);
    });
});

var ManagerFollow = {
    FollowArtist: function (username, artistId, token) {
        var serviceUrl = "https://localhost:7054/api/follow-artist";
        var data = {
            Username: username,
            ArtistId: artistId
        };
        APIManagerSecurity.PostAPISecurity(serviceUrl, token, data, onSuccess, onFailed);
        function onSuccess(jsonData) {
            loadPage("/Artist?artistId=" + artistId);
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    },
    UnFollowArtist: function (username, artistId, token) {
        var serviceUrl = "https://localhost:7054/api/unfollow-artist";
        var data = {
            Username: username,
            ArtistId: artistId
        };
        APIManagerSecurity.DeleteAPISecurity(serviceUrl, token, data, onSuccess, onFailed);
        function onSuccess(jsonData) {
            loadPage("/Artist?artistId=" + artistId);
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    }
};

var ManagerFavor = {
    GetFavorSong:async function (username, token) {
        try {
            var serviceUrl = "https://localhost:7054/api/get-all-favourites?username=" + username;
            await APIManagerSecurity.GetAPISecurityReturn(serviceUrl, token);
        } catch (error) {
            window.alert(error);
        }
    },
    AddFavorSong: async function (username, songId, pageId, token, page, parameter) {
        var serviceUrl = "https://localhost:7054/api/add-favourite";
        var data = {
            Username: username,
            SongId: songId
        };
        await APIManagerSecurity.PostAPISecurity(serviceUrl, token, data, onSuccess, onFailed);
        function onSuccess(jsonData) {

            loadPage("/" + page + "?" + parameter + "=" + pageId);
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    },
    DeleteFavorSong: async function (username, songId, pageId, token, page, parameter) {
        var serviceUrl = "https://localhost:7054/api/delete-favourite";
        var data = {
            Username: username,
            SongId: songId
        };
        await APIManagerSecurity.DeleteAPISecurity(serviceUrl, token, data, onSuccess, onFailed);
        function onSuccess(jsonData) {
          
            loadPage("/" + page + "?" + parameter + "=" + pageId);
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    },
    AddPageFavorSong: async function (username, songId, token) {
        var serviceUrl = "https://localhost:7054/api/add-favourite";
        var data = {
            Username: username,
            SongId: songId
        };
        await APIManagerSecurity.PostAPISecurity(serviceUrl, token, data, onSuccess, onFailed);
        function onSuccess(jsonData) {

            loadPage("/Favorite");
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    },
    DeletePageFavorSong: async function (username, songId, token) {
        var serviceUrl = "https://localhost:7054/api/delete-favourite";
        var data = {
            Username: username,
            SongId: songId
        };
        await APIManagerSecurity.DeleteAPISecurity(serviceUrl, token, data, onSuccess, onFailed);
        function onSuccess(jsonData) {

            loadPage("/Favorite");
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    }
};