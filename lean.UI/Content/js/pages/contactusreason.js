'use strict';

let modelAddTitle = AddContactUsReason;
let modelEditTitle = EditContactUsReason;
let targetFilterForm = '#ContactUsReasonFilterForm';


function deleteContactUsReason(id) {
    Delete('/ContactUsReason/Delete', id, targetFilterForm);
}

function addContactUsReason() {
    LoadPartialInModal(`/ContactUsReason/ContactUsReasonPartial?id=${0}`, modelAddTitle);
}

function editContactUsReason(id) {
    LoadPartialInModal(`/ContactUsReason/ContactUsReasonPartial?id=${id}`, modelEditTitle);
}

function successSavingContactUsReason(data) {
    Success(data, targetFilterForm);
}
