// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
async function  setClass(){

    const levelId = document.getElementById("LevelId").value
    console.log("123", levelId)
    const response = await fetch("/Admin/Classrooms/" + levelId)
    const data = await response.json()
    console.log(data)
    const selectInput = document.getElementById("ClassroomId");
    selectInput.innerHTML = `< option value = "" > </option>`;
    for (var item of data) {
        selectInput.innerHTML += `
            <option value = "${item.Id}">${item.Name}</option>
            `;
    }
}