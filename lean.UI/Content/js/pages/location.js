'use strict';

let modelAddTitle = AddLocation;
let modelEditTitle = EditLocation;
let targetFilterForm = '#LocationFilterForm';


function deleteLocation(id) {
    Delete('/Location/Delete', id, targetFilterForm);
}

function addLocation() {
    LoadPartialInModal(`/Location/LocationPartial?id=${0}`, modelAddTitle);
}

function editLocation(id) {
    LoadPartialInModal(`/Location/LocationPartial?id=${id}`, modelEditTitle);
}

function successSavingLocation(data) {
    Success(data, targetFilterForm);
}
