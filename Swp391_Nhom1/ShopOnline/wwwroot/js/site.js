// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.onload = load();

function load() {
    $('.owl-one').owlCarousel({
        autoplay: true,
        loop: true,
        margin: 10,
        items: 1,
        nav: true,
        dotSpeed: 100,
    })

    var owl = $('.owl-carousel');
    $('.owl-dot').click(function () {
        owl.trigger('to.owl.carousel', [$(this).index(), 300]);
    });
}
