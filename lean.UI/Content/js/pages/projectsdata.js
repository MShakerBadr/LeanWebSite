'use strict';
let projectForm = '#ProjectForm';
let handleBarRowIdAmenities = '#ProjectAmenitieRow';
let tblProjectAmenities = '#tblProjectAmenities';
let prefixAmenities = 'ProjectAmenitie';
let handleBarRowIdPlanes = '#ProjectPlaneRow';
let tblProjectPlanes = '#tblProjectPlanes';
let prefixPlanes = 'ProjectPlane';
let handleBarRowIdGallerys = '#ProjectGalleryRow';
let tblProjectGallerys = '#tblProjectGallerys';
let prefixGallerys = 'ProjectGallery';
let PleaseFillRequiredFields = 'PleaseFillRequiredFields';


function AppendProjectAmenitieRow() {
    if (ValidateTable(tblProjectAmenities)) {
        var template = Handlebars.compile($(handleBarRowIdAmenities).html());
        var templateHtml = template({ Index: Number($(`${tblProjectAmenities} tbody tr`).length), Counter: Number($(`${tblProjectAmenities} tbody tr`).length + 1) });
        $(`${tblProjectAmenities} tbody`).append(templateHtml); // append
        OrderTableNames(tblProjectAmenities, prefixAmenities); // order
        RefreshRequiredInputsValidation();
    } else {
        WarningToast(PleaseFillRequiredFields);
    }
}

function RemoveProjectGalleryRow(element) {
    $(element).closest('div.img-collection').find('img').attr('src', defaultImage);
    $(element).closest('div.img-collection').find('input[type=hidden]').val('');
    $(element).closest('tr').remove();
    OrderTableNames(tblProjectGallerys, prefixGallerys); // order

}

function RemoveProjectAmenitieRow(element) {
    RemoveRow(element);
    OrderTableNames(tblProjectAmenities, prefixAmenities); // order
}

function AppendProjectPlaneRow() {
    if (ValidateTable(tblProjectPlanes)) {
        var template = Handlebars.compile($(handleBarRowIdPlanes).html());
        var templateHtml = template({ Index: Number($(`${tblProjectPlanes} tbody tr`).length), Counter: Number($(`${tblProjectPlanes} tbody tr`).length + 1) });
        $(`${tblProjectPlanes} tbody`).append(templateHtml); // append
        OrderTableNames(tblProjectPlanes, prefixPlanes); // order
        RefreshRequiredInputsValidation();
    } else {
        WarningToast(PleaseFillRequiredFields);
    }
}

function RemoveProjectPlaneRow(element) {
    RemoveRow(element);
    OrderTableNames(tblProjectPlanes, prefixPlanes); // order
}

function AppendProjectGalleryRow() {
    if (ValidateTable(tblProjectGallerys)) {
        var template = Handlebars.compile($(handleBarRowIdGallerys).html());
        var templateHtml = template({ Index: Number($(`${tblProjectGallerys} tbody tr`).length), Counter: Number($(`${tblProjectGallerys} tbody tr`).length + 1) });
        $(`${tblProjectGallerys} tbody`).append(templateHtml); // append
        OrderTableNames(tblProjectGallerys, prefixGallerys); // order
        RefreshRequiredInputsValidation();
    } else {
        WarningToast(PleaseFillRequiredFields);
    }
}

function SubmitForm() {
    $(projectForm).submit();

}
