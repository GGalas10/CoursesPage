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