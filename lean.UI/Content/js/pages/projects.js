'use strict';

let targetFilterForm = '#ProjectsFilterForm';


function deleteProject(id) {
    Delete(`/Projects/Delete?code=${id}`, id, targetFilterForm);
}

function editProject(id) {
    window.location.href = `/Projects/ProjectData?code=${id}`;
}

function successSavingProject(data) {
    Success(data, targetFilterForm);
}
