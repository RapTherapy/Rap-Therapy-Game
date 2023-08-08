if (document.URL.includes('Frame138')
) { 
    let timerscaling
    let scaling = window.screen.availHeight;
    if (scaling > 1000) {
        timerscaling = "base-timer__label";    
    }
    else {
        timerscaling = "base-timer__labelgame6";  
    }
    let timerCounter;
    let timer;
    var answers;
    var currentcounter = 0;
    var answervalid;
    var refreshtimerCounter;

    const FULL_DASH_ARRAY = 283;
    const WARNING_THRESHOLD = 20;
    const ALERT_THRESHOLD = 10;

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

    let timePassed = 0;
    let timeLeft = 60; 
    let TIME_LIMIT = 60;
    let timerInterval = null;
    let remainingPathColor = COLOR_CODES.info.color;
    let currentbutton = null;

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
      <span id="base-timer-label" class="${timerscaling}">${
      timeLeft
    }</span>
</div>
`;

    function start(element) {
        $(element).attr('disabled', 'disabled');
        if (element.disabled == true) {
            document.getElementById('base-timer-label').style.color = "black";
        }
        GetWords();
        startTimer();
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
                go();
            }
        }, 1000);
    }

    function formatTime(time) {
        const minutes = Math.floor(time / 60);
        let seconds = time % 60;

        if (seconds < 10) {
            seconds = `0${seconds}`;
        }

        return `${seconds}`;
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

    //Timer
    function GetWords() {
        $.ajax({
            type: "POST",
            beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
            url: '/Frame138?handler=GetAnswers',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log("true")
                answers = result;
                getAnswer();
            }
        });
    }

    function countdown() {
        document.getElementById('Timer').innerHTML = timerCounter;
        timerCounter--;
        if (timerCounter < 0) {
            $('#timeIsOutModel').modal('show');
            refrechGame();
        }
        else {
            timer = setTimeout(countdown, 1000);
        }
    }

    function setNewTimer() {
        document.getElementById('Timer').innerHTML = refreshtimerCounter;
    }
    function refrechGame() {
        setNewTimer();
        currentcounter = 0;
        refreshAnswer();
    }

    document.querySelectorAll('.answer')
        .forEach((element) => element.addEventListener('click', onClick))

    function onClick(event) {
        for (var i = 0; i < answers.models[currentcounter].correctAnswer.length; i++) {
            var id = event.target.id.substr(event.target.id.length - 1);
            if (id == answers.models[currentcounter].correctAnswer[i]) {
                answervalid = true;
                break;
            }
            else {
                if (i == answers.models[currentcounter].correctAnswer.length - 1) {
                    $('#ModalErrorAnswer').modal('show');
                    answervalid = false;
                }
            }
        }
        nextModel();
    }
    function getAnswer() {

        for (var i = 0; i < answers.countOfline; i++) {

            document.getElementById('string+' + [i]).innerHTML = answers.models[currentcounter].question[i];
        }
    }
    function refreshAnswer() {

        for (var i = 0; i < answers.countOfline; i++) {

            document.getElementById('string+' + [i]).innerHTML = "";
        }
    }
    function nextModel() {
        if (answervalid == true) {
            currentcounter++;
            if (currentcounter == 4) {
                document.getElementById('textgame').innerHTML = "Click on the repetition​";
                timePassed-=10;
                $('#bonus').toggleClass("d-none");
            }
            if (currentcounter == 5) {
                let url = window.location.protocol + "//" + window.location.host + '/Frame73?FrameNumber=144';
                window.location.replace(url);
            }
            getAnswer();
        }
    }
    function go() {
        let url = window.location.protocol + "//" + window.location.host + '/AdditionalContent/Game?MessageFor=TimeIsOut&BackTo=Frame138';
        window.location.replace(url);
    }
}