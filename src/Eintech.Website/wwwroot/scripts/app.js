app = {

    OnLoad: function () {
        this.SetupErrorHandling();

        app.Search.Setup();

        if ($.getUrlVar("action")) {
            alert(decodeURI($.getUrlVar("action")));
        }
    },
    SetupErrorHandling: function () {

        $.ajaxSetup({
            error: function (xhr, status, error) {

                app.UI.HideLayerLoader();

                if (!xhr.responseText && !xhr.statusText) return;

                if (!xhr.responseText && xhr.statusText) {
                    alert(xhr.statusText);
                    return;
                };

                var jsonDetails = JSON.parse(xhr.responseText);

                var msg = jsonDetails[Object.keys(jsonDetails)[0]][0];

                alert(msg);
            }
        });
    }
};

app.Pages = {};
app.Pages.Users = {};

app.UI = {

    ShowLayerLoader: function () {

        var html = "";
        html += "<div class=\"layer-loader ui segment\">";
        html += "<div class=\"ui active dimmer\"><div class=\"ui large text loader\"><div></div>";
        html += "</div>";

        $("body").append(html);
        $("body").css("overflow", "hidden");
    },
    HideLayerLoader: function () {
        $(".layer-loader").remove();
        $("body").css("overflow", "auto");
    }
};

$.extend({

    getUrlVars: function () {

        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');

        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        };

        return vars;
    },
    getUrlVar: function (name) {
        return $.getUrlVars()[name];
    }

});
