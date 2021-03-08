'use strict';

let modelAddTitle = AddNewsAndEvents;
let modelEditTitle = EditNewsAndEvents;
let targetFilterForm = '#NewsAndEventsFilterForm';


function deleteNewsAndEvents(id) {
    Delete(`/NewsAndEvents/Delete`, id, targetFilterForm);
}

function addNewsAndEvents() {
    LoadPartialInModal(`/NewsAndEvents/NewsAndEventsPartial?id=${0}`, modelAddTitle, true);
}

function editNewsAndEvents(id) {
    LoadPartialInModal(`/NewsAndEvents/NewsAndEventsPartial?id=${id}`, modelEditTitle, true);
}

function successSavingNewsAndEvents(data) {
    if (!$('#NewsAndEventsPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
        UploadFile($('#NewsAndEventsPhotoUpload'), `/NewsAndEvents/SaveNewsAndEventsPhoto?NewsAndEventsId=${data.Data.NewsAndEventsId}`, () => { Success(data, targetFilterForm); });
    }
}



function UploadNewsAndEventsAttachment(element) {
    let newsAndEventsId = $(element).attr('data-target-id');
    UploadFile(element, '/NewsAndEvents/UploadNewsAndEventsAttachment?newsAndEventsId=' + newsAndEventsId + '', function (res) {
        $(element).val('');
        LoadNewsAndEventsAttachmentImages(element);
        InfoToast('Saved');
    });
}

function LoadNewsAndEventsAttachmentImages(element) {
    let target = $(element).closest('div').find('.images-container');
    let newsAndEventsId = $(element).attr('data-target-id');
    $(target).load('/NewsAndEvents/LoadNewsAndEventsAttachmentImages?newsAndEventId=' + newsAndEventsId + '', () => {
        //$(target).closest('tr').removeAttr('hidden');
    });
}

function DeleteNewsAndEventsAttachment(element) {
    let imgId = $(element).attr('data-img-id');
    AjaxCall('POST', '/NewsAndEvents/RemoveNewsAndEventsAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.img-item').remove();
        }
    });
}

function UploadNewsAndEventsVideo(element) {
    let vedioUrl = $(element).closest('.video-form').find('#uploadvideoitems').val();
    if (!vedioUrl.includes('https://www.youtube.com/')) {
        ErrorToast('Not Youtube Video!');
        return false;
    }
    if (vedioUrl !== "") {
        let newsAndEventsId = $(element).attr('data-target-id');
        AjaxCall('POST', '/NewsAndEvents/UploadNewsAndEventsVideo', { newsAndEventsId: newsAndEventsId, url: vedioUrl }, true, function (res) {
            $(element).closest('.video-form').find('#uploadvideoitems').val('');
            LoadNewsAndEventsAttachmentVideos(element);
            InfoToast('Saved');
        });
    }
}

function LoadNewsAndEventsAttachmentVideos(element) {
    let target = $(element).closest('.video-form').find('.images-container');
    let newsAndEventsId = $(element).attr('data-target-id');
    $(target).load('/NewsAndEvents/LoadNewsAndEventsAttachmentVideos?newsAndEventId=' + newsAndEventsId + '', () => {
        //$(target).closest('tr').removeAttr('hidden');
    });
}

function DeleteNewsAndEventsVideo(element) {
    let imgId = $(element).attr('data-video-id');
    AjaxCall('POST', '/NewsAndEvents/RemoveNewsAndEventsAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.video-item').remove();
        }
    });
}

