
$(document).ready(function () {
    $("#profile ").css("display", "block");
   
    $(".layout div:nth-child(1) span:nth-of-type(2)").click(function () {

        $(".layout div:nth-child(3)").css("display", "block");
        $(".layout div:nth-child(5)").css("display", "none");
        $(".layout div:nth-child(4)").css("display", "none");
    });
   
    $(".layout div:nth-child(1) span:nth-of-type(3)").click(function () {

        $(".layout div:nth-child(4)").css("display", "block");
        $(".layout div:nth-child(3)").css("display", "none");
        $(".layout div:nth-child(5)").css("display", "none");
    });

});