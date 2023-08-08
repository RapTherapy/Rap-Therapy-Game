// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.
let timerS = 10;
let op = 1;
var licence;
setTimeout(function dis() {
    $('#leftUpperMic').attr('style', 'opacity:' + op);
    $('#leftBottomMic').attr('style', 'opacity:' + op);
    $('#rightUpperMic').attr('style', 'opacity:' + op);
    $('#rightBottomMic').attr('style', 'opacity:' + op);
    op = op - 0.01;
    timerS--;
    if (timerS < 0) {

        if (!document.URL.includes('Frame56') && !document.URL.includes('Frame28') && !document.URL.includes('Frame37') && !document.URL.includes('Frame46') && !document.URL.includes('Frame137') && !document.URL.includes('Frame168Template')) {
            document.getElementById('sumbmitBtn').removeAttribute('disabled');
            return;
        }
    }
    else {
        setTimeout(dis, 100);
    }
}, 3500)

if (document.URL.includes('Frame56')) {
    document.getElementById('audioBtn').setAttribute('disabled', '');
    setTimeout(() => document.getElementById('audioBtn').removeAttribute('disabled'), 4500);
}

if (document.getElementById('logo')) {
    document.getElementById('logo').classList.remove('d-none')
}

if (document.getElementById('lastAnimation') && !document.URL.includes('Frame34') ) {
    let lastAnimation = document.getElementById('lastAnimation');

    lastAnimation.addEventListener('animationend', () => {

        document.getElementById('audioBtn').removeAttribute('disabled');
        document.getElementById('sumbmitBtn').removeAttribute('disabled');
    });
}

const animateCSS = (element, animation, prefix = 'animate__') =>

    new Promise((resolve, reject) => {
        const animationName = `${prefix}${animation}`;
        const node = document.getElementById(element);
        const slower = `${prefix}slow`;

        node.classList.add(`${prefix}animated`, animationName, slower);

        function handleAnimationEnd(event) {
            event.stopPropagation();
            node.classList.remove(`${prefix}animated`, animationName, slower);
            resolve('Animation ended');
        }

        node.addEventListener('animationend', handleAnimationEnd, { once: true });
    });

const animateCSSsaveClass = (element, animation, prefix = 'animate__') =>

    new Promise((resolve, reject) => {
        const animationName = `${prefix}${animation}`;
        const node = document.getElementById(element);
        const slower = `${prefix}slow`;
        const delay = `${prefix}delay-2s`

        node.classList.add(`${prefix}animated`, animationName, slower, delay);

        function handleAnimationEnd(event) {
            event.stopPropagation();
            resolve('Animation ended');
        }

        node.addEventListener('animationend', handleAnimationEnd, { once: true });
    });

if (document.getElementById('logo')) {
    CheckLicence();
    if (licence) {
        animateCSS('logo', 'fadeInUpBig').then((message) => {
            animateCSSsaveClass('logo', 'fadeOut').then((message) => {
                let url = window.location.protocol + "//" + window.location.host + "/Frame3";
                window.location.replace(url);
            });
        });
    }
    else 
    {
        animateCSS('logo', 'fadeInUpBig').then((message) => {
            animateCSSsaveClass('logo', 'fadeOut').then((message) => {
                let url = window.location.protocol + "//" + window.location.host + "/FrameFaildLicence";
                window.location.replace(url);
            });
        });
    }
}



$("#usernameInput").click(function () {
    $("#usernameInput").removeAttr('placeholder');
});

$("#passwordInput").click(function () {
    $("#passwordInput").removeAttr('placeholder');
});

function login() {
    $('#loginErrorMessage').addClass('d-none');

    let loginData = {
        login: $('#usernameInput').val(),
        password: $('#passwordInput').val()
    }

    $.ajax({
        type: "POST",
        beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
        url: '/Frame3?handler=Login',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(loginData),
        success: function (resulr) {
            if (resulr.pathToRedirect == null) {
                $('#loginErrorMessage').text(resulr.errorMessage);
                $('#loginErrorMessage').removeClass('d-none');
            }
            else {
                let url = window.location.protocol + "//" + window.location.host + "/" + resulr.pathToRedirect;
                window.location.replace(url);
            }
        }
    });
}

function handleKeyPress(e) {
    var key = e.keyCode || e.which;
    if (key == 13) {
        login();
    }
}

function test() {
    document.getElementById("myRange").disabled = true;
    setTimeout(function () {
        $.ajax({
            type: "POST",
            beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
            url: '/Frame4Template?handler=GoToNextPageFromFeelingBar',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                let url = window.location.protocol + "//" + window.location.host + "/Frame4Template?FrameNumber=14";
                window.location.replace(url);
            }
        });
    }, 1000);
}

function CheckLicence() {
    $.ajax({
        type: "GET",
        async: false,
        beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
        url: '/Frame1?handler=CheckLicence',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            licence = result;
        }
    });
}


