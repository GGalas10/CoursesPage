/*<!-- Cart --> */
function addToCart(courseId) {
    var button = document.getElementById('TestBtn');
    $.ajax({
        type: "POST",
        url: "/Shop/AddToCart",
        data: { courseId: courseId },
        beforeSend: function () {
            button.disabled = true;
            button.innerHTML = '<i class="fa fa-spinner fa-spin"></i> Dodawanie...';
        },
        success: function () {
            button.innerHTML = '<i class="fa fa-check"></i> Dodano do koszyka';
            button.classList.remove("btn-primary");
            button.classList.add("btn-success");
        },
        error: function () {
            button.innerHTML = '<i class="fa fa-times"></i> Error';
            button.classList.remove("btn-primary");
            button.classList.add("btn-danger");
        },
        complete: function () {
            button.disabled = false;
        },
    });
}
function DeleteFromCart(courseId) {
    var button = document.getElementById('TestBtn');
    $.ajax({
        type: "POST",
        url: "/Shop/DeleteFromCart",
        data: { courseId: courseId },
        beforeSend: function () {
            button.disabled = true;
            button.innerHTML = '<i class="fa fa-spinner fa-spin"></i> Usuwanie...';
        },
        success: function () {
            button.innerHTML = '<i class="fa fa-check"></i> Usuni�to z koszyka';
            button.classList.remove("btn-primary");
            button.classList.add("btn-success");
        },
        error: function () {
            button.innerHTML = '<i class="fa fa-times"></i> Error';
            button.classList.remove("btn-primary");
            button.classList.add("btn-danger");
        },
        complete: function () {
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
};
/*<!-- Cart --> */
/*<--- Shop Menu ---> */
window.onload= function() {
    console.log("Pobieranie kategori");
    var menuList = document.getElementById("CategoryList");
    $.ajax({
        type: "GET",
        url: "/Category/GetAllCategory",
        success: function (data) {
            $.each(data, function (oneCategory) {
                menuList.innerHTML +=`<a class="MenuItem" id="CategoryItem" data="${data[oneCategory].id}" onclick="CategoryClik(this)">${data[oneCategory].name}</a>`
            })          
        },
        error: function(error){
            console.log(error);
        }
    });
}
function CategoryClik(sender) {
    var data = String(sender.attributes.data.value);
    console.log(data);
    }
/*<--- Shop Menu ---> */