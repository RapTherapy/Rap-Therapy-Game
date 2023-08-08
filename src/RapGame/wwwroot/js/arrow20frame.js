if (document.URL.includes('Frame20')) {
    let lastAnimation = document.getElementById('lastAnimation');
    lastAnimation.addEventListener('animationend', () => {
        document.getElementById('audioBtn').removeAttribute('disabled');

        let scaling = window.screen.availHeight;

        let start = document.getElementById('start');
        let end = document.getElementById('end');

        let startParam;
        let endParam;

        if (scaling <= 680) {
            startParam = LeaderLine.pointAnchor(start, { x: 180, y: -50 });
            endParam = LeaderLine.pointAnchor(end, { x: -220, y: 0 });
        }
        else if (scaling > 1000) {
            startParam = start;
            endParam = LeaderLine.pointAnchor(end, { x: 100, y: 60 });
        }
        else {
            startParam = LeaderLine.pointAnchor(start, { y: -25 });
            endParam = LeaderLine.pointAnchor(end, { x: -50, y: 40 });
        }

        let line = new LeaderLine(startParam, endParam, {
            color: '#0000ff',
            size: 6,
            endPlugColor: 'rgb(252, 235, 192)',
            endPlugSize: 2.5,
            endPlugOutline: true,
            endPlugOutlineColor: '#0000ff',
            path: 'fluid',
            startSocket: 'top',
            endSocket: 'bottom',
        });

        line.startSocketGravity = [-200, scaling > 1000 ? -600 : -800]
        $('#lastAnimation').css("visibility", "");
    });
}