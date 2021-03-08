'use strict';

let modelViewTitle = ViewContactUsRequest;
let targetFilterForm = '#ContactUsRequestFilterForm';


function deleteContactUsRequest(id) {
    Delete('/ContactUsRequest/Delete', id, targetFilterForm);
}

function viewContactUsRequest(id) {
    LoadPartialInModal(`/ContactUsRequest/ContactUsRequestPartial?id=${id}`, modelViewTitle);
}

