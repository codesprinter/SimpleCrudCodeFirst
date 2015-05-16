
$(function () {
    $.ajaxSetup({ cache: false });
    bindEditDeleteActionLink();
});

function bindEditDeleteActionLink() {
    $('.modal-link').click(function () {
        $('#modalContent').load(this.href, function () {
            $('#modalDiv').modal({
                /*backdrop: 'static', */
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
}

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                $('#messageContainer').html(result);
                refreshCourseList();
                $('#modalDiv').modal('hide');
            }
        });
        return false;
    });
}
function refreshCourseList() {
    $('#courseList').load('/Department/GetListofDepartment', function () {
        bindEditDeleteActionLink();
    });
}