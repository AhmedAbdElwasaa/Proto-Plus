$(document).ready(function() {
    var theForm = $("#theForm");
    var button = $("#buyButton");
    var productInfo = $(".product-props li");


    //var listItems = productInfo.item[0].children;

    //console.log(listItems);


    theForm.hide();
    //theForm.hidden = true;

    button.on("click", function() {
        console.log("Buying Item!");
    });
    productInfo.on("click", function() {
        console.log("you clicked on" + $(this).text());


    });


    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function() {
        $popupForm.fadeToggle(1000);
    });








});





/* (function(){

})(); */