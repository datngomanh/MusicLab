// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const musicContainer = document.getElementById("music-container");
const playBtn = document.getElementById("play");
const prevBtn = document.getElementById("prev");
const nextBtn = document.getElementById("next");
const randomBtn = document.getElementById("random-audio");
const redoBtn = document.getElementById("redo-audio");

const audio = document.getElementById("audio");
const progress = document.getElementById("progress");
const progressVolumeBar = document.getElementById("progress-volume-bar");
const progressCurrentTime = document.getElementById("progress-currentTime");
const progressDuration = document.getElementById("progress-duration");
const progressContainer = document.getElementById("progress-container");
const progressVolume = document.getElementById("progress-volume");
const title = document.getElementById("title");
const cover = document.getElementById("cover");
const artist = document.getElementById("artist");

const searchPage = document.getElementById("link_search");

const songs = [];
let songIndex = 1;
var audioPosition = 0;

function loadSong(index) {
    songIndex = index;
    const song = songs[index];
    if (song) {
        title.innerText = song.title;
        artist.innerText = song.artist;
        audio.src = song.audioUrl;
        cover.src = song.cover;
    }
    
}

function playSong() {
    musicContainer.classList.add("play");
    playBtn.querySelector("i.fas").classList.remove("fa-play-circle");
    playBtn.querySelector("i.fas").classList.add("fa-pause-circle");
    audio.play();
}

function pauseSong() {
    musicContainer.classList.remove("play");
    playBtn.querySelector("i.fas").classList.add("fa-play-circle");
    playBtn.querySelector("i.fas").classList.remove("fa-pause-circle");
    audio.pause();
}

function prevSong() {
    songIndex--;

    if (songIndex < 0) {
        songIndex = songs.length - 1;
    }
    loadSong(songIndex);
    playSong();
}

function nextSong() {
    songIndex++;
    if (songIndex > songs.length - 1) {
        songIndex = 0;
    }
    loadSong(songIndex);
    playSong();
}

function randomSong() {
    if (randomBtn.querySelector("i.fas").classList.contains("text-success")) {
        songIndex++;
        if (songIndex > songs.length - 1) {
            songIndex = 0;
        }
        randomBtn.querySelector("i.fas").classList.add("color-default");
        randomBtn.querySelector("i.fas").classList.remove("text-success");
    } else {
        songIndex = getRandomNumber(0, songs.length);
        if (songIndex > songs.length - 1) {
            songIndex = 0;
        }
        randomBtn.querySelector("i.fas").classList.remove("color-default");
        randomBtn.querySelector("i.fas").classList.add("text-success");
    }
    
}

function getRandomNumber(min, max) {
    return Math.floor(Math.random() * (max - min) + min);
}

function redoSong() {
    if (audio.loop == true) {
        audio.loop = false
        redoBtn.querySelector("i.fas").classList.add("color-default");
        redoBtn.querySelector("i.fas").classList.remove("text-success");
    }
    else {
        audio.loop = true
        redoBtn.querySelector("i.fas").classList.remove("color-default");
        redoBtn.querySelector("i.fas").classList.add("text-success");
    }
}

function updateProgress(e) {
    const { duration, currentTime } = e.srcElement;
    const progressPercent = (currentTime / duration) * 100;
    progressCurrentTime.innerText = Math.floor(currentTime / 60) + ":" + String(Math.floor(currentTime % 60)).padStart(2, "0");
    progressDuration.innerText = Math.floor(duration / 60) + ":" + String(Math.floor(duration % 60)).padStart(2, "0");
    progress.style.width = `${progressPercent}%`;
}

function setProgress(e) {
    const width = this.clientWidth;
    const clickX = e.offsetX;
    const duration = audio.duration;

    audio.currentTime = (clickX / width) * duration;
}

function setVolume(e) {
    const width = this.clientWidth;
    const clickX = e.offsetX;
    const duration = 1;

    audio.volume = (clickX / width) * duration;
    const progressPercent = (audio.volume / duration) * 100;
    progressVolumeBar.style.width = `${progressPercent}%`;
}

playBtn.addEventListener("click", () => {
    const isPlaying = musicContainer.classList.contains("play");
    if (isPlaying) {
        pauseSong();
    } else {
        playSong();
    }
});

function loadPage(url) {
    //audio.pause();
    //audioPosition = audio.currentTime;
    $.ajax({
        url: url,
        success: function (data) {
            $("#main").html(data);
            //if (musicContainer.classList.contains("play")) {
            //    audio.currentTime = audioPosition;
            //    audio.play();
            //}
        }
    });
}


prevBtn.addEventListener("click", prevSong);
nextBtn.addEventListener("click", nextSong);
randomBtn.addEventListener("click", randomSong);
redoBtn.addEventListener("click", redoSong);

audio.addEventListener("timeupdate", updateProgress);

progressContainer.addEventListener("click", setProgress);
progressVolume.addEventListener("click", setVolume);

audio.addEventListener("ended", function () {
    ManagerSong.UpdateListens(songs[songIndex].id);
    nextSong();
});

$(".nav-link").click(function (e) {
    e.preventDefault();
    var url = $(this).attr("href");
    loadPage(url);
    if (url == "/Search") {
        document.getElementById("search-top-bar").style.setProperty('display', 'flex', 'important');
        document.getElementById("nav-item-home").classList.remove("active");
        document.getElementById("nav-item-search").classList.add("active");
    } else {
        document.getElementById("search-top-bar").style.setProperty('display', 'none', 'important');
        document.getElementById("nav-item-home").classList.add("active");
        document.getElementById("nav-item-search").classList.remove("active");
    }
});
$(".nav-link-playlist").click(function (e) {
    e.preventDefault();
    var url = $(this).attr("href");
    loadPage(url);
});
//--------------------------------------------
let main = document.getElementById('main');
let header = document.getElementById('header-overlay');
main.addEventListener('scroll', function (event) {
    var scroll = this.scrollTop;
    if (scroll < 60) {
        header.style.opacity = '.' + scroll
    } else {
        header.style.opacity = 1
    }
})