
function successSavingStaticContent(data) {
    debugger;
    if (!$('#ChairManPhotoUpload').val() && !$('#AboutUsPhotoUpload').val() && !$('#AboutUsBannerPhotoUpload').val() && !$('#ProjectBannerPhotoUpload').val()
        && !$('#NewsBannerPhotoUpload').val() && !$('#ContactBannerPhotoUpload').val() && !$('#DeliveredBannerPhotoUpload').val()
        && !$('#GalleryBannerPhotoUpload').val()) {
        Success(data);
        return;
    }
    if (data.Success) {
        debugger;
        UploadFile($('#ChairManPhotoUpload'), `/StaticContent/SaveChairManPhoto`, () => { Success(data); });

        UploadFile($('#AboutUsPhotoUpload'), `/StaticContent/SaveAboutUsPhoto`, () => { Success(data); });

        UploadFile($('#AboutUsBannerPhotoUpload'), `/StaticContent/SaveAboutUsBannerPhoto`, () => { Success(data); });

        UploadFile($('#ProjectBannerPhotoUpload'), `/StaticContent/SaveProjectBannerPhoto`, () => { Success(data); });

        UploadFile($('#NewsBannerPhotoUpload'), `/StaticContent/SaveNewsBannerPhoto`, () => { Success(data); });

        UploadFile($('#ContactBannerPhotoUpload'), `/StaticContent/SaveContactBannerPhoto`, () => { Success(data); });

        UploadFile($('#DeliveredBannerPhotoUpload'), `/StaticContent/SaveDeliveredBannerPhoto`, () => { Success(data); });

        UploadFile($('#GalleryBannerPhotoUpload'), `/StaticContent/SaveGalleryBannerPhoto`, () => { Success(data); });



    }
}
