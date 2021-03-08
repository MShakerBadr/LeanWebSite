'use strict';


function successChangeUsername(data) {
    debugger
    Success(data);
    if (data.Success)
        $('#dvChangeUsername').find('input[type=text]').val('');
}

function successChangePassword(data) {
    Success(data);
    if (data.Success)
        $('#dvChangePassword').find('input[type=text],input[type=password]').val('');
}
