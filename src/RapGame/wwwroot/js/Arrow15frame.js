   if (document.URL.includes('Frame4Template?FrameNumber=15')) {
        let start = document.getElementById('start');
        let end = document.getElementById('end');

        let scaling = window.screen.availHeight;

        param = scaling <= 680 ? LeaderLine.pointAnchor(end,
            window.innerWidth >= 1000 ? { x: -120, y: -10 } : { x: -30, y: -20 }
        ) : end;


        let line = new LeaderLine(start, param, {
            color: '#0000ff',
            size: 6,
            endPlugColor: 'rgb(252, 235, 192)',
            endPlugSize: 3.0,
            endPlugOutline: true,
            endPlugOutlineColor: '#0000ff',
            path: 'fluid',
            startSocket: 'left',
            endSocket: 'left',
        });

       line.startSocketGravity = [
           (scaling <= 680 ? -650 : (scaling > 1000 ? -700 : -750)), (scaling > 1000 ? -300 : -300)];

        if (window.innerWidth < 1000) {
            line.startSocketGravity = [(scaling <= 680 ? -180 : (scaling > 1000 ? -300 : -150)), -50];
            line.startSocket = 'top';
        }
    }

