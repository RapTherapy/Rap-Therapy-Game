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

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    document.getElementById(data).removeAttribute('class');
    ev.target.innerHTML = ev.target.innerHTML + document.getElementById(data).innerHTML;
    document.getElementById(data).remove();
    ev.target.removeAttribute('contenteditable');
    ev.target.removeAttribute('ondrop');
    ev.target.removeAttribute('ondragover');
    /*ev.target.appendChild(document.getElementById(data));*/
    if (isAllWordsUsed()) {
        //if (isGameEnd()) {
        //    document.getElementById('sumbmitBtn').classList.remove('d-none');
        //}
        //else {
        //     $('#ModalErrorAnswer').modal('show');

        //    $('#ModalErrorAnswer').on('hidden.bs.modal', function () {
        //      reloadGame();
        //    })
        //}
        document.getElementById('sumbmitBtn').classList.remove('d-none');
    }
}
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


function isGameEnd() {
    //let countofwords = document.getElementById('words').children.length;
    //let couplet = Math.floor(countofwords/4);
    //let words = document.getElementById('finish').children;
    //for (var i = 0; i < couplet; i++) {
    //    var firstelement = i * 4
    //    var lastelement = (i + 1) * 4
    //    for (var j = firstelement; j < lastelement-1; j++) {
    //        if (words[j].children[0].id.split('.')[1] != words[j+1].children[0].id.split('.')[1]) {
    //            return false;
    //        }
    //    }
    //}
    //return true;

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
