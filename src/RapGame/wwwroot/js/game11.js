if (document.URL.includes('Frame237') || document.URL.includes('Frame252')) {
    document.getElementById("display").children[0].children[1].children[0].setAttribute('disabled', '');
    const FULL_DASH_ARRAY = 283;
    const WARNING_THRESHOLD = 10;
    const ALERT_THRESHOLD = 5;
    window.onload = GetAttemps();
    const COLOR_CODES = {
        info: {
            color: "green"
        },
        warning: {
            color: "orange",
            threshold: WARNING_THRESHOLD
        },
        alert: {
            color: "red",
            threshold: ALERT_THRESHOLD
        }
    };
    var currentIndex = 0;
    var answers = [];
    var TIME_LIMIT = 20;
    let timePassed = 0;
    var timeLeft = TIME_LIMIT;
    let timerInterval = null;
    let remainingPathColor = COLOR_CODES.info.color;

    document.getElementById("app").innerHTML = `
<div class="base-timer">
  <svg class="base-timer__svg" viewBox="0 0 100 100" xmlns="http://www.w3.org/2000/svg">
    <g class="base-timer__circle">
      <circle class="base-timer__path-elapsed" cx="50" cy="50" r="45"></circle>
      <path
        id="base-timer-path-remaining"
        stroke-dasharray="283"
        class="base-timer__path-remaining ${remainingPathColor}"
        d="
          M 50, 50
          m -45, 0
          a 45,45 0 1,0 90,0
          a 45,45 0 1,0 -90,0
        "
      ></path>
    </g>
  </svg>
  <span id="base-timer-label" class="base-timer__label">${formatTime(
        timeLeft
    )}</span>
</div>
`;

    function start(element) {
        $(element).attr('disabled', 'disabled');
        if (element.disabled == true) {
            document.getElementById('base-timer-label').style.color = "black";
        }
        document.getElementById("display").children[0].children[1].children[0].removeAttribute('disabled');
        startTimer();
    }

    function onTimesUp() {
        clearInterval(timerInterval);
    }

    function startTimer() {
        timerInterval = setInterval(() => {
            timePassed = timePassed += 1;
            timeLeft = TIME_LIMIT - timePassed;
            document.getElementById("base-timer-label").innerHTML = formatTime(
                timeLeft
            );
            setCircleDasharray();
            setRemainingPathColor(timeLeft);

            if (timeLeft === 0) {
                onTimesUp();
                go();
            }
        }, 1000);
    }

    function verification(currentElement) {
        getAnswers();
        const newInnerHtml = checkForProhibitionWord(currentElement.value);
        if (newInnerHtml !== currentElement.value) {
            currentElement.value = newInnerHtml;
        }
        if (CheckForRhyme(currentElement.value)) {
            if (!CheckForEndingIndex(currentIndex)) {
                document.getElementById(currentIndex.toString()).classList.add("d-none");
                currentIndex++;
                document.getElementById(currentIndex.toString()).classList.remove("d-none");
            }
            else {
                redirect();
            }
        }
        else {
            console.log('false');
        }

    }

    function getAnswers() {
        var element = "example+" + currentIndex.toString();
        for (let i = 0; i < document.getElementById(element).childElementCount; i++) {
            answers.push(document.getElementById(element.toString()).children[i].children[0].innerHTML);
        }
    }

    function CheckForRhyme(string) {
        let arrayOfWords = string.split(' ');
        if (answers.includes(arrayOfWords[arrayOfWords.length - 1])) {
            return true;
        }
        return false;
    }

    function CheckForEndingIndex(index) {
        if (document.URL.includes('Frame237')) {
            if (index == 4) {
                return true;

            }
            else {
                return false;
            }
        }
        else {
            if (index == 9) {
                return true;

            }
            else {
                return false;
            }
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

    function redirect() {
        let url;
        if (document.URL.includes('Frame237')) {
            const queryString = "?FrameNumber=242";
             url = window.location.protocol + "//" + window.location.host + "/Frame232Template" + queryString;
        }
        else {
            const queryString = "?FrameNumber=262";
            url = window.location.protocol + "//" + window.location.host + "/Frame226Template" + queryString;
        }
        window.location.replace(url);
    }

    function formatTime(time) {
        const minutes = Math.floor(time / 60);
        let seconds = time % 60;

        if (seconds < 10) {
            seconds = `0${seconds}`;
        }

        return `${minutes}:${seconds}`;
    }

    function setRemainingPathColor(timeLeft) {
        const { alert, warning, info } = COLOR_CODES;
        if (timeLeft <= alert.threshold) {
            document
                .getElementById("base-timer-path-remaining")
                .classList.remove(warning.color);
            document
                .getElementById("base-timer-path-remaining")
                .classList.add(alert.color);
        } else if (timeLeft <= warning.threshold) {
            document
                .getElementById("base-timer-path-remaining")
                .classList.remove(info.color);
            document
                .getElementById("base-timer-path-remaining")
                .classList.add(warning.color);
        }
    }

    function calculateTimeFraction() {
        const rawTimeFraction = timeLeft / TIME_LIMIT;
        return rawTimeFraction - (1 / TIME_LIMIT) * (1 - rawTimeFraction);
    }

    function setCircleDasharray() {
        const circleDasharray = `${(
            calculateTimeFraction() * FULL_DASH_ARRAY
        ).toFixed(0)} 283`;
        document
            .getElementById("base-timer-path-remaining")
            .setAttribute("stroke-dasharray", circleDasharray);
    }

    function GetAttemps() {
        if (document.URL.includes('Frame237')) {
            $.ajax({
                type: "POST",
                beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
                url: '/Frame237?handler=GetCountOfattempts',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    document.getElementById('base-timer-label').innerHTML = formatTime(result);
                    TIME_LIMIT = result;
                    timeLeft = TIME_LIMIT;
                }
            });
        }
        else {
            $.ajax({
                type: "POST",
                beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
                url: '/Frame252?handler=GetCountOfattempts',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    document.getElementById('base-timer-label').innerHTML = formatTime(result);
                    TIME_LIMIT = result;
                    timeLeft = TIME_LIMIT;
                }
            });
        }
    }

    function go() {
        const frame = window.location.href.split('/')[3].split('?')[0];
        const queryString = window.location.search;
        let url = window.location.protocol + "//" + window.location.host + '/AdditionalContent/Game?MessageFor=TimeIsOut&BackTo=' + frame + queryString;
        window.location.replace(url);
    }
}