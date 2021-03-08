'use strict';

let modelAddTitle = AddHeaderFooterPages;
let modelEditTitle = EditHeaderFooterPages;
let targetFilterForm = '#HeaderFooterPagessFilterForm';


function deleteHeaderFooterPages(id, userId) {
    Delete(`/Pages/Delete?userId=${userId}`, id, targetFilterForm);
}

function addHeaderFooterPages() {
    LoadPartialInModal(`/Pages/HeaderFooterPagesPartial?id=${0}`, modelAddTitle);
}

function editHeaderFooterPages(id) {
    LoadPartialInModal(`/Pages/HeaderFooterPagesPartial?id=${id}`, modelEditTitle);
}

function successSavingHeaderFooterPages(data) {
    if (data.Success) Success(data, targetFilterForm);
}
