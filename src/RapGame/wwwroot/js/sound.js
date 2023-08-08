var audiopath = "";
var audio;
var audioImgSound = document.getElementById("audioImgSound");
var audioImgPause = document.getElementById("audioImgPause");

if (document.URL.includes('Frame34')) {
    window.onload = function () {
        path = document.getElementById("additional_audio");
        audio = new Audio(path.getAttribute('value'));
        audio.play();

        document.getElementById("audioBtn").setAttribute('disabled', '');
        setTimeout(() => document.getElementById("audioBtn").removeAttribute('disabled', ''), 9000);
    }

}

function play(path) {
    if (audiopath == "") {
        audiopath = path;
        audio = null;
        audio = new Audio(path);
    }
    if (document.getElementById("audioBtn").classList.contains('playing')) {
        audioImgPause.style.display = "none";
        audioImgSound.style.display = null;
        audio.pause();
        document.getElementById("audioBtn").classList.remove('playing');
    }
    else {
        if (document.URL.includes('Frame56')) {
            document.getElementById("startBtn").setAttribute('disabled', '');
        }
        if (document.URL.includes('Frame69Template')) {
            document.getElementById("startBtnGame4").setAttribute('disabled', '');
        }
        if (document.URL.includes('Frame137')) {
            document.getElementById("startBtnFrame137").setAttribute('disabled', '');
        }
        if (document.URL.includes('Frame29')) {
            document.getElementById("startBtnGame2").setAttribute('disabled', '');
        }
        audio.play();
        audioImgSound.style.display = "none";
        audioImgPause.style.display = null;
        document.getElementById("audioBtn").classList.add('playing');
    }
    audio.addEventListener("ended", () => {
        if (document.URL.includes('Frame56')) {
            document.getElementById("startBtn").removeAttribute('disabled');
        }
        if (document.URL.includes('Frame137')) {
            document.getElementById("startBtnFrame137").removeAttribute('disabled');
        }
        if (document.URL.includes('Frame69Template')) {
            document.getElementById("startBtnGame4").removeAttribute('disabled');
        }
        if (document.URL.includes('Frame29')) {
            document.getElementById("startBtnGame2").removeAttribute('disabled');
        }
        audiopath = path;
        audio = new Audio(audiopath);
        document.getElementById("audioBtn").classList.remove('playing');
        audioImgPause.style.display = "none";
        audioImgSound.style.display = null;
    });
}

/*startBtnFrame137*/
/*startBtnGame4*/