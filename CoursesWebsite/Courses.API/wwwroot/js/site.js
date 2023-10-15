/*<!-- Password check --> */
const passwordInput = document.getElementById('RegisterPassword');
passwordInput.addEventListener("input", function () {
    let password = passwordInput.value;
    let smallBox = document.getElementById('SmallSquare');
    let test = 0;
    let hasNumber = /\d/;
    let hasUpperCase = /[A-Z]/;
    let hasSpecialCharacter = /\W/;   
    if (hasNumber.test(password))
        test++;
    if (hasUpperCase.test(password))
        test++;
    if (hasSpecialCharacter.test(password))
        test++;
    if (password.length < 8)
        test = 0;
    else
        test++;
    if (test == 0) {
        smallBox.innerHTML = "";
    };
    if (test == 1) {
        smallBox.style.background = "linear-gradient(to right, red 25%, white 25%)";
        smallBox.innerHTML = "Słabe hasło";
    };
    if (test == 2) {
        smallBox.style.background = "linear-gradient(to right, orange 50%, white 50%)"; 
        smallBox.innerHTML = "Średnie hasło";
    };
    if (test == 3) {
        smallBox.style.background = "linear-gradient(to right, green 75%, white 25%)";
        smallBox.innerHTML = "Silne hasło";
    };
    if (test == 4) {
        smallBox.style.background = "linear-gradient(to right, darkgreen 100%, white 0%)"
        smallBox.style.width = "100%";
        smallBox.innerHTML = "Bardzo sile hasło";
    };
});
/*<!-- Password check --> */