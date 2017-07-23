(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('accountController', [
        '$scope', '$mdDialog',
        function($scope, $mdDialog) {

            $scope.ShowCouponCode = function(id, fromTime, toTime) {

                var currentTime = +new Date();
                var fromDate = new Date().setHours(fromTime, 0, 0, 0);
                var toDate = new Date().setHours(toTime, 0, 0, 0);

                if (currentTime >= fromDate && currentTime <= toDate) {
                    onLoading();

                    $.ajax({
                        type: "GET",
                        url: '/Customer/GetCouponCode?couponId=' + id,
                        success: function(data) {

                            onLoadingFinish();

                            $mdDialog.show(
                                $mdDialog.alert()
                                .clickOutsideToClose(true)
                                .title('Coupon code')
                                .textContent(data)
                                .ok('ok')
                            );
                        }
                    });
                } else {
                    showNotificationSlider("You can only redeem this coupon between the specified time of day.", 3000);
                }
            }
        }
    ]);
}());