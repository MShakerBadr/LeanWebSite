'use strict';

let modelAddTitle = AddPropertyType;
let modelEditTitle = EditPropertyType;
let targetFilterForm = '#PropertyTypeFilterForm';


function deletePropertyType(id) {
    Delete('/PropertyType/Delete', id, targetFilterForm);
}

function addPropertyType() {
    LoadPartialInModal(`/PropertyType/PropertyTypePartial?id=${0}`, modelAddTitle);
}

function editPropertyType(id) {
    LoadPartialInModal(`/PropertyType/PropertyTypePartial?id=${id}`, modelEditTitle);
}

function successSavingPropertyType(data) {
    Success(data, targetFilterForm);
}
