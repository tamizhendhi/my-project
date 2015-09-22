function confirmDelete() {
    var cnfrmVal;
    cnfrmVal = document.createElement("input");
    cnfrmVal.name = "confirmValue";
    cnfrmVal.type = "hidden";
    if (confirm("Are you sure want to cancel the booking?") == true) {
        cnfrmVal.value = "Yes";
    } else {
        cnfrmVal.value = "No";
    }
    document.forms[0].appendChild(cnfrmVal);
}
$(document).ready(function () {
    $("#profile ").css("display", "block");
   
    $(".layout div:nth-child(1) span:nth-of-type(2)").click(function () {

        $(".layout div:nth-child(3)").css("display", "block");
        $(".layout div:nth-child(4)").css("display", "none");
    });
   
    $(".layout div:nth-child(1) span:nth-of-type(3)").click(function () {

        $(".layout div:nth-child(4)").css("display", "block");
        $(".layout div:nth-child(3)").css("display", "none");
       
    });

});