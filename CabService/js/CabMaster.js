$(document).ready(function () {
    $("marquee p:odd").css("background-color", "teal");
    $("marquee p:even").css("background-color", "silver");

   
    $("header span").click(function () {

        $("header div").toggle();
    });

    $("#ContentPlaceHolder1_txtUser,#txtOldpassword,#txtNewpassword,#txtConfirmpassword,#txtAdminid,#txtAdminmail").click(function () {
        $(this).attr("value", "")
    });
        $(".details center div span:first-child").click(function () {

        $(".addnewadmin").toggle();
    });
    $("#usersetting span:first-child").click(function () {

        $(".changepswd").toggle();
    });
    $(".details center div span:nth-of-type(2)").click(function () {

        $(".changepassword").toggle();
    });
    $("#ContentPlaceHolder1_btnlogin").click(function () {

        $("#profile").css("display","block");
    });
    $(".layout div ul:first-child > li span ").click(function () {

        $(".layout div ul:first-child ul").toggle();
    });

      
});