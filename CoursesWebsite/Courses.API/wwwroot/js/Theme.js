function GetTheme() {
    $(document).ready(function () {
            var theme = "test";
            $.ajax({
                url: '/UserConfiguration/GetTheme',
                type: 'GET',
                datatype: JSON,
                async: true,
                success: function (result) {
                    return result;
                },
                Error: function (error) {
                    console.log(error);
                }
            });
        });
}