
index = {

    OnPageLoad: function() {

        $("#btn-add-user").on("click",
            function() {
                location.href = "/users/add";
            });
    }
};