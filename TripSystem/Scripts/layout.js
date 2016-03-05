//test

$(document).ready(function () {
    
    hideIntranetMenu();

});

function hideIntranetMenu() {

    //Set up the arrays: one for the menus to be selected and initialize the <LI> collection.
    var menuItems = ["/Genero", "/Guia", "/Transportadora", "/Veiculo", "/Excurcao"];
    var liItems = [];

    //Loop thru the menus items do hide and collect to the <LI> colleciton.
    $.each(menuItems, function (key, value) {
        if ($("a[href='" + value + "']").size() > 0) {
            var li = $("a[href='" + value + "']").parent();
            liItems.push(li);
        }
    });

    console.log(liItems.length);
    if (liItems.length > 0) {

        //Create a new <LI> to host the new intranet menu.
        var intranetLi = $("<li><a href='javascript:void(0)'>Intranet</a></li>");
        $("#menu").append(intranetLi);

        //Create a new UL for the intranet menu
        var menuParent = $("#menu").parent();
        var intranetUl = $("<ul id='intranetMenu' />");

        //Populate the UL with the LI elements collected before.
        $.each(liItems, function (key, value) {
            $(intranetUl).append(this);
        });

        $(menuParent).append(intranetUl);

        $(intranetLi).mouseenter(function () {
            $(intranetUl).fadeIn(100);
        });

        $(intranetUl).mouseenter(function () {
            $(intranetUl).show();

        }).mouseleave(function () {
            setTimeout(function () {
                $(intranetUl).fadeOut(100);
            }, 200);
        });
    }
}