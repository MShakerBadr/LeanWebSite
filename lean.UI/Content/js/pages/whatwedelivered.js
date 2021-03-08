'use strict';

let modelAddTitle = AddWhatWeDelivered;
let modelEditTitle = EditWhatWeDelivered;
let targetFilterForm = '#WhatWeDeliveredFilterForm';


function deleteWhatWeDelivered(id, userId) {
    Delete(`/WhatWeDelivered/Delete`, id, targetFilterForm);
}

function addWhatWeDelivered() {
    LoadPartialInModal(`/WhatWeDelivered/WhatWeDeliveredPartial?id=${0}`, modelAddTitle);
}

function editWhatWeDelivered(id) {
    LoadPartialInModal(`/WhatWeDelivered/WhatWeDeliveredPartial?id=${id}`, modelEditTitle);
}

function successSavingWhatWeDelivered(data) {
    if (!$('#WhatWeDeliveredPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
        UploadFile($('#WhatWeDeliveredPhotoUpload'), `/WhatWeDelivered/SaveWhatWeDeliveredPhoto?WhatWeDeliveredId=${data.Data.WhatWeDeliveredId}`, () => { Success(data, targetFilterForm); });
    }
}

function UploadWhatWeDeliveredAttachment(element) {
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    UploadFile(element, '/WhatWeDelivered/UploadWhatWeDeliveredAttachment?WhatWeDeliveredId=' + WhatWeDeliveredId + '', function (res) {
        $(element).val('');
        LoadWhatWeDeliveredAttachmentImages(element);
        InfoToast('Saved');
    });
}

function LoadWhatWeDeliveredAttachmentImages(element) {
    let target = $(element).closest('div').find('.images-container');
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    $(target).load('/WhatWeDelivered/LoadWhatWeDeliveredAttachmentImages?WhatWeDeliveredId=' + WhatWeDeliveredId + '', () => {
        //$(target).closest('tr').removeAttr('hidden');
    });
}

function DeleteDeliveredAttachment(element) {
    let imgId = $(element).attr('data-img-id');
    AjaxCall('POST', '/WhatWeDelivered/RemoveWhatWeDeliveredAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.img-item').remove();
        }
    });
}
