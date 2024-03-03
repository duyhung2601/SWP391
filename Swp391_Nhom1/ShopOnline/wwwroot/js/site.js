// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.owl-carousel').owlCarousel({
        item:1,
        loop: true,
        autoplayTimeout: 3000,
        margin: 10,
        nav: true,
        autoplay: true,
    })
});