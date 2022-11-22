// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function onPetClicked(petId) {
    var btn = document.getElementById(petId);
    console.log("Pet");

    if (btn.style.color == 'grey') {
        console.log("red");
        btn.style.color = 'red';
    } else {
        console.log("grey");
        btn.style.color = 'grey';
    }

}
