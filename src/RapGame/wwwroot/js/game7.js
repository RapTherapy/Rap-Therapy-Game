var currentanswer
window.onload = getData;

document.querySelectorAll('.answer')
    .forEach((element) => element.addEventListener('click', onClick))



function onClick(event) {
    for (var i = 0; i < currentanswer.answer.length; i++) {
        var id = event.target.id.substr(event.target.id.length - 1);
        if (id == currentanswer.answer[i]) {
            document.getElementById("audioBtn").setAttribute('disabled', '');
            audio = new Audio(currentanswer.pathToTheAdditionalAudioFile);
            audio.play();
            $('#start').toggleClass("d-none");
            let start = document.getElementById('start');
            let end = document.getElementById('finish');
            let scaling = window.screen.availHeight;

            if (scaling <= 700) {
                let line = new LeaderLine(LeaderLine.pointAnchor(start, {
                    x: 80,
                    y: 120
                }), LeaderLine.pointAnchor(end, {
                    x: 800,
                    y: 0
                }), {
                    color: 'rgb(0, 176, 80)',
                    path: 'straight',
                    startSocket: 'right',
                    endSocket: 'bottom',
                });
                line.size = 20;
            }
            else {
                let line = new LeaderLine(LeaderLine.pointAnchor(start, {
                    x: 200,
                    y: 225
                }), LeaderLine.pointAnchor(end, {
                    x: 1000,
                    y: 0
                }), {
                    color: 'rgb(0, 176, 80)',
                    path: 'straight',
                    startSocket: 'right',
                    endSocket: 'bottom',
                });
                line.size = 25;
            }
            
            for (var i = 0; i < currentanswer.length; i++) {
                var currentid = "string+" + currentanswer[i];
                document.getElementById(currentid).style.color = 'green';
            }
            audio.addEventListener("ended", () => {
                document.getElementById('sumbmitBtn').classList.remove('d-none');
            });
            document.querySelectorAll('.answer')
                .forEach((element) => element.removeEventListener('click', onClick));
            document.getElementById('click').style.visibility ="hidden";    
            break;
        }
        else {
            if (i == currentanswer.answer.length - 1) {
                $('#ModalErrorAnswer').modal('show');
            }
        }
    }
}
function getData() {
    $.ajax({
        type: "POST",
        beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
        url: '/Frame154?handler=GetCurrentAnswers',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            currentanswer = result;
        }
    });
}