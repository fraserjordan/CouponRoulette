(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('createCouponController', [
        '$scope', 'state',
        function($scope, state) {


            $scope.hideOtherOptions = true;

            $scope.couponModel = {
                quantitytOne: "",
                itemOne: "",
                multiplierOption: "",
                quantityTwo: "",
                itemTwo: ""
            }

            $scope.changeFreeOptionInput = function(val) {
                if (val === "for free") {
                    $scope.hideOtherOptions = true;
                    $scope.couponModel.quantityTwo = "";
                    $scope.couponModel.itemTwo = "";

                } else {
                    $scope.hideOtherOptions = false;
                }
            }

            $scope.createCoupon = function() {
                $.ajax({
                    type: "POST",
                    url: '/Coupon/Create',
                    data: {
                        CouponDealText: "Get " + $scope.couponModel.quantityOne + " " +
                            $scope.couponModel.itemOne + " " +
                            $scope.couponModel.multiplierOption + " " +
                            $scope.couponModel.quantityTwo + " " +
                            $scope.couponModel.itemTwo
                    },
                    success: function(data) {
                        //finish loading
                    },
                    error: function(data) {
                        //finish loading, show error
                    }
                });
            }

            $scope.quantityOptions = ["any", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"]
            $scope.multiplierOptions = ["for free", "when you buy"]
        }
    ]);
}());