
app.Search = {

    Setup: function() {
        $("#btn-search").on("click",
            function () {
                app.Search.Search();
            });

        $("#txt-search-keyword").keypress(function (e) {
            if ((e.which && e.which === 13) || (e.keyCode && e.keyCode === 13)) {
                app.Search.Search();
            }
        });
    },

    Search: function() {

        if (!this.IsValid()) return;

        location.href = "/users?keyword=" + encodeURI($("#txt-search-keyword").val());
    },
    IsValid: function () {

        if (!$("#txt-search-keyword").val() || $("#txt-search-keyword").val().length < 2) {
            alert("Please enter a keyword");
            return false;
        }

        return true;
    }
};