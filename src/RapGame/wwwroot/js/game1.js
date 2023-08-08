if (document.URL.includes('Frame17?FrameNumber=17') ||
    document.URL.includes('Frame17?FrameNumber=19')) {
    let scaling = window.screen.availHeight;

    if (document.getElementById('startText')) {
        let startText = document.getElementById('startText');
        let cTime = document.getElementById('cTime');


        let startParam;
        let endParam;

        if (scaling <= 680) {
            startParam = LeaderLine.pointAnchor(startText, { x: 950, y: 35 });
            endParam = LeaderLine.pointAnchor(cTime, { x: 140, y: 10 });
        }
        else if (scaling < 1000) {
            startParam = LeaderLine.pointAnchor(startText, { x: 1000, y: 50 });
            endParam = LeaderLine.pointAnchor(cTime, { x: 220, y: 40 });
        }
        else {
            startParam = LeaderLine.pointAnchor(startText, { x: 1100, y: 70 });
            endParam = LeaderLine.pointAnchor(cTime, { x: 320, y: 70 });
        }

        let line = new LeaderLine(startParam, endParam,
            {
                color: 'red',
                size: 8,
                endPlugSize: 1.0,
                path: 'grid',
                startSocket: 'bottom',
                endSocket: 'right',
            });
    }

    const FULL_DASH_ARRAY = 283;
    const WARNING_THRESHOLD = 10;
    const ALERT_THRESHOLD = 5;

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

    const TIME_LIMIT = document.getElementById('cTime').children[0].id;
    let timePassed = 0;
    let timeLeft = TIME_LIMIT;
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
  <span id="base-timer-label" class="base-timer__label">${formatTime(
        timeLeft
    )}</span>
</div>
`;

    if (scaling <= 680) {
        document.getElementById("base-timer-label").setAttribute('style', 'position: absolute; width: 150px; height: 150px; top: 0; display: flex; align-items: center; justify-content: center; font-size: 50px; ')
    }

    //Animation
    const animateCSSsaveClass = (element, animation, prefix = 'animate__') =>

        new Promise((resolve, reject) => {
            const animationName = `${prefix}${animation}`;
            const node = document.getElementById(element);

            node.classList.add(`${prefix}animated`, animationName);

            function handleAnimationEnd(event) {
                event.stopPropagation();
                resolve('Animation ended');
            }

            node.addEventListener('animationend', handleAnimationEnd, { once: true });
        });
    //
     

    function start(element) {
        $(element).attr('disabled', 'disabled');
        if (element.disabled == true) {
            document.getElementById('base-timer-label').style.color = "black";
        }
        setWordSettings();
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

    //Drag and drop
    function allowDrop(ev) {
        ev.preventDefault();
    }

    function drag(ev) {
        ev.dataTransfer.setData("text", ev.target.id);
    }

    function drop(ev) {
        ev.preventDefault();
        var data = ev.dataTransfer.getData("Text");
        var test = data.replaceAll(/\s/g, '');
        if (test.length > 0) {
            if ($(document.getElementById(data)).attr("data-parent") == "empty") {
                var element = document.getElementById(data);
                element.setAttribute('data-parent', document.getElementById(data).parentNode.id);
            }
            if (ev.target.id.split(':')[0] == "L") {
                document.getElementById(data).setAttribute('style', 'margin-left:150px;font-size:50px; font-weight: bold; cursor: pointer;')
            }
            else {
                document.getElementById(data).setAttribute('style', 'margin-right:150px;font-size:50px; font-weight: bold; cursor: pointer;')
            }
            document.getElementById(ev.target.id.split(':')[0]).appendChild(document.getElementById(data));

            if (!(data.split(':')[0] == ev.target.id.split(':')[0])) {
                setTimeout(function () {
                    $('#exampleModal').modal('show');
                    returnvalue(data, document.getElementById(data).dataset.parent);
                }, 500)
            }

            isGame1End();
        }
    }
    //
    function returnvalue(data, oldParent) {
        animateCSSsaveClass(data, 'fadeOut').then((message) => {
            document.getElementById(oldParent).appendChild(document.getElementById(data));
            document.getElementById(data).classList.remove('animate__animated', 'animate__fadeOut');
            document.getElementById(data).setAttribute('style', 'font-size:100px; font-weight: bold; cursor: pointer;');
            animateCSSsaveClass(data, 'fadeIn').then((message) => {
                document.getElementById(data).classList.remove('animate__animated', 'animate__fadeIn');
            });
        });
    }
    //Game1
    function isGame1End() {
        const wordsInLColl = $.map($('#L > div'), div => div.id);
        const wordsInRColl = $.map($('#R > div'), div => div.id);

        const correctWordsInLColl = wordsInLColl.filter(element => element.includes('L'));
        const correctWordsInRColl = wordsInRColl.filter(element => element.includes('R'));

        if (correctWordsInLColl.length == 5 && correctWordsInRColl.length == 5) {
            onTimesUp();
            stopGame();
            document.getElementById('sumbmitBtn').classList.remove('d-none');
        }
    }

    function stopGame() {
        let leftW = document.getElementById('L').children;
        let rightW = document.getElementById('R').children;

        for (var i = 0; i < leftW.length; i++) {
            leftW[i].removeAttribute('draggable');
        }

        for (var i = 0; i < rightW.length; i++) {
            rightW[i].removeAttribute('draggable');
        }
    }

    function setWordSettings() {
        let words = document.getElementById('words').children;
        let table = words[0].children;

        for (var i = 0; i < table.length; i++) {
            for (var j = 0; j < table[i].children.length; j++) {
                table[i].children[j].children[0].setAttribute('draggable', 'true');
            }
        }

        document.getElementById('L').setAttribute('ondrop', 'drop(event)');
        document.getElementById('R').setAttribute('ondrop', 'drop(event)');
    }

    function go() {
        let url = window.location.protocol + "//" + window.location.host + '/AdditionalContent/Game?MessageFor=TimeIsOut&BackTo=Frame17?FrameNumber=19';
        window.location.replace(url);
    }
}
