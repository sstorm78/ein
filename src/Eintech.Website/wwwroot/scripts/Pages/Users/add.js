
app.Pages.Users.Add = {
    OnPageLoad: function() {
        $("#btn-create").on("click", app.Pages.Users.Add.Submit);
    },
    
    Submit: function () {

        if (!app.Pages.Users.Add.IsValid()) return;

        app.UI.ShowLayerLoader();

        var payload = {
            FirstName: $("#txt-first-name").val(),
            LastName: $("#txt-last-name").val(),
            Groups: [{
                Id: $("#ddl-group").val()
            }]
        };

        $.ajax({
            url: "/api/users",
            type: "POST",
            data: JSON.stringify(payload),
            dataType: "text",
            contentType: "application/json",
            success: function (data, status, jqxhr) {
                window.location.assign("/?action=" + encodeURI("User was created"));
            }
        });

    },

    IsValid: function () {
        
        if (!$("#txt-first-name").val() || $("#txt-first-name").val().length < 2) {
            alert("Please enter first name");
            return false;
        }

        if (!$("#ddl-group").val()) {
            alert("Select a group");
            return false;
        }
        
        return true;
    }
};