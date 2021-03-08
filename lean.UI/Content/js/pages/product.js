'use strict';

let modelAddTitle = AddProduct;
let modelEditTitle = EditProduct;
let targetFilterForm = '#ProductFilterForm';


function deleteProduct(id, userId) {
    Delete(`/Product/Delete`, id, targetFilterForm);
}

function addProduct() {
    LoadPartialInModal(`/Product/ProductPartial?id=${0}`, modelAddTitle);
}

function editProduct(id) {
    LoadPartialInModal(`/Product/ProductPartial?id=${id}`, modelEditTitle);
}

function successSavingProduct(data) {
  
    if (!$('#ProductPhotoUpload').val()) {
        Success(data, targetFilterForm);
        return;
    }
    if (data.Success) {
       
        UploadFile($('#ProductPhotoUpload'), `/Product/SaveProductPhoto?productId=${data.Data.productId}`, () => { Success(data, targetFilterForm); });
    }
}

function UploadWhatWeDeliveredAttachment(element) {
    let WhatWeDeliveredId = $(element).attr('data-target-id');
    UploadFile(element, '/Product/UploadWhyUsAttachment?whyUsId=' + WhatWeDeliveredId + '', function (res) {
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
        AjaxCall('POST', '/Product/DeleteImg', { path: ImgPathToDelete }, true, function (res) {
        //if (res === true) {
        //    $(element).closest('.img-item').remove();
        //}
    });
    }

}

function DeleteDeliveredAttachment(element) {
    let imgId = $(element).attr('data-img-id');
    AjaxCall('POST', '/Product/RemoveWhyUSAttachmentImg', { imgId: imgId }, true, function (res) {
        if (res === true) {
            $(element).closest('.img-item').remove();
        }
    });
}
