function OpenCart() {
    let cartDiv = document.getElementById("CartBtn");
    let check = cartDiv.classList.contains("Hidden");
    if (check == false) {
        $.ajax({
            url: "/Cart/GetCartProduct",
            type: "GET",
            datetype: "application/json",
            success: function (result) {
                cartDiv.innerHTML += `<div class="CartBox" id="CartBox">
                <p>Twój koszyk</p><div id="Products"></div></div>`;
                let productDiv = document.getElementById("Products");
                $.each(result, function (element) {
                    productDiv.innerHTML += `<p style="font-size:.6rem;">` + result[element] + `</p>`;
                })
                productDiv.innerHTML +=`<div class="CartBtn"><a href="/Cart/Index">Idź do koszyka</a></div>`
            },
    });        
        cartDiv.classList += "Hidden";
    }else {
        
        cartDiv.classList.remove("Hidden");
        document.getElementById("CartBox").remove();
    }
}