// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function setClass() {

    const levelId = document.getElementById("LevelId").value
    console.log("123", levelId)
    fetch("/Admin/Classrooms/" + levelId).then(response => {
        return response.json()
    }).then(data => {
        const selectInput = document.getElementById("ClassroomId");
        selectInput.innerHTML = `<option></option>`;
        for (var item of data) {
            console.log(selectInput);
            selectInput.innerHTML += `
                            <option value = "${item['id']}">${item['name']}</option>
                    `;
        }
    }).catch(err => console.log("err=> ", err))

}
function showFile() {
    const input = document.getElementById("File");
    const target = document.getElementById("show-file");
    console.log(input)
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            target.innerHTML = `<img src="${e.target.result}"  height="150" />`;
        };

        reader.readAsDataURL(input.files[0]);
    }
} 


async function AddModalData(SubjectName, ClassroomName) {
    console.log(SubjectName);
    console.log(ClassroomName);

    fetch(`/ManageClassrooms/${ClassroomName}/${SubjectName}/Add`).then(response => {
        console.log(response);
        return response.text();
    }).then(data => {
        document.getElementById("modal-body").innerHTML = data;
    })
}

