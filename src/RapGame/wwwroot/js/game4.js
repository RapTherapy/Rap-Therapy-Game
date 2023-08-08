if (document.URL.includes('Frame66') || document.URL.includes('Frame69Template')) {
    
    var arrayOfAudio;
    function GetAudio() {
        $.ajax({
            type: "GET",
            beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
            url: '/Frame69Template?handler=GetAudioFiles',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {                
                arrayOfAudio = result;            
            }
        });
    }
    $(document).ready(function () {
        GetAudio();
    });
    const source = document.querySelector(".borderblack");
    if (document.getElementById('song')) {
        let song = document.getElementById('song').children;
    }

    if (document.getElementById('couplets')) {
        let couplets = document.getElementById('couplets').children;
    }

    let counter = 0;

    //Drag and drop
    function allowDrop(ev) {
        ev.preventDefault();      
                   
    }

    function drag(ev) {
        ev.dataTransfer.setData("text", ev.target.id);
        

       
    }
    //source.addEventListener("dragend", (ev) =>
    //    ev.target.classList.remove("dragging")
    //);

    function drop(ev) {
        ev.preventDefault();
        var check = ev.target.getAttribute("data-used");
        if (check == "false") {
            var data = ev.dataTransfer.getData("Text");
            var currentElement = document.getElementById(data);
            currentElement.removeAttribute('class');
            currentElement.style.fontSize = null;
            currentElement.setAttribute("class", " ");
            currentElement.classList.add('text-success');
            ev.target.appendChild(currentElement);
            ev.target.dataset.used == "true";
        }
      
    }
    //

    //Game4
    function isGameEnd() {
        for (var i = 0; i < (song.childElementCount) - 1; i++) {
            for (var j = 0; j < song.children[i].childElementCount - 1; j++) {
                if (!(song.children[i].children[j].children[1].hasChildNodes())) {
                    $('#ModalErrorNotAllWordsUsed').modal('show');
                    return null;
                    /*     document.getElementById('song').children[0].children[0].children[1].hasChildNodes()*/
                }
                else if (!(song.children[i].children[j].children[1].id == song.children[i].children[j].children[1].children[0].id.split(':')[1])) {
                    $('#ModalErrorAnswer').modal('show');
                    return null;
                }
            }           
        }
        redirect();
    }

    function reloadGame() {
        location.reload();
    }

    function playAudioForGame4(pathToAudioFile) {
        /* var audio = new Audio(pathToAudioFile);*/
        if (document.getElementById("audioBtn") != null) {
            document.getElementById("audioBtn").setAttribute('disabled', '');
        }
        document.getElementById('startBtnGame4').setAttribute('disabled', '');
        var audio = new Audio(arrayOfAudio[counter]);
        audio.play();     
        setTimeout(loadTextForGame4, couplets.children[counter].id.split(':')[1] + '000');
    }

    function loadTextForGame4() {
        if (couplets.children.length - 1 > counter) {
            couplets.children[counter].classList.add('d-none');
        }
        counter++;

        if (couplets.children.length > counter) { 
            var audio = new Audio(arrayOfAudio[counter]);
            audio.play();
            couplets.children[counter].classList.remove('d-none');
            setTimeout(loadTextForGame4, couplets.children[counter].id.split(':')[1] + '000');
        }
        else {
            document.getElementById('nextBtn').classList.remove('d-none');
        }
    }

    function goNext() {
        let url = window.location.protocol + "//" + window.location.host + "/Frame73?FrameNumber=73";
        window.location.replace(url);
    }

    $('#ModalErrorNotAllWordsUsed').on("hidden.bs.modal", function () {
        reloadGame();
    });

    $('#ModalErrorAnswer').on("hidden.bs.modal", function () {
        reloadGame();
    });

    function redirect() {
        let url = window.location.protocol + "//" + window.location.host + "/Frame22?FrameNumber=67";
        window.location.replace(url);
    };

    const setDragCursor = value => {
        const html = document.getElementsByTagName('html').item(0);
        html.classList.toggle('grabbing', value)
    };
    setDragCursor(true);
}