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
        var li = $("a[href='" + value + "']").parent();
        var clone = $(li).clone(true)
        liItems.push(clone);
        $(li).hide();
    });

    //Create a new <LI> to host the new intranet menu.
    var intranetLi = "<li><a href='javascript:void(0)'>Intranet</a></li>";
    $("#menu").append(intranetLi);

    //Create a new UL for the intranet menu
    var menuParent = $("#menu").parent();
    var intranetUl = $("<ul id='intranetMenu' />");
    

    //Populate the UL with the LI elements collected before.
    $.each(liItems, function (key, value) {
        console.log(key + ": " + $(this).text());
        var li = $(this);
        $(intranetUl).append($(this));
    });

    $(menuParent).append(intranetUl);

    $(intranetLi).mouseover(function () {
        $(intranetUl).show();

    }).mouseout(function () {
        $(intranetUl).hide();
    });

}