//test

$(document).ready(function () {
    
    adjustLogo();
    hideIntranetMenu();

});

function adjustLogo() {
   
    var href = document.location.href;

    if (Utils.isHome(href)) {
        $("#logo").removeClass("logo_content");
        $("#logo").addClass("logo_home");
    } else {
        $("#logo").removeClass("logo_home");
        $("#logo").addClass("logo_content");
    }

}

/**
* Method which strips out the pre-built menu and 
* re-build it in a separate intrant menu.
*/
function hideIntranetMenu() {

    //Small fix to remove empty <li> elements from menu.
    $("#menu").find("li").get(3).remove();

    //Set up the arrays: one for the menus to be selected and initialize the <LI> collection.
    var menuItems = ["/Genero", "/Guia", "/Transportadora", "/Veiculo", "/Excurcao", "/Home/ListaEmbarque"];
    var liItems = [];

    //Loop thru the menus items do hide and collect to the <LI> colleciton.
    $.each(menuItems, function (key, value) {
        if ($("a[href='" + value + "']").size() > 0) {
            var li = $("a[href='" + value + "']").parent();
            liItems.push(li);
        }
    });

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

/** UTILS **/
var Utils = {
    isHome: function (href) {
        var slashes = (href.match(/\//g) || []).length;
        if (slashes == 3 && href.indexOf("?") == -1) {
            return true;
        } else {
            return false;
        }
    }
}