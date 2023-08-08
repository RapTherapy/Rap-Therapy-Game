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
    var value = target.value;
     
    $(".modal-body #valueofrange").val(value);
    $('#NextPage').modal('show');
}

function transition_frame22() {
    var value = document.getElementById('valueofrange').value;
        $.ajax({
            type: "POST",
            beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
            url: '/Frame22?handler=NextPage',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(value),
            success: function (result) {
                let url = window.location.protocol + "//" + window.location.host + "/" + result;
                window.location.replace(url);
            }
        });
}
