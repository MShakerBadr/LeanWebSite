'use strict';

let modelAddTitle = AddGallery;
let modelEditTitle = EditGallery;
let modalAddUserTitle = 'AddUserTitle';
let modalViewUserTitle = 'ViewUserTitle';
let targetFilterForm = '#GallerysFilterForm';
let targetRemoveUserForm = '#removeUserFrm';


function deleteGallery(id, userId) {
    Delete(`/Gallery/Delete?userId=${userId}`, id, targetFilterForm);
}

function addGallery() {
    LoadPartialInModal(`/Gallery/GalleryPartial?id=${0}`, modelAddTitle);
}

function editGallery(id) {
    LoadPartialInModal(`/Gallery/GalleryPartial?id=${id}`, modelEditTitle);
}

function successSavingGallery(data) {
    if ($('#GalleryPhotoUpload').val()) {
        UploadFile($('#GalleryPhotoUpload'), `/Gallery/SaveGalleryPhoto?GalleryId=${data.Data.GalleryId}`, () => { Success(data, targetFilterForm); });
    }
    else {
        if (data.Success) Success(data, targetFilterForm);
    }

    if ($('#GalleryVideoUpload').val()) {
        UploadFile($('#GalleryVideoUpload'), `/Gallery/SaveGalleryVideo?GalleryId=${data.Data.GalleryId}`, () => { Success(data, targetFilterForm); });
    }
    else {
        if (data.Success) Success(data, targetFilterForm);
    }
}

function isVideoCheck(element) {
    if ($(element).is(":checked")) {
        $(".videoURL").removeClass('d-none');
        $("#GalleryVideoRemove").click();
    } else {
        $(".videoURL").addClass('d-none');
    }
}


function ReadVideoURL(input) {
    var $source = $(input).closest('div.video-collection').find('video source');
    if (input.files && input.files[0]) {
        $source[0].src = URL.createObjectURL(input.files[0]);
        $source.parent()[0].load();
    } else {
        $('input[type=hidden][name=' + $(input).attr('name') + ']').val('');
        $source[0].src = "";
        $source.parent()[0].load();
    }
}

function RemoveVideo(element) {
    var videoElement = $(element).closest('.video-collection').find('.video-element');
    $(videoElement).find('video').remove();
    var video = `<video idth="175" height="125" controls>
                         <source src="" type="video/mp4">
                 </video>`;
    $(videoElement).html(video);
    $("#GalleryVideoUpload").val('');
    $(element).closest('.video-collection').find('input[name=VideoUrl]').val('');
}
