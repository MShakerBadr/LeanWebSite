'use strict';

let targetFilterForm = '#JobRequestFilterForm';


function deleteJobRequest(id) {
    Delete('/JobRequests/Delete', id, targetFilterForm);
}

