var onLoading = function() {
    $("header div").attr("aria-busy", true);
    $("button").prop('disabled', true);
    $("input").prop('disabled', true);
}

var onLoadingFinish = function() {
    $("header div").attr("aria-busy", false);
    $("button").prop('disabled', false);
    $("input").prop('disabled', false);
}

function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail());
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}

var showNotificationSlider = function(notification, duration) {

    var notifcationContent = notification;

    var div = $(".MainNotification");
    var notifcaitonContentContainer = $(".NotificationContent");

    notifcaitonContentContainer.html(notifcationContent);

    if ($(".Expand")[0]) {
        $(".Expand").bind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function() {
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

var HideNotificationSlider = function() {

    var div = $(".MainNotification");

    div.removeClass('Expand');
}

var expandSearch = function() {

    if ($(".Expand")[0]) {
        $(".Expand").bind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function() {
            $(".CustomerSearch").addClass('Expand');

            $(".Expand").unbind();
        });
        $(".Expand").removeClass('Expand');
    } else {
        $(".CustomerSearch").addClass('Expand');
    }
}

var collapseSearch = function() {
    $(".CustomerSearch").removeClass('Expand');
}