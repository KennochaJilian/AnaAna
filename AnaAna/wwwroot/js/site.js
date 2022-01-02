// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const addChoice = () => {
    let containterChoice = document.getElementById("choices");
    let button = document.getElementById("add-choice-button"); 
    let newInput = document.getElementById("choice-model").cloneNode(true);
    newInput.type = "text";
    containterChoice.insertBefore(newInput, button);
}