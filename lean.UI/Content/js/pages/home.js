

$(document).ready(function () {
    $('#PropertyTypes').val('0');
    $('#UnitTypes').val('0');
    $('#Locations').val('0');


    $('#PropertyTypes').change(function () {
        PropertyUnitLocationChange();
    });
    $('#UnitTypes').change(function () {
        PropertyUnitLocationChange();
    });
    $('#Locations').change(function () {
        PropertyUnitLocationChange();
    });
});


function PropertyUnitLocationChange() {
    if ($('#PropertyTypes').val() !== '0' && $('#UnitTypes').val() !== '0' && $('#Locations').val() !== '0') {
        var property = parseInt($('#PropertyTypes').val());
        var unit = parseInt($('#UnitTypes').val());
        var location = parseInt($('#Locations').val());
        //window.location.href = 'Home/ProjectDetailsFilterd? PropertyTypeId ='+property+' & UnitTypeId =' + unit + '&LocationId = ' + location +'';
        window.location.href = `/Home/ProjectDetailsFilterd?PropertyTypeId=${property}&UnitTypeId=${unit}&LocationId=${location}`;
    }
}

function MoreNews() {
    let count = $('#NewsRemail .blog-box').length + 6;
    $.ajax({
        url: `/Home/MoreNews?count=${count}`,
        type: 'GET',
        async: true,
        success: function (res) {
            $('#NewsRemail').append(res);
        },
    });
}


// AJAX CALL
function AjaxCall(type, url, data, async, onSuccess, onComplete) {
    $.ajax({
        url: url,
        type: type ? type : 'POST',
        data: JSON.stringify(data),
        async: async ? async : true,
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (res) {
            if (onSuccess) { onSuccess(res); }
        },
        complete: function (res) {
            if (onComplete) { onComplete(res); }
        },
        error: function (error) {
            console.log('Ajax Call Error : ' + error);
        }
    });
}


function LoadPartial(divId, url, afterLoad = null) {
    $(divId).load(url, () => {
        if (afterLoad) afterLoad();
    });
}
