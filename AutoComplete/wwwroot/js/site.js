// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#input").on("input", function () {
    $("#list1").empty();
    $("#list1").load("/Home/AutoComplete", { suche: $("#input").val() });
});