'use strict';

let modelAddTitle = AddWhatWeDelivered;
let modelEditTitle = EditWhatWeDelivered;
let targetFilterForm = '#WhatWeDeliveredFilterForm';


function deleteWhatWeDelivered(id, userId) {
    Delete(`/Client/Delete`, id, targetFilterForm);
}

function addWhatWeDelivered() {
    LoadPartialInModal(`/Client/clientPartial?id=${0}`, modelAddTitle);
}

function editWhatWeDelivered(id) {
    LoadPartialInModal(`/Client/ClientPartial?id=${id}`, modelEditTitle);
}

function successSavingWhatWeDelivered(data) {
    if (!$('#WhatWeDeliveredPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
        UploadFile($('#WhatWeDeliveredPhotoUpload'), `/Client/SaveClientPhoto?whyusId=${data.Data.WhatWeDeliveredId}`, () => { Success(data, targetFilterForm); });
    }
}

function UploadWhatWeDeliveredAttachment(element) {
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    UploadFile(element, '/Client/UploadWhyUsAttachment?whyUsId=' + WhatWeDeliveredId + '', function (res) {
        $(element).val('');
        LoadWhatWeDeliveredAttachmentImages(element);
        InfoToast('Saved');
    });
}

function LoadWhatWeDeliveredAttachmentImages(element) {
    let target = $(element).closest('div').find('.images-container');
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    $(target).load('/Client/RemoveWhyUSAttachmentImg?whyusId=' + WhatWeDeliveredId + '', () => {
        //$(target).closest('tr').removeAttr('hidden');
    });
}

function DeleteDeliveredAttachment(element) {
    let imgId = $(element).attr('data-img-id');
    AjaxCall('POST', '/Client/RemoveWhyUSAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.img-item').remove();
        }
    });
}
