//test

$(document).ready(function () {

    adjustIntranetMenu();

});

/**
* Method which strips out the pre-built menu and 
* re-build it in a separate intrant menu.
*/
function adjustIntranetMenu() {

    $("#menu").find("li").get(5).remove();

    var menuParent = $("#menu").parent();
    $(menuParent).append($("#intranetMenu"));

    $("#intranet").mouseenter(function () {
        $("#intranetMenu").fadeIn(100);
    });

    $("#intranetMenu").mouseenter(function () {
        $("#intranetMenu").show();

    }).mouseleave(function () {
        setTimeout(function () {
            $("#intranetMenu").fadeOut(100);
        }, 200);
    });
}