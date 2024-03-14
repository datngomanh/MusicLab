document.getElementById("search-library").addEventListener("click", event => {
    document.getElementById("search-input").style.setProperty('display', 'block', 'important');
});

document.addEventListener("click", function (e) {
    var container = document.getElementById("search-library");
    if (!container.contains(e.target)) {
        document.getElementById("search-input").style.setProperty('display', 'none', 'important');
    }
});

$(document).ready(function () {

    $("#search-input").on('input', function () {
        var keyword = $(this).val();
        var token = $(".jwt-token").val();
        var username = $(".username-logged").val();
        console.log(keyword, token, username);
        if (keyword === null || keyword === undefined || keyword === '') {
            ManagerPlaylist.GetAllPlaylist(username, token);
        } else {
            ManagerPlaylist.GetSearchPlaylist(username, token, keyword);
        }

    });
});

var ManagerPlaylist = {
    GetSearchPlaylist: function (username, token, keyword) {
        var serviceUrl = "https://localhost:7054/api/get-playlists-by-keyword";
        serviceUrl += "?username=" + username + "&keyword=" + keyword;
        APIManagerSecurity.GetAPISecurity(serviceUrl, token, onSuccess, onFailed);
        function onSuccess(jsonData) {
            var htmlContent = '';
            $('#search-playlist').empty();
            if (jsonData.length > 0) {

                jsonData.forEach(function (playlist) {

                    htmlContent += `<div class="root-list-item d-flex">
                            <div class="root-list-icon d-flex justify-content-center align-items-center bg-secondary">
                                <i class="fa-solid fa-music"></i>
                            </div>
                            <span>
                                <span>${playlist.title}</span><br />
                                <span class="fw-light ms-1" style="font-size: 12px;">Playlists</span>
                                <span class="m-1"><i class="fa-solid fa-circle align-content-center" style="font-size: 5px;"></i></span>
                                <span class="fw-light" style="font-size: 12px;">${playlist.username}</span>
                            </span>
                        </div>`;
                });

                $('#search-playlist').append(htmlContent);
            }
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    },
    GetAllPlaylist: function (username, token) {
        var serviceUrl = "https://localhost:7054/api/get-top-6-playlists?username=" + username;
        APIManagerSecurity.GetAPISecurity(serviceUrl, token, onSuccess, onFailed);
        function onSuccess(jsonData) {
            var htmlContent = '';
            $('#search-playlist').empty();
            if (jsonData.length > 0) {

                jsonData.forEach(function (playlist) {

                    htmlContent += `<div class="root-list-item d-flex">
                            <div class="root-list-icon d-flex justify-content-center align-items-center bg-secondary">
                                <i class="fa-solid fa-music"></i>
                            </div>
                            <span>
                                <span>${playlist.title}</span><br />
                                <span class="fw-light ms-1" style="font-size: 12px;">Playlists</span>
                                <span class="m-1"><i class="fa-solid fa-circle align-content-center" style="font-size: 5px;"></i></span>
                                <span class="fw-light" style="font-size: 12px;">${playlist.username}</span>
                            </span>
                        </div>`;
                });

                $('#search-playlist').append(htmlContent);
            }
        }
        function onFailed(xhr, status, error) {
            window.alert(error);
        }
    }
}