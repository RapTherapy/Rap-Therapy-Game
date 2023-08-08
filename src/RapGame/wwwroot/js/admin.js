$(document).ready(function () {
    $('#example').DataTable();
    $('.dataTables_length').addClass('bs-select');
});

function getCreateForm(studentId) {
    $.ajax({
        type: "POST",
        beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
        url: '/AdminPage?handler=GetStudent',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(studentId),
        success: function (result) {

            $('#loginInput').val('');
            $('#passwordInput').val('');

            document.getElementById('SaveUser').setAttribute('disabled', 'disabled');

            document.getElementById('loginMessage').textContent = "";
            document.getElementById('passwordMessage').textContent = "";

            if (result == null || result.id == null) {
                $('#loginInput').attr('readonly', false);
                $('#SaveUser').attr('onclick', "saveUser('')");
            }
            else {
                $('#loginInput').val(result.name);
                $('#loginInput').attr('readonly', true);
                $('#passwordInput').val(result.password);
                $('#DeleteUser').attr('onclick', "deleteUser('" + result.id + "')")
                $('#DeleteUser').removeClass('d-none');
                $('#SaveUser').attr('onclick', "saveUser('" + result.id + "')");
                document.getElementById('loginMessage').textContent = "OK";
            }

            $('#createStudentForm').modal('show');
        }
    });   
};


function getErrorMessage(messageBy) {
    var text = JSON.stringify(document.getElementById(messageBy + 'Input').value);
    var url = messageBy == 'password' ? '/AdminPage?handler=IsPasswordValid' : '/AdminPage?handler=IsUserExist';

    $.ajax({
        type: "POST",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: text,
        success: function (resulr) {
            document.getElementById(messageBy + 'Message').removeAttribute('class');
            document.getElementById(messageBy + 'Message').setAttribute('class', resulr.color);
            document.getElementById(messageBy + 'Message').textContent = resulr.message;
            isLoginAndPassCorrect()
        }
    });
}

function isLoginAndPassCorrect() {
    if (document.getElementById('loginMessage').textContent == document.getElementById('passwordMessage').textContent) {
        document.getElementById('SaveUser').removeAttribute('disabled');
    }
    else {
        document.getElementById('SaveUser').setAttribute('disabled', 'disabled');
    }
}

function saveUser(studentId) {
    let requestData = {
        id: studentId,
        name: $('#loginInput').val(),
        password: $('#passwordInput').val()
    }

    $.ajax({
        type: "POST",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        url: '/AdminPage?handler=SaveUser',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(requestData),
        success: function (resulr) {     
            $('#createStudentForm').modal('hide');
            location.reload();
        }
    });
}

function deleteUser(studentId) {
    $.ajax({
        type: "POST",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        url: '/AdminPage?handler=DeleteUser',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(studentId),
        success: function (resulr) {
            location.reload();
        }
    });
}

function enterKeyPress(e) {
    var key = e.keyCode || e.which;
    if (key == 13) {
        let id = $('#SaveUser').attr('onclick');
        let start = id.indexOf('\'');
        let end = id.indexOf('\'', start + 1);
        let result = id.substring(start + 1, end);

        saveUser(result);
    }
}

function saveBasePath() {
    let basePath = $('#val').html();

    $.ajax({
        type: "POST",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        url: '/AdminPage?handler=ChangBasePath',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(basePath),
        success: function (resulr) {
            location.reload();
        }
    });
}

$('input[type=file]').change(function () {
    let withoutFile = this.files[0].path.substring(0, this.files[0].path.lastIndexOf('\\'));
    let withoutFolder = withoutFile.substring(0, withoutFile.lastIndexOf('\\'));

    $('#val').text(withoutFolder);
});