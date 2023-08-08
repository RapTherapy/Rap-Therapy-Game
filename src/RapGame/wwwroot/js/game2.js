let row = document.getElementById('sentensGame2').children;
let counter = 0;

function playAudioForGame2(pathToAudioFile, isPageHaveFullText) {
    var audio = new Audio(pathToAudioFile);
    audio.play();
    if (isPageHaveFullText == "False") {
        document.getElementById('audioBtn').setAttribute('disabled', '');
        document.getElementById('startBtnGame2').setAttribute('disabled', '');
        row[counter].classList.remove('d-none');
        setTimeout(loadTextForGame2, row[counter].id.split(':')[1] + '000');
    }
    else {
        document.getElementById('audioBtn').setAttribute('disabled', '');
        let sum = 0;
        document.getElementById('startBtnGame2').setAttribute('disabled', '');
        for (var i = 0; i < row.length; i++) {
            sum += parseInt(row[i].id.split(':')[1]);
        }
        setInterval(function () {
            document.getElementById('nextBtn').removeAttribute('disabled');
            document.getElementById('audioBtn').removeAttribute('disabled');
        }, sum + '000');    
    }
}

function loadTextForGame2() {
    if (row.length-1 > counter) {
        row[counter].classList.add('d-none');
        counter++;
    }
    else {
        counter++;
    }
    if (row.length > counter) {  
        if (row.length - 1 >= counter) {
            row[counter].classList.remove('d-none');
        }
        setTimeout(loadTextForGame2, row[counter].id.split(':')[1] + '000');
    }
    else {
        document.getElementById('nextBtn').removeAttribute('disabled');
        document.getElementById('audioBtn').removeAttribute('disabled');
    }
}