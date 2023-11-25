function ResizeMenu() {
    var menu = document.getElementById("Menu");
    if (menu.classList.contains("Resize")){
        menu.style.left = '-7.1rem';
        menu.classList.remove("Resize");
    } else {
        menu.style.left = 0;
        menu.classList.add("Resize");
    }
}
function LoginUser() {
    var email = document.getElementById("Email");
    var password = document.getElementById("Password");
    var loginUser = new Object();
    loginUser.name = email.value;
    loginUser.password = password.value;
    $.ajax({
        url: "/API/PAdmin/Login",
        type: "POST",
        contentType: 'application/json',
        data: JSON.stringify(loginUser),
        success: function (data) {

        }, error: function (xhr) {
            console.log(xhr);
        }
    })
}