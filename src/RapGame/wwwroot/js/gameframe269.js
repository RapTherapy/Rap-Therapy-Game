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
