'use strict';

let modelAddTitle = AddSlider;
let modelEditTitle = EditSlider;
let modalAddUserTitle = 'AddUserTitle';
let modalViewUserTitle = 'ViewUserTitle';
let targetFilterForm = '#SliderFilterForm';
let targetRemoveUserForm = '#removeUserFrm';


function deleteSlider(id, userId) {
    Delete(`/Slider/Delete?userId=${userId}`, id, targetFilterForm);
}

function addSlider() {
    LoadPartialInModal(`/Slider/SliderPartial?id=${0}`, modelAddTitle);
}

function editSlider(id) {
    LoadPartialInModal(`/Slider/SliderPartial?id=${id}`, modelEditTitle);
}

function successSavingSlider(data) {
    if (!$('#SliderPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
        UploadFile($('#SliderPhotoUpload'), `/Slider/SaveSliderPhoto?SliderId=${data.Data.SliderId}`, () => { Success(data, targetFilterForm); });
    }
}
