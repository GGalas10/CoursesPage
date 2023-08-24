function GetTheme() {
    let themeLink = document.getElementById("Theme");
    $(document).ready(function () {
            var theme = "test";
            $.ajax({
                url: '/User/GetUserTheme',
                type: 'GET',
                datatype: "application/json",
                async: true,
                success: function (result) {
                    console.log(themeLink);
                    themeLink.href = "/css/Themes/" + result + ".css";
                },
                Error: function (error) {
                    console.log(error);
                }
            });
        });
}
function ChangeTheme() {
    let themeLink = document.getElementById("Theme");
    $(document).ready(function () {
        var theme = "test";
        $.ajax({
            url: '/User/ChangeTheme',
            type: 'GET',
            datatype: "application/json",
            async: true,
            success: function (result) {
                console.log(themeLink);
                themeLink.href = "/css/Themes/" + result + ".css";
                location.reload(true);
            },
            Error: function (error) {
                console.log(error);
            }
        });
    });
}