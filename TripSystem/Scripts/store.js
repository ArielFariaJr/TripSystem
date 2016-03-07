$(document).ready(function () {

    //build the trip gallery
    tripGallery();

    //fire the first link
    $($(".category-list").find("a").get(0)).click();


});

function tripGallery() {

    //Loop for every lin in the category list.
    $(".category-list").find("a").click(function(e) {

        //prevent link default function
        e.preventDefault();

        //hightlight the item selection
        $(".category-list").find("li").css("backgroundColor", "#807EA3");
        $(this).parent().css("backgroundColor", "#696892");

        //get the link to the detail
        var href = $(this).attr("href");

        $.get(href, function (data) {

            //clear the trip list container
            $("#list-trips").empty();

            //get the framework-generated galery list
            var ul = $(data).find("#album-list");
            
            //loop thru every trip
            $(ul).find("li").each(function (index) {

                //Build a detail object
                var detail = new Detail($($(this).find("span").get(0)).text(),
                    $(this).find("img").get(0),
                    $($(this).find("a").get(0)).attr("href"));
                console.log(detail);

                //create a div for the trip and append it to the container
                var div = $("<div class='trip' />");
                 $(div).css("backgroundImage", "url('" + detail.img.src + "')");
                var linkDetail = $("<a class='trip-title' />");
                $(linkDetail).attr("href", detail.link);
                $(linkDetail).text(detail.title);
                $(div).append(linkDetail);
                $("#list-trips").append(div);

            });

            //get the container height and hack the height of the whole page
            var tripListHeight = $("#list-trips").height();
            console.log(tripListHeight);
            $("#layout-fix").css("height", (tripListHeight + 40) + "px");

        });
    });
}

/**
* Trip detail class
*/
var Detail = function(title, img, link) {
    
    this.title = title;
    this.img = img;
    this.link = link;

}