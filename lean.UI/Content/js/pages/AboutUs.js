'use strict';

let modelAddTitle = AddAboutUs;
let modelEditTitle = EditAboutUs;
let targetFilterForm = '#AboutUsFilterForm';


function deleteAboutUs(id, userId) {
    Delete(`/AboutUs/Delete`, id, targetFilterForm);
}

function addAboutUs() {
    LoadPartialInModal(`/AboutUs/AboutUsPartial?id=${0}`, modelAddTitle);
}

function editAboutUs(id) {
    LoadPartialInModal(`/AboutUs/AboutUsPartial?id=${id}`, modelEditTitle);
}

function successSavingAboutUs(data) {
  
    if (!$('#AboutUsPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
        debugger;
        UploadFile($('#AboutUsPhotoUpload'), `/AboutUs/SaveAboutUsPhoto?aboutUsId=${data.Data.aboutUsID}`, () => { Success(data, targetFilterForm); });
    }
}

function UploadWhatWeDeliveredAttachment(element) {
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    UploadFile(element, '/AboutUs/UploadWhyUsAttachment?whyUsId=' + WhatWeDeliveredId + '', function (res) {
        $(element).val('');
        LoadWhatWeDeliveredAttachmentImages(element);
        InfoToast('Saved');
    });
}

function LoadWhatWeDeliveredAttachmentImages(element) {
    let target = $(element).closest('div').find('.images-container');
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    $(target).load('/AboutUs/RemoveWhyUSAttachmentImg?whyusId=' + WhatWeDeliveredId + '', () => {
        //$(target).closest('tr').removeAttr('hidden');
    });
}


function DeleteImag(element) {
    if (confirm("Are you sure you want to delete the image ?")) {
     
    let  ImgPathToDelete= $(element).closest('div.img-collection').find('img').attr('src');
        AjaxCall('POST', '/AboutUs/DeleteImg', { path: ImgPathToDelete }, true, function (res) {
        //if (res === true) {
        //    $(element).closest('.img-item').remove();
        //}
    });
    }

}

function DeleteDeliveredAttachment(element) {
    let imgId = $(element).attr('data-img-id');
    AjaxCall('POST', '/AboutUs/RemoveWhyUSAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.img-item').remove();
        }
    });
}
