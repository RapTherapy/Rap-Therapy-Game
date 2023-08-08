if (document.URL.includes('Frame4Template?FrameNumber=13')) {
    const rangeInputs = document.querySelectorAll('input[type="range"]')

    function handleInputChange(e) {
        let target = e.target
        if (e.target.type !== 'range') {
            target = document.getElementById('range')
        }
        const min = target.min
        const max = target.max
        const val = target.value
        currentValue = target.value



        target.style.backgroundSize = (val - min) * 100 / (max - min) + '% 100%'
    }

    rangeInputs.forEach(input => {
        input.addEventListener('input', handleInputChange)
    })
    rangeInputs.forEach(input => {
        input.addEventListener('mouseup', GetPopup)
    });
    rangeInputs.forEach(input => {
        input.addEventListener('change', GetPopup)
    });

    function GetPopup(e) {
        let target = e.target;
        if (e.target.type !== 'range') {
            target = document.getElementById('range')
        }
        $('#NextPage').modal('show');
    }
    function transition_frame14() {
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
    }
}
