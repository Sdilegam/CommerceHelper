// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleLeftBar(button){
    const leftBar = document.getElementById('left-side');
    const ListGrid = document.getElementById('ItemListGrid');
    const btn = document.getElementById("CloseLeftSideBtn");
    const classClosed = "classClosed";
    
    ListGrid.classList.toggle(classClosed);
    if(button.innerText == ">"){
        button.innerText= "<";
    }
    else{
        button.innerText= ">";
    }
}