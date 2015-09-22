
$(document).ready(function () {
    $(".rshift").css("display", "block");
    $(".bdiv li:first-child").click(function () {

       $(".rcab").css("display", "block");
        $(".rshift").css("display", "none");
        $(".rroute").css("display", "none");
    });

    $(".bdiv li:nth-child(2)").click(function () {

        $(".rshift").css("display", "block");
        $(".rcab").css("display", "none");
        $(".rroute").css("display", "none");
           });
    $(".bdiv li:nth-child(3)").click(function () {

        $(".rroute").css("display", "block");
        $(".rcab").css("display", "none");
        $(".rshift").css("display", "none");
    });

});