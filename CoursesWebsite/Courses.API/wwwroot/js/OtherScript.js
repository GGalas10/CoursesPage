function CreateAdminPanel() {
    let divFroAdmin = document.getElementById("AdminPanelLink");
    $.ajax({
        url: "/User/CheckAdmin",
        type: 'GET',
        datatype: "application/json",
        success: function (result) {
            if (result) {
                divFroAdmin.innerHTML = 
                `
                <li class="nav-item">
                    <a class="nav-link text-dark" href="/API/PAdmin/Index">PAdmin</a>
                </li>`
            }
        },
        Error: function (error) {
            console.log(error);
        }
    })
}