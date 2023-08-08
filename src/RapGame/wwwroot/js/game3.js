if (document.URL.includes('Frame56')) {
    document.getElementById('sumbmitBtn').setAttribute('disabled', '');
    var IsMediaReproduced = false;
    var currentElement;
    function Comapare(val) {
        var valueOfbuttom = val;
        var currentValue = document.getElementById("startBtn").value;
        if (IsMediaReproduced == true) {
            if (valueOfbuttom == currentValue) {
                disabledbuttons();
                currentElement = document.getElementsByName(valueOfbuttom);
                currentElement.forEach((element) => {
                    element.style.background = 'Black'
                });
                document.getElementById('startBtn').setAttribute('disabled', '');
                document.getElementById('sumbmitBtn').removeAttribute('disabled');
            }
            else {
                currentElement = document.getElementsByName(valueOfbuttom);
                currentElement.forEach((element) => {
                    element.style.background = 'Black'
                });
                $('#ModalErrorAnswer').modal('show');
                disabledbuttons();
              
            }
        }
        else {
            $('#ModalReproduce').modal('show');
        }
    }
    function Reproduce() {
        IsMediaReproduced = true;

    }
    function playaudiogame3(path) {
        document.getElementById("audioBtn").setAttribute('disabled', '');
        gameAudio = new Audio(path);
        gameAudio.play();
        document.getElementById('startBtn').setAttribute('disabled', '');
        gameAudio.addEventListener("ended", () => {
            document.getElementById('startBtn').removeAttribute('disabled');
            document.getElementById("audioBtn").removeAttribute('disabled');
            activebuttons();
        });
    }
    function activebuttons() {
        document.getElementById('firstbutton').removeAttribute('disabled');
        document.getElementById('secondbutton').removeAttribute('disabled');
        document.getElementById('thirdbutton').removeAttribute('disabled');
    }
    function disabledbuttons() {
        document.getElementById('firstbutton').setAttribute('disabled', '');
        document.getElementById('secondbutton').setAttribute('disabled', '');
        document.getElementById('thirdbutton').setAttribute('disabled', '');
    }

    setTimeout(() => document.getElementById('startBtn').removeAttribute('disabled'), 4800);

    $("#ModalErrorAnswer").on("hidden.bs.modal", function () {
        setTimeout(() => currentElement.forEach((element) => {
            element.style.background = "";
        }), 1000);
    });
}

