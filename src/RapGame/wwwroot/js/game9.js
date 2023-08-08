if (document.URL.includes('Frame190Template') || document.URL.includes('Frame191Template') || document.URL.includes('Frame192Template')) {
    var arrayOfAnswer;
    var selectWrongWord = false;
    window.onload = GetAnwers();
    //Drag and drop

    function allowDrop(ev) {
        ev.preventDefault();
        if (ev.target.getAttribute("draggable") == "true") {
            ev.dataTransfer.dropEffect = "none";
        }
        else {
            ev.dataTransfer.dropEffect = "all";
        }
    }


    function drag(ev) {
        ev.dataTransfer.setData("text", ev.target.id);
    }

    function GetAnwers() {
        $.ajax({
            type: "POST",
            beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
            url: '/Frame190Template?handler=GetAnswers',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                arrayOfAnswer = result;
            }
        });
    }

    function drop(ev) {
        ev.preventDefault();
        var data = ev.dataTransfer.getData("Text");
        document.getElementById(data).removeAttribute('class');
        ev.target.innerHTML = ev.target.innerHTML + document.getElementById(data).innerHTML;
        document.getElementById(data).remove();
        ev.target.removeAttribute('contenteditable');
        ev.target.removeAttribute('ondrop');
        ev.target.removeAttribute('ondragover');
        checkRhyme(ev.target.id, data);
        /*ev.target.appendChild(document.getElementById(data));*/
        if (isAllWordsUsed())
        {
            if (!selectWrongWord) {
                console.log("answers are right");
                redirect();
            }
            else {
                $('#ModalErrorAnswer').modal('show');
                
            }
        }  
    }

    function checkRhyme(lineId, elementId) {
        var answerId = elementId.split('.')[1];
        if (answerId != arrayOfAnswer[lineId]) {
            selectWrongWord = true;
        }
    }

    function redirect() {
        const queryString = window.location.search;
        let url = window.location.protocol + "//" + window.location.host + "/Frame191Template" + queryString;
        window.location.replace(url);
    };
    //

    //Game5
    function isAllWordsUsed() {
        let words = document.getElementById('words').children;
        for (var i = 0; i < words.length; i++) {
            if (words[i].children.length == 1) {
                return false;
            }
        }
        return true;
    }

    function verification(currentElement) {
        const newInnerHtml = checkForProhibitionWord(currentElement.innerHTML);
        if (newInnerHtml !== currentElement.innerHTML) {
            currentElement.innerHTML = newInnerHtml;
        }
    }

    function checkForProhibitionWord(string) {
        const badWords = ["Prick", "dick", "pussy", "fuck", "shit", "dickhead", "pussyclart", "bloodclart", "asshole", "nigga", "nigger", "crap", "git", "ass", "bullshit", "pissed", "bitch", "bellend", "tit", "bollocks", "fanny", "cunt", "prick", "punani", "twat", "cock", "bastard", "motherfucker", "wanker", "wank", "cocksucker", "piss", "pissed", "faggot", "git", "bellend"];
        let finalArray = string.split(' ');
        let arr = string.toLowerCase().split(' ');
        for (let i = 0; i < arr.length; i++) {
            if (badWords.includes(arr[i])) {
                finalArray.splice(i, 1);
                $('#ModalBadWord').modal('show');
            }
        }
        return string = finalArray.join(' ');
    }

    function reloadGame() {
        location.reload();
    }

    $('#ModalErrorAnswer').on("hidden.bs.modal", function () {
        location.reload();       
    });

    function playAudioGame9(path) {
        document.getElementById("audioBtn").setAttribute('disabled', '');
        var audio = new Audio(path);
        audio.play();
        document.getElementById('startBtnGame9').setAttribute('disabled', '');
        audio.addEventListener("ended", () => {
            document.getElementById('audioBtn').removeAttribute('disabled');
        });
    }
}
