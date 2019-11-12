(function () {
    function toggleMatchMedia(mediaQuery) {
        if (mediaQuery.matches) {
            $('#menu-toggle-icon').toggleClass("fa-bars fa-times");
        } else {
            $('#menu-toggle-icon').toggleClass("fa-times fa-bars");
        }
    }

    var mediaQuery = window.matchMedia("(min-width: 768px)");

    toggleMatchMedia(mediaQuery);
    mediaQuery.addListener(toggleMatchMedia);

    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
        $('#menu-toggle-icon').toggleClass("fa-bars fa-times");
    });
})();