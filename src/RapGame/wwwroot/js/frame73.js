var firstimage = document.getElementById("first");
var secondimage = document.getElementById("second");

var seco
var timer = setTimeout(function () {
    
    firstimage.classList.remove("visible");
    setTimeout(() => {
        firstimage.src = secondimage.src;
        firstimage.classList.add("visible");
    }, 2000);

}, 5000);

//setTimeout(function () {
//    var pages = document.querySelectorAll('.additionalpage');
//    pages.removeAttribute('class');
//    pages.setAttribute("class", "animate__animated", "animate__slow","animate__fadeInUp");
//}, 3000);

