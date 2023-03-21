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
    if (password.length <= 8)
        test = 0;
    else
        test++;
    if (test == 0) {
        smallBox.innerHTML = "";
        smallBox.style.width = "0%";
    };
    if (test == 1) {
        smallBox.style.backgroundColor = "red";
        smallBox.style.width = "25%";
        smallBox.innerHTML = "Słabe hasło";
    };
    if (test == 2) {
        smallBox.style.backgroundColor = "orange";
        smallBox.style.width = "50%";
        smallBox.innerHTML = "Średnie hasło";
    };
    if (test == 3) {
        smallBox.style.backgroundColor = "green";
        smallBox.style.width = "75%";
        smallBox.innerHTML = "Silne hasło";
    };
    if (test == 4) {
        smallBox.style.backgroundColor = "darkgreen";
        smallBox.style.width = "100%";
        smallBox.innerHTML = "Bardzo sile hasło";
    };
});
/*<!-- Password check --> */

/*<!-- Cart --> */
function addToCart(courseId) {
    var button = document.getElementById('TestBtn'); // pobieramy element Button z HTML
    $.ajax({
        type: "POST",
        url: "/Shop/AddToCart", // adres URL do metody kontrolera
        data: { courseId: courseId }, // przekazujemy parametr courseId
        beforeSend: function () {
            // wyświetlamy animację ładowania
            button.disabled = true;
            button.innerHTML = '<i class="fa fa-spinner fa-spin"></i> Adding to cart...';
        },
        success: function () {
            // jeśli dodanie do koszyka się powiedzie, aktualizujemy stan przycisku
            button.innerHTML = '<i class="fa fa-check"></i> Added to cart';
            button.classList.remove("btn-primary");
            button.classList.add("btn-success");
        },
        error: function () {
            // jeśli dodanie do koszyka się nie powiedzie, wyświetlamy komunikat błędu
            button.innerHTML = '<i class="fa fa-times"></i> Error';
            button.classList.remove("btn-primary");
            button.classList.add("btn-danger");
        },
        complete: function () {
            // kończymy animację ładowania i przywracamy przycisk do pierwotnego stanu
            button.disabled = false;
        },
    });
}
function test() {
    $.ajax({
        type: "POST",
        url: "/Shop/Test",
        data: { param1: "value1", param2: "value2" },
        success: function (result) {
            $("#Test").html(result);
        },
        error: function (error) {
            console.log(error);
        }
    });
}
/*<!-- Cart --> */