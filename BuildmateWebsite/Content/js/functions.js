jQuery("document").ready(function ($) {
    var nav = $('body');

    $(window).scroll(function () {
        if ($(this).scrollTop() > 65) {
            nav.addClass("fixed-nav");
        } else {
            nav.removeClass("fixed-nav");
        }
    });

    $('.navbar-toggle').on('click', toggleNav);
});

function toggleNav() {
    $('.header').toggleClass('show-nav');
    return false;
}