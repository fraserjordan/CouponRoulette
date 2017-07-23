var onLoading = function () {
    $("header div").attr("aria-busy", true);
    $(".Button").prop('disabled', true);
    $("Input").prop('disabled', true);
}

var onLoadingFinish = function () {
    $("header div").attr("aria-busy", false);
    $(".Button").prop('disabled', false);
    $("Input").prop('disabled', false);
}

var showNotificationSlider = function (notification, duration) {

    var notifcationContent = notification;

    var div = $(".MainNotification");
    var notifcaitonContentContainer = $(".NotificationContent");

    notifcaitonContentContainer.html(notifcationContent);

    if ($(".Expand")[0]) {
        $(".Expand").bind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function () {
            div.addClass('Expand');
        });
        $(".Expand").removeClass('Expand');
    } else {
        div.addClass('Expand');
    }

    setTimeout(
        function() {
            div.removeClass('Expand');
        }, duration);
}

var HideNotificationSlider = function () {

    var div = $(".MainNotification");

    div.removeClass('Expand');
}

var expandSearch = function () {

    if ($(".Expand")[0]) {
    $(".Expand").bind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function () {
        $(".CustomerSearch").addClass('Expand');

        $(".Expand").unbind();
    });
    $(".Expand").removeClass('Expand');
    } else {
        $(".CustomerSearch").addClass('Expand');
    }
}

var collapseSearch = function () {
    $(".CustomerSearch").removeClass('Expand');
}