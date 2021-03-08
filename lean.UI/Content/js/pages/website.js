'use strict';


function redirectToServices(ctype) {
    window.location.href = `/Home/Services?ctype=${ctype}`;
}

function loadServices(id) {
    LoadPartialInSpecialModal(`/Home/LoadService/${id}`);
}

function loadPreviousWork(id) {
    LoadPartialInSpecialModal(`/Home/LoadPreviousWork/${id}`);
}

function loadCertification(id) {
    LoadPartialInImageModal(`/Home/LoadCertification/${id}`);
}

function loadClient(id) {
    LoadPartialInImageModal(`/Home/LoadClient/${id}`);
}

function successSendingRequest(data) {
    if (data.Success) {
        SwalInfo(YourRequestSentSuccessfully);
        $('#contactRequestFrm input[type!=button],textarea').val('');
    } else {
        ErrorToast(ErrorSeningYourRequest);
    }
}


// navbar 
//let navCondition = window.location.href.toLowerCase().includes('/servicedepartments') || window.location.href.toLowerCase().includes('/previouswork') || window.location.href.toLowerCase().includes('/services') || window.location.href.toLowerCase().includes('/certifications');
//$(window).scroll((e) => {
//    if (navCondition && $(e.target).scrollTop() < 100) { $('.navbar').find('a.nav-link').css('color', 'black'); }
//    else if (navCondition) { $('.navbar').find('a.nav-link').css('color', 'white'); }
//});
//$(document).ready((e) => {
//    if (navCondition) {
//        $('.navbar').find('a.nav-link').css('color', 'black');
//    }
//});

