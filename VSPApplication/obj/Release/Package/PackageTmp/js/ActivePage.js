$(function () {
    setNavigation();
});

function setNavigation() {
    var path = window.location.pathname;
    path = path.replace(/\/$/, "");
    path = decodeURIComponent(path);


    $(".sidebar-menu li a").each(function () {
        var href = $(this).attr('href');

        if (path.substring(0, href.length) === href) {
            $('.sidebar-menu li.active').removeClass('active');
            $(this).closest('li').addClass('active');
        }
    });
}