
function playAudioForFrame137(path) {
    document.getElementById('sumbmitBtn').setAttribute('disabled', '');
    document.getElementById("audioBtn").setAttribute('disabled', '');
    var audio = new Audio(path);
    audio.play();
    document.getElementById('startBtnFrame137').setAttribute('disabled', '');
    audio.addEventListener("ended", () => {
        document.getElementById('sumbmitBtn').removeAttribute('disabled');
    });
}