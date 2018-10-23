$(document).ready(function () {

    $("#hide-btn").click(function () {
        $(".hide_content").hide();
    });

    $("#show-btn").click(function () {
        $(".hide_content").show();
    });

    $("#red-btn").click(function () {
        $("#mainJQ").children("p").toggleClass("red important");
    });

    $("#mainJQ").find("a").css({"color":"purple"});
});