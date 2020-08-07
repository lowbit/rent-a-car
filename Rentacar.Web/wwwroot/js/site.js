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