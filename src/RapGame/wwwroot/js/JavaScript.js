let lastAnimation = document.getElementById('lastAnimation');

lastAnimation.addEventListener('animationend', () => {
    lastAnimation.classList.remove('animate__animated', 'animate__fadeInUp', 'animate__slower', 'animate__delay-1s');
    lastAnimation.classList.add('animate__animated' , 'animate__flip')
}
);
