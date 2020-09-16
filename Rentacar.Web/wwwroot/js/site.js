// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Delete Confirmation Modal
// Get the modal
var modal = document.getElementById('deletemodal');
// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

// On picture upload notify of file
$('#uploadPicture').on('change', function () {
    //get the file name
    var fileName = $(this).val();
    var index = fileName.lastIndexOf("\\");
    var result = 'File: ' + fileName.substr(index + 1) + ' is ready for upload.';
    //replace the "Choose a file" label
    $('.uploadPictureLabel label').append(result);
    $('.uploadPictureLabel span').empty();
})
//Readonly checkboxes
$('input[type="checkbox"]').on('click keyup keypress keydown', function (event) {
    if ($(this).is('[readonly]')) { return false; }
});

function GetNoOfNotifications() {
    tgt = $("#notifikacije");
    $.ajax({
        type: 'GET',
        url: '/Novosti/GetNumberOfNewNotifications',
        dataType: 'json',
        // success is called when dataset returns
        success: function (p) {
            console.log(p);
            tgt[0].innerText = p;
            if(p>0)
                tgt.addClass('notificationNumber');
        },
        error: function (data, status, error) {
            console.log(data);
            console.log(status);
            console.log(error);
        }
    });
}