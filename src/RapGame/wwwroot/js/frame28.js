var firstelement = document.getElementById("firstrow");
var secondelement = document.getElementById("secondrow");
var thirdelement = document.getElementById("thirdrow");
var fourthelemnet = document.getElementById("fourthrow");
function fadeInUp(element) {
    if (element == fourthelemnet) {
        element.classList.add("animate__animated", "animate__fadeInUp", "animate__slow");
        element.style.display = "";
        document.getElementById('sumbmitBtn').removeAttribute('disabled');
    }
    else {
        element.classList.add("animate__animated", "animate__fadeInUp", "animate__slow");
        element.style.display = "";
    }    
}
setTimeout(fadeInUp, 8000, firstelement);
setTimeout(fadeInUp, 10000, secondelement);
setTimeout(fadeInUp, 12000, thirdelement);
setTimeout(fadeInUp, 14000, fourthelemnet);

