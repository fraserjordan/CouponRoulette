(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('businessHomeController', [
        '$scope', '$mdDialog', '$mdToast', '$compile', 'state', 'alertService',
        function($scope, $mdDialog, $mdToast, $compile, state, alertService) {

            $scope.model = JSON.parse(state('index.model')).Model;
            $scope.isLoading = false;

            $scope.activateCouponModel = {
                selectedId: null,
                selectedAmount: null
            }

            $scope.deactivateCouponModel = {
                selectedId: null,
                selectedAmount: null
            }

            $scope.deleteCouponModel = {
                selectedId: null
            }

            $scope.amounts = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"];

            $scope.setSelectableAmounts = function(amountLeft) {
                for (var i = 0; i < amountLeft; i++) {
                    $scope.deactivateDeleteCouponsAmounts.push("" + i + "");
                }
            }

            $scope.activateCouponsDialog = function() {
                $mdDialog.show({
                    templateUrl: 'activateCouponsDialog.html',
                    clickOutsideToClose: true
                });
            }

            $scope.deactivateCouponsDialog = function() {
                $mdDialog.show({
                    templateUrl: 'deactivateCouponsDialog.html',
                    clickOutsideToClose: true
                });
            }

            $scope.deleteCouponsDialog = function() {
                $mdDialog.show({
                    templateUrl: 'deleteCouponsDialog.html',
                    clickOutsideToClose: true
                });
            }

            function reloadPage() {
                window.location.reload();
            }

            $scope.activateCoupon = function(form) {
                if (form.$valid) {
                    onLoading();
                    $scope.isLoading = true;
                    $.ajax({
                        type: "POST",
                        url: '/Coupon/ActivateCoupons',
                        data: {
                            couponId: $scope.activateCouponModel.selectedId,
                            amount: $scope.activateCouponModel.selectedAmount
                        },
                        success: function (data) {
                            onLoadingFinish();
                            $scope.isLoading = false;
                            if (data.Success) {
                                alertService.showAlert(data.Success, data.Messages[0], reloadPage);
                            } else {
                                alertService.showAlert(data.Success, data.Messages[0]);
                            }
                        }
                    });
                }
            }

            $scope.deactivateCoupon = function(form) {
                if (form.$valid) {
                    onLoading();
                    $scope.isLoading = true;
                    $.ajax({
                        type: "POST",
                        url: '/Coupon/DeactivateCoupons',
                        data: {
                            couponId: $scope.deactivateCouponModel.selectedId,
                            amount: $scope.deactivateCouponModel.selectedAmount
                        },
                        success: function (data) {
                            onLoadingFinish();
                            $scope.isLoading = false;
                            if (data.Success) {
                                alertService.showAlert(data.Success, data.Messages[0], reloadPage);
                            } else {
                                alertService.showAlert(data.Success, data.Messages[0]);
                            }
                        }
                    });
                }
            }

            $scope.deleteCoupon = function(form) {
                if (form.$valid) {
                    onLoading();
                    $scope.isLoading = true;
                    $.ajax({
                        type: "POST",
                        url: '/Coupon/DeleteCoupons',
                        data: {
                            couponId: $scope.deleteCouponModel.selectedId
                        },
                        success: function (data) {
                            onLoadingFinish();
                            $scope.isLoading = false;
                            if (data.Success) {
                                alertService.showAlert(data.Success, data.Messages[0], reloadPage);
                            } else {
                                alertService.showAlert(data.Success, data.Messages[0]);
                            }
                        }
                    });
                }
            }
        }
    ]);
}());