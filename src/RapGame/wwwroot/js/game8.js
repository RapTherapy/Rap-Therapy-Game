const animateCSSsaveClass = (element, animation, prefix = 'animate__') =>

    new Promise((resolve, reject) => {
        const animationName = `${prefix}${animation}`;
        const node = document.getElementById(element);
        const slow = `${prefix}slow`;

        node.classList.add(`${prefix}animated`, animationName, slow);

        function handleAnimationEnd(event) {
            event.stopPropagation();
            resolve('Animation ended');
        }

        node.addEventListener('animationend', handleAnimationEnd, { once: true });
    });

//Drag and drop
function allowDrop(ev) {
    ev.preventDefault();
    if (ev.target.getAttribute("draggable") == "true")
        ev.dataTransfer.dropEffect = "none";
    else
        ev.dataTransfer.dropEffect = "all";
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    isAnswerCorrect(document.getElementById(data).textContent, ev, data);
}

function isAnswerCorrect(answer, ev, data) {
    $.ajax({
        type: "POST",
        beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
        url: '/Frame167Template?handler=IsAnswerCorrect',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(answer),
        success: function (result) {
            ev.target.appendChild(document.getElementById(data));
            document.getElementById(data).removeAttribute('class');

            if (result.isCorrect) {
                document.getElementById('next').classList.remove('d-none');
                animateCSSsaveClass('answers', 'fadeOut');
                animateCSSsaveClass('box', 'fadeOut');
                animateCSSsaveClass('next', 'fadeIn')
            }
            else {
                setTimeout(function () {
                    document.getElementById('message').innerText = result.message;
                    $('#incorrectAnswerModal').modal('show');
                    $('#incorrectAnswerModal').on('hidden.bs.modal', function () {
                        document.getElementById('answers').appendChild(document.getElementById(data));
                        document.getElementById(data).classList.add('col-5', 'display-4', 'text-center', 'border', 'border-3', 'border-dark', 'borderblack', 'm-3','p-3');
                    })
                }, 500)
            }
        }
    });
}

    addEventListener('load', (event) => { document.getElementById('sumbmitBtn').removeAttribute('disabled') });

//