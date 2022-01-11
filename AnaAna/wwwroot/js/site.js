// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const addChoice = () => {
    let containterChoice = document.getElementById("choices-container");
    let newInput = document.getElementById("choice-model").cloneNode(true);
    containterChoice.appendChild(newInput);
}

const removeChoice = (element) => {
    element.parentNode.remove(); 
}





window.addEventListener("DOMContentLoaded", () => {
    let selectorCategory = document.getElementById("selector-category");
    if (selectorCategory) {

        

        selectorCategory.addEventListener("change", (nameCategory) => {
            let url = nameCategory.target.value ? window.location.origin + `/Polls?category=${nameCategory.target.value}` :
                window.location.origin + `/Polls`; 
          window.location.href = url
        })
    }

    
    let openModalButton = document.getElementById("openModal");

    if (openModalButton) {
        let finishModal = new bootstrap.Modal(document.getElementById('modalCreate'));
        openModalButton.click(); 
    }

    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        const popoverId = popoverTriggerEl.attributes['data-content-id'];
        if (popoverId) {
            const contentEl = popoverTriggerEl.attributes['data-bs-content'].value;
            return new bootstrap.Popover(popoverTriggerEl, {
                html: true,
                content: '<span>' + contentEl + '</span>',
                trigger: "hover",
            });
        } else {//do something else cause data-content-id isn't there.
        }
    })







})