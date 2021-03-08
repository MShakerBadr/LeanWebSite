'use strict';

let modelAddTitle = AddWhatWeDelivered;
let modelEditTitle = EditWhatWeDelivered;
let targetFilterForm = '#WhatWeDeliveredFilterForm';


function deleteWhatWeDelivered(id, userId) {
    Delete(`/WhyUs/Delete`, id, targetFilterForm);
}

function addWhatWeDelivered() {
    LoadPartialInModal(`/WhyUs/WhyUsPartial?id=${0}`, modelAddTitle);
}

function editWhatWeDelivered(id) {
    LoadPartialInModal(`/WhyUs/WhyUsPartial?id=${id}`, modelEditTitle);
}

function successSavingWhatWeDelivered(data) {
    if (!$('#WhatWeDeliveredPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
        UploadFile($('#WhatWeDeliveredPhotoUpload'), `/WhyUs/SaveWhyUsPhoto?whyusId=${data.Data.WhatWeDeliveredId}`, () => { Success(data, targetFilterForm); });
    }
}

function UploadWhatWeDeliveredAttachment(element) {
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    UploadFile(element, '/WhyUs/UploadWhyUsAttachment?whyUsId=' + WhatWeDeliveredId + '', function (res) {
        $(element).val('');
        LoadWhatWeDeliveredAttachmentImages(element);
        InfoToast('Saved');
    });
}

function LoadWhatWeDeliveredAttachmentImages(element) {
    let target = $(element).closest('div').find('.images-container');
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    $(target).load('/WhyUs/RemoveWhyUSAttachmentImg?whyusId=' + WhatWeDeliveredId + '', () => {
        //$(target).closest('tr').removeAttr('hidden');
    });
}

function DeleteDeliveredAttachment(element) {
    let imgId = $(element).attr('data-img-id');
    AjaxCall('POST', '/WhyUs/RemoveWhyUSAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.img-item').remove();
        }
    });
}
