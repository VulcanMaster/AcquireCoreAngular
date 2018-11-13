$(document).ready(function () {


    var z = 666;

    console.log(z);

    var theForm = $("#theForm");
    theForm.hide();
    //theForm.hidden = true;

    $("#buyButton").on("click", alertMe);

    function alertMe() {
        alert("Buying Item.")
        var theForm = document.getElementById("theForm");
        theForm.hidden = false;
    }

    var productInfo = $(".product-props li")

    productInfo.on("click",
        function () {
            console.log("You clicked on " + $(this).text());
        });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function() {
        $popupForm.fadeToggle(1000);
    })
});


//var listItems = productInfo.item[0].children;
//document.getElementById("buyButton").addEventListener("click", alertMe);
//function alertMe() {
//    alert("Buying item.")
//    var theForm = document.getElementById("theForm");
//    theForm.hidden = false;
//}

//var button = document.getElementById("buyButton");

//button.addEventListener("click", function() {
//    alert("Buying item");
//});