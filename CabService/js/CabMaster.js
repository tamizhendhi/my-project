$(document).ready(function () {
    $("marquee p:odd").css("background-color", "teal");
    $("marquee p:even").css("background-color", "silver");

   
    $("header span").click(function () {

        $("header div").toggle();
    });

    $("#ContentPlaceHolder1_txtUser,#ContentPlaceHolder1_txtcanceldate,#txtOldpassword,#txtNewpassword,#ContentPlaceHolder1_txtPassword,#txtConfirmpassword,#txtAdminid,#txtAdminmail").click(function () {
        $(this).attr("value", "")
    });
        $("#lblAddadmin").click(function () {

        $(".addnewadmin").toggle();
    });
    $("#lblChangepswd").click(function () {

        $(".changepswd").toggle();
    });
    $("#lblChpswd").click(function () {

        $(".changepassword").toggle();
    });
    $("#ContentPlaceHolder1_btnlogin").click(function () {

        $("#profile").css("display","block");
    });
    $(".layout div ul:first-child > li span ").click(function () {

        $(".layout div ul:first-child ul").toggle();
    });
    $("header ul a").each(function (index) {
        if (this.href.trim() == window.location)
            $(this).addClass("style");
    });
      
});