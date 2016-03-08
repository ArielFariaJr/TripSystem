$(document).ready(function () {

    console.log("blah");
    setDetailViewer();


});

function setDetailViewer() {

    //Loop for every detail link in grids
    $(".grid").find("a[class='details']").click(function(e) {

        //prevent link default function
        e.preventDefault();

        //get the link to the detail
        var href = $(this).attr("href");

        $.get(href, function (data) {

            //clear the trip list container
            $("#display-detail").empty();

            //console.log(data);
            var fieldset = $(data).find("fieldset").get(0);

            var tb = $("<table class='grid'>");

            $(fieldset).find(".display-label").each(function (index) {

                var tr = $("<tr>");
                var th = $("<th width='30%'>" + $(this).text() + "</th>");

                if ($(this).text().indexOf("imagem") != -1) {

                    var url = $($(fieldset).find(".display-field").get(index)).text();
                    var img = "<img src = '"+url+"' class='display-image-preview' />";
                    var td = $("<td>" + img + "</td>");

                } else {
                    var td = $("<td>" + $($(fieldset).find(".display-field").get(index)).text() + "</td>");
                }
                
                $(tr).append(th);
                $(tr).append(td);
                $(tb).append(tr);
                
            });

            $("#display-detail").html(tb);

            //add the close button
            var close = $("<a href=javascript:void(0) class='close'>Fechar</a>");
            $("#display-detail").append(close);

            //add the overlay
            var overlay = $("<div class='overlay'>sdhsjkdfhsjk</div>");
            $(overlay).css("height", ($(window).height() - 10) + "px");
            $(body).append(overlay);


            //show the details panel and the overlay
            $(overlay).fadeIn(100);
            $("#display-detail").fadeIn(200);

            //hide panel and overlay at the close button
            $(close).click(function () {
                $(overlay).fadeOut(100);
                $("#display-detail").fadeOut(200);
            });

        });

    });
    
}