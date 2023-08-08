if (document.URL.includes('Frame250')) {
    window.onload = changeTimer
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

    const TIME_LIMIT = 20;
    let timePassed = 0;
    let timeLeft = TIME_LIMIT;
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
      <span id="base-timer-label" class="base-timer__label animate__animated animate__fadeOut animate__delay-2s">${formatTime(
          timeLeft
      )}</span>
    </div>
    `;

    function formatTime(time) {
        const minutes = Math.floor(time / 60);
        let seconds = time % 60;

        if (seconds < 10) {
            seconds = `0${seconds}`;
        }

        return `${minutes}:${seconds}`;
    }

        function changeTimer()
        {   
            setTimeout(() => {
                var timeFromTimer = document.getElementById('base-timer-label');
                timeFromTimer.innerHTML = formatTime(timeLeft - 5);
                timeFromTimer.classList.remove('animate__animated', 'animate__fadeOut', 'animate__delay-2s');
                timeFromTimer.classList.add('animate__animated', 'animate__fadeIn', 'animate__delay-2s');
                
    }, 4000);
            //setTimeout(addFn2, 1200);
            //function addFn2() {
            //    var timer = formatTime(timeLeft);
            //    $('#base-timer-label').html(timer).fadeIn(600);
            //}
        }
    //var timer = setTimeout(function () {

    // $('#placeholder1').html(${formatTime(
    //    timeLeft
    //)}).fadeIn(600);
//    setTimeout(() => {
//        firstimage.src = secondimage.src;
//        firstimage.classList.add("visible");
//    }, 2000);

//}, 5000);
//}
}