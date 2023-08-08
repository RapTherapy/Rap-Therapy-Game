
let lastAnimation = document.getElementById('lastAnimation2');
lastAnimation.addEventListener('animationend', () => {
    document.getElementById('audioBtn').removeAttribute('disabled');

    let start = document.getElementById('start');
    let end = document.getElementById('end2');

    let scaling = window.screen.availHeight;

    if (scaling <= 680) {

        startParam = LeaderLine.pointAnchor(start, { x: +520 });
        endParam = LeaderLine.pointAnchor(end, { x: -120, y: +160 });
    }
    else {
        startParam = LeaderLine.pointAnchor(start, { y: +200 , x:+820 });
        endParam = end;
    }

    let line = new LeaderLine(startParam, endParam, {
        color: 'rgb(0, 176, 80)',
        path: 'grid',
        startSocket: 'right',
        endSocket: 'bottom'
       
    });
    
    line.size = 15
    document.getElementById("lastAnimation2").classList.add("test3");
    document.getElementById("lastAnimation").classList.remove("test3");
    document.getElementById("leader-line-1-line-path").classList.add("test3");
    document.getElementById("leader-line-1-line-path").classList.add("animate__animated", "animate__fadeInUp");
    document.getElementById("leader-line-1-line-path").classList.remove("test3");

});



