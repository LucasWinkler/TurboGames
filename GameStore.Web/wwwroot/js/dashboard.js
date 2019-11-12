$(document).ready(function () {
    function toggleMatchMedia(mediaQuery) {
        if (mediaQuery.matches) {
            $('#menu-toggle-icon').removeClass();
            $('#menu-toggle-icon').addClass("fa-times");
        } else {
            $('#menu-toggle-icon').removeClass();
            $('#menu-toggle-icon').addClass("fa-bars");
        }
    }

    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
        $('#menu-toggle-icon').toggleClass("fa-bars fa-times");
    });

    var mediaQuery = window.matchMedia("(min-width: 768px)");

    toggleMatchMedia(mediaQuery);
    mediaQuery.addListener(toggleMatchMedia);
});