(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('contactController', ['$scope', 'alertService',
        function ($scope, alertService) {
            $scope.emailName = "";
            $scope.emailFrom = "";
            $scope.emailBody = "";

            $scope.sendEmail = function(form) {
                if (form.$valid) {
                    onLoading();
                    $.ajax({
                        type: "POST",
                        url: '/Home/SendEmail',
                        data: {
                            EmailName: $scope.emailName,
                            EmailFrom: $scope.emailFrom,
                            EmailBody: $scope.emailBody
                        },
                        success: function (data) {
                            if (data.Success) {
                                onLoadingFinish();
                                $scope.emailName = "";
                                $scope.emailFrom = "";
                                $scope.emailBody = "";
                                alertService.showAlert(true, 'An email has been sent, we will get back to you shortly.');
                            } else {
                                onLoadingFinish();
                                alertService.showAlert(false, 'An error was encountered while attempting to send an email, please try again.');
                            }
                        }
                    });
                } else {
                    common.showRemainingValidation(form);
                }
            }

            var myLatLng = { lat: -36.897295, lng: 174.823737 };

            map = new google.maps.Map(document.getElementsByClassName("business-location")[0], {
                center: myLatLng,
                zoom: 15,
                draggable: false,
                scrollwheel: false,
                disableDefaultUI: true
            });
            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                title: "Simple Coupons"
            });
        }
    ]);
}());