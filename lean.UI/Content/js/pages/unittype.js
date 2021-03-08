'use strict';

let modelAddTitle = AddUnitType;
let modelEditTitle = EditUnitType;
let targetFilterForm = '#UnitTypeFilterForm';


function deleteUnitType(id) {
    Delete('/UnitType/Delete', id, targetFilterForm);
}

function addUnitType() {
    LoadPartialInModal(`/UnitType/UnitTypePartial?id=${0}`, modelAddTitle);
}

function editUnitType(id) {
    LoadPartialInModal(`/UnitType/UnitTypePartial?id=${id}`, modelEditTitle);
}

function successSavingUnitType(data) {
    Success(data, targetFilterForm);
}
