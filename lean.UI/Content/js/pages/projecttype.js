'use strict';

let modelAddTitle = AddProjectType;
let modelEditTitle = EditProjectType;
let targetFilterForm = '#ProjectTypeFilterForm';


function deleteProjectType(id) {
    Delete('/ProjectType/Delete', id, targetFilterForm);
}

function addProjectType() {
    LoadPartialInModal(`/ProjectType/ProjectTypePartial?id=${0}`, modelAddTitle);
}

function editProjectType(id) {
    LoadPartialInModal(`/ProjectType/ProjectTypePartial?id=${id}`, modelEditTitle);
}

function successSavingProjectType(data) {
    Success(data, targetFilterForm);
}
