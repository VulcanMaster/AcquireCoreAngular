var z = 666;

console.log(z);

var theForm = document.getElementById("theForm");
theForm.hidden = true;

document.getElementById("buyButton").addEventListener("click", alertMe);

function alertMe() {
    alert("Buying item.")
    var theForm = document.getElementById("theForm");
    theForm.hidden = false;
}

//var button = document.getElementById("buyButton");

//button.addEventListener("click", function() {
//    alert("Buying item");
//});