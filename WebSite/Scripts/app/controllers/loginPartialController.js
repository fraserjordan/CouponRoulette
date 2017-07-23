var module = angular.module('freeCouponsApp');

module.controller('loginPartialController', ['$scope', '$mdDialog',
    function ($scope, $mdDialog) {

        $scope.ShowCouponCode = function (id) {

                $.ajax({
                    type: "GET",
                    url: '/Customer/GetCouponCode?couponId=' + id,
                    success: function (data) {
                        $mdDialog.show(
                              $mdDialog.alert()
                                .clickOutsideToClose(true)
                                .title('Coupon code')
                                .textContent(data)
                                .ok('ok')
                            );
                    }
                });
            };
    }]);