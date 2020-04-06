
app.Pages.Users.Index = {

    OnPageLoad: function () {

        if ($.getUrlVar("keyword")) {
            this.Search($.getUrlVar("keyword"));
        }

        $("#btn-add-user").on("click",
            function () {
                location.href = "/users/add";
            });
    },
    Search: function(keyword) {
        
        app.UI.ShowLayerLoader();

        $.ajax({
            url: "/api/users?keyword=" + keyword,
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            success: function (data, status, jqxhr) {

                app.UI.HideLayerLoader();

                app.Pages.Users.Index.ClearList();

                app.Pages.Users.Index.PopulateResults(data);
            }
        });

    },
    ClearList: function() {
        $("#div-users").empty();
    },

    PopulateResults: function(data) {

        if (!data || data.length === 0) {
            $("#div-users").html("The search returned no results");
            return;
        }

        var container = $("#div-users");

        $.each(data, function (userIndex, user) {

            var groupNames = new Array();

            $.each(user.groups,
                function(groupIndex, group) {
                    groupNames.push(group.name);
                });

            var html = "";

            html += '<div class="user-list-row">';
            html += '<div class="name">' + user.firstName + ' ' + (user.lastName === null ? "":user.lastName) + '</div>';
            html += '<div class="memberof">Member of: ' + groupNames.join(', ') + '</div>';
            html += '</div>';
            
            container.append(html);
        });
    }
};