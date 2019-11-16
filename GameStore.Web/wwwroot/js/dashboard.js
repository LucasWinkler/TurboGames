(function () {
    function toggleMatchMedia(mediaQuery) {
        if (mediaQuery.matches) {
            if (!$('#menu-toggle-icon').hasClass('fa-bars fa-times')) {
                $('#menu-toggle-icon').addClass("fa-bars");
                $('#menu-toggle').addClass("btn-primary");
            }
            $('#menu-toggle-icon').toggleClass("fa-bars fa-times");
            $('#menu-toggle').toggleClass("btn-primary btn-danger");
        } else {
            if (!$('#menu-toggle-icon').hasClass('fa-bars fa-times')) {
                $('#menu-toggle-icon').addClass("fa-times");
                $('#menu-toggle').addClass("btn-danger");
            }
            $('#menu-toggle-icon').toggleClass("fa-bars fa-times");
            $('#menu-toggle').toggleClass("btn-primary btn-danger");
        }
    }

    var mediaQuery = window.matchMedia("(min-width: 768px)");

    toggleMatchMedia(mediaQuery);
    mediaQuery.addListener(toggleMatchMedia);

    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
        $('#menu-toggle-icon').toggleClass("fa-bars fa-times");
        $('#menu-toggle').toggleClass("btn-primary btn-danger");
    });
})();