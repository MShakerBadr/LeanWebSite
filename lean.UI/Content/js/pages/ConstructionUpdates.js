'use strict';

let modelAddTitle = AddConstructionUpdates;
let modelEditTitle = EditConstructionUpdates;
let targetFilterForm = '#ConstructionUpdatesFilterForm';


function deleteConstructionUpdates(id, userId) {
    Delete(`/ConstructionUpdates/Delete`, id, targetFilterForm);
}

function addConstructionUpdates(ProjectId) {
    debugger
    LoadPartialInModal(`/ConstructionUpdates/ConstructionUpdatesPartial?id=${0}&ProjectId=${ProjectId}`, modelAddTitle);
}

function editConstructionUpdates(id, ProjectId) {
    LoadPartialInModal(`/ConstructionUpdates/ConstructionUpdatesPartial?id=${id}&ProjectId=${ProjectId}`, modelEditTitle);
}

function successSavingConstructionUpdates(data) {
    LoadPartial('#ConstructionUpdatesPartialDiv', `/ConstructionUpdates/GetConstructionUpdatesUnderProject?projectId=${$('#ProjectID').val()}`);
    if (!$('#ConstructionUpdatesPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
        UploadFile($('#ConstructionUpdatesPhotoUpload'), `/ConstructionUpdates/SaveConstructionUpdatesPhoto?ConstructionUpdatesId=${data.Data.ConstructionUpdatesId}`, () => { Success(data, targetFilterForm); });
    }

}

function UploadConstructionUpdatesAttachment(element) {
    let ConstructionUpdatesId = $(element).attr('data-target-id');
    UploadFile(element, '/ConstructionUpdates/UploadConstructionUpdatesAttachment?ConstructionUpdatesId=' + ConstructionUpdatesId + '', function (res) {
        $(element).val('');
        LoadConstructionUpdatesAttachmentImages(element);
        InfoToast('Saved');
    });
}

function LoadConstructionUpdatesAttachmentImages(element) {
    let target = $(element).closest('div').find('.images-container');
    let ConstructionUpdatesId = $(element).attr('data-target-id');
    $(target).load('/ConstructionUpdates/LoadConstructionUpdatesAttachmentImages?ConstructionUpdatesId=' + ConstructionUpdatesId + '', () => {
        //$(target).closest('tr').removeAttr('hidden');
    });
}

function DeleteConstructionUpdatesAttachment(element) {
    let imgId = $(element).attr('data-img-id');
    AjaxCall('POST', '/ConstructionUpdates/RemoveConstructionUpdatesAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.img-item').remove();
        }
    });
}


function UploadConstructionUpdatesVideo(element) {
    let vedioUrl = $(element).closest('.video-form').find('#uploadvideoitems').val();
    if (!vedioUrl.includes('https://www.youtube.com/')) {
        ErrorToast('Not Youtube Video!');
        return false;
    }
    if (vedioUrl !== "") {
        let ConstructionUpdateId = $(element).attr('data-target-id');
        AjaxCall('POST', '/ConstructionUpdates/UploadConstructionUpdatesVideo', { ConstructionUpdateId: ConstructionUpdateId, url: vedioUrl }, true, function (res) {
            $(element).closest('.video-form').find('#uploadvideoitems').val('');
            LoadConstructionUpdatesIdAttachmentVideos(element);
            InfoToast('Saved');
        });
    }
}

function LoadConstructionUpdatesIdAttachmentVideos(element) {
    let target = $(element).closest('.video-form').find('.images-container');
    let ConstructionUpdateId = $(element).attr('data-target-id');
    $(target).load('/ConstructionUpdates/LoadConstructionUpdatesAttachmentVideos?ConstructionUpdateId=' + ConstructionUpdateId + '', () => {
        //$(target).closest('tr').removeAttr('hidden');
    });
}

function DeleteConstructionUpdatesVideo(element) {
    let imgId = $(element).attr('data-video-id');
    AjaxCall('POST', '/ConstructionUpdates/RemoveConstructionUpdatesAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.video-item').remove();
        }
    });
}

