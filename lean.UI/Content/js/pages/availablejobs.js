'use strict';

let modelAddTitle = AddAvailableJobs;
let modelEditTitle = EditAvailableJobs;
let targetFilterForm = '#AvailableJobsFilterForm';


function deleteAvailableJobs(id) {
    Delete('/AvailableJobs/Delete', id, targetFilterForm);
}

function addAvailableJobs() {
    LoadPartialInModal(`/AvailableJobs/AvailableJobsPartial?id=${0}`, modelAddTitle);
}

function editAvailableJobs(id) {
    LoadPartialInModal(`/AvailableJobs/AvailableJobsPartial?id=${id}`, modelEditTitle);
}

function successSavingAvailableJobs(data) {
    Success(data, targetFilterForm);
}
