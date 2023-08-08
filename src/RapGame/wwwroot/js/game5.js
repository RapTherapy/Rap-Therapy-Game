if (document.URL.includes('Frame82Template') || document.URL.includes('Frame80Template') || document.URL.includes('Frame83Template') || document.URL.includes('AdditionalContent')) {
    var reloadpage = false;

    function allowDrop(ev) {
        ev.preventDefault();
        if (ev.target.getAttribute("draggable") == "true")
            ev.dataTransfer.dropEffect = "none";
        else
            ev.dataTransfer.dropEffect = "all";
    }

    function drag(ev) {
        ev.dataTransfer.setData("text", ev.target.id);

    }

    function drop(ev) {
        ev.preventDefault();
        var data = ev.dataTransfer.getData("Text");
        document.getElementById(data).removeAttribute('class');
        document.getElementById(data).setAttribute('class', 'text-center');      
        ev.target.appendChild(document.getElementById(data));
        deleteDragCursorw();
        if (iaAllWordsUsed()) {
            if (isGameEnd()) {
                getArrow();
            }
            else {
                reloadpage = true;
                $('#ModalErrorAnswer').modal('show');
                return null
            }
        }
    }
    //

    //Game5
    function iaAllWordsUsed() {
        let words = document.getElementById('words').children;
        for (var i = 0; i < words.length; i++) {
            if (words[i].children.length == 1) {
                document.getElementById('refToNextPage').removeAttribute('disabled');
                return false;
            }
        }

        return true;
    }

    function isGameEnd() {
        let couplet = document.getElementById('end').children;

        for (var i = 0; i < couplet.length; i++) {
            let test = couplet[i];
            if (test.localName != 'a') {
                if (!(couplet[i].children[0].id == couplet[i].children[1].children[0].id.split(':')[1])) {
                    return false;
                }
            }
            else {
                if (!(couplet[i].children[0].children[0].id == couplet[i].children[0].children[1].children[0].id.split(':')[1])) {
                    return false;
                }
            }
        }

        return true;
    }

    function reloadGame() {
        location.reload();
    }

    function playAudioForGame5(pathToAudioFile) {
        var audio = new Audio(pathToAudioFile);
        audio.play();
        document.getElementById('startBtn').setAttribute('disabled', 'disabled');
        setTimeout(function () {
            document.getElementById('nextBtn').classList.remove('d-none');
        }, document.getElementById('duration').children[0].id + '000');
    }

    function isAnswerCorrect(id) {
        if (document.getElementById('rhyme').children[0].id == id) {
            document.getElementById('nextBtn').classList.remove('d-none');
            document.getElementById(id).style.background = 'Black';
            document.getElementById('AAAA').setAttribute('disabled', 'disabled');
            document.getElementById('AABB').setAttribute('disabled', 'disabled');
            document.getElementById('ABAB').setAttribute('disabled', 'disabled');
        }
        else {
            $('#ModalErrorAnswer').modal('show');
        }
    }

    function GoTo(id) {
        let url = window.location.protocol + "//" + window.location.host + '/' + id.split(':')[0] + '?FrameNumber=' + id.split(':')[1] + '&EmotionForRap=' + id.split(':')[2];
        window.location.replace(url);
    }

    function isCorrect(id) {
        if (document.getElementById('answer').children[0].id == id) {
            document.getElementById('sumbmitBtn').classList.remove('d-none');
            for (var i = 1; i < 5; i++) {

                document.getElementById(i).removeAttribute('onclick');
            }
        }

        else {
            $('#ModalErrorAnswer').modal('show');
        }
    }
    //

    //Arrow
    function getArrow() {
        document.getElementById('navigationPanel').classList.remove('d-none');

        if (document.getElementById('start') && document.getElementById('end')) {
            let start;
            let end;
            let scaling = window.screen.availHeight;
            if (scaling <= 680) {
                start = LeaderLine.pointAnchor(document.getElementById('start'), { x: -100, y: -25 });
                end = LeaderLine.pointAnchor(document.getElementById('end'), { x: 250, y: 120 });
            }
            else {
                start = document.getElementById('start');
                end = document.getElementById('end');
            }

            let line = new LeaderLine(start, end, {
                color: 'rgb(68, 114, 196)',
                size: 8,
                path: 'grid',
                startSocket: 'left',
                endSocket: 'bottom',
            });

            line.size = 20;
        }
    }

    $('#ModalErrorAnswer').on("hidden.bs.modal", function () {
        if (reloadpage) {
            reloadGame();
            reloadpage = false;
        }
    });
}

function deleteDragCursorw() {
   /* element.classList.remove('grabbing');*/
    for (var i = 0; i < document.getElementById("words").children.length; i++) {
        if (!document.getElementById("words").children[i].children[0]) {
            var element = document.getElementById("words").children[i];
            element.classList.remove('grabbing');
        }     
    }
}

if (document.URL.includes('Frame80Template')) {
    const setDragCursor = value => {
        for (var i = 0; i < document.getElementById("words").children.length; i++) {

            const html = document.getElementById("words").children[i];
            html.classList.toggle('grabbing', value)
        }
    };
    setDragCursor(true);

}
