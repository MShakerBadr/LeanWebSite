'use strict';

let modelAddTitle = AddManagment;
let modelEditTitle = EditManagment;
let modalAddUserTitle = 'AddUserTitle';
let modalViewUserTitle = 'ViewUserTitle';
let targetFilterForm = '#ManagmentsFilterForm';
let targetRemoveUserForm = '#removeUserFrm';


function deleteManagment(id, userId) {
    Delete(`/Managment/Delete?userId=${userId}`, id, targetFilterForm);
}

function addManagment() {
    LoadPartialInModal(`/Managment/ManagmentPartial?id=${0}`, modelAddTitle);
}

function editManagment(id) {
    LoadPartialInModal(`/Managment/ManagmentPartial?id=${id}`, modelEditTitle);
}

function successSavingManagment(data) {
    if (!$('#ManagmentPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
        UploadFile($('#ManagmentPhotoUpload'), `/Managment/SaveManagmentPhoto?ManagmentId=${data.Data.ManagmentId}`, () => { Success(data, targetFilterForm); });
    }
}
