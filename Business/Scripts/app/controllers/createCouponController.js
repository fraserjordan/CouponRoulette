(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('createCouponController', [
        '$scope', '$mdDialog', '$mdToast', '$compile', 'alertService',
        function($scope, $mdDialog, $mdToast, $compile, alertService) {

            $scope.hideOtherOptions = true;
            $scope.hidePriceOptions = true;
            $scope.isLoading = false;

            $scope.couponModel = {
                title: "",
                type: "",
                quantitytOne: "",
                itemOne: "",
                multiplierOption: "",
                price: "",
                quantityTwo: "",
                itemTwo: ""
            }
            $scope.types = [{text: "Breakfast", value: 0 }, { text: "Lunch", value: 1 }, { text: "Dinner", value: 2 }];

            $scope.changeFreeOptionInput = function(val) {
                if (val === "for free") {
                    $scope.hideOtherOptions = true;
                    $scope.hidePriceOptions = true;
                    $scope.couponModel.price = "";
                    $scope.couponModel.quantityTwo = "";
                    $scope.couponModel.itemTwo = "";
                }
                else if (val === "for") {
                    $scope.hideOtherOptions = true;
                    $scope.hidePriceOptions = false;
                    $scope.couponModel.quantityTwo = "";
                    $scope.couponModel.itemTwo = "";
                } else {
                    $scope.hideOtherOptions = false;
                    $scope.hidePriceOptions = true;
                    $scope.couponModel.price = "";
                }
            }

            function redirect() {
                window.location = "/";
            }

            $scope.createCoupon = function() {
                onLoading();
                $scope.isLoading = true;
                $.ajax({
                    type: "POST",
                    url: '/Coupon/Create',
                    data: {
                        couponTitle: $scope.couponModel.title,
                        couponType: $scope.couponModel.type,
                        couponText: "Get " + $scope.couponModel.quantityOne + " " +
                            $scope.couponModel.itemOne + " " +
                            $scope.couponModel.multiplierOption + " " +
                            $scope.couponModel.price + " " +
                            $scope.couponModel.quantityTwo + " " +
                            $scope.couponModel.itemTwo
                    },
                    success: function (data) {
                        onLoadingFinish();
                        $scope.isLoading = false;
                        if (data.Success) {
                            alertService.showAlert(data.Success, data.Messages[0], redirect);
                        } else {
                            alertService.showAlert(data.Success, data.Messages[0]);
                        }
                    }
                });
            }

            $scope.quantityOptions = ["any", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"]
            $scope.multiplierOptions = ["for", "for free", "when you buy"]
        }
    ]);
}());