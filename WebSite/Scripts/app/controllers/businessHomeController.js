var module = angular.module('freeCouponsApp');

module.controller('businessHomeController', ['$scope', '$mdDialog', '$mdToast', '$compile',
    function ($scope, $mdDialog, $mdToast, $compile) {

        $scope.CouponTitle = "";
        $scope.CouponValue = "";
        $scope.CouponCount = "";
        $scope.CouponCategory = "";
        $scope.CouponPassword = "";
        $scope.validFrom = "";
        $scope.FromTimeFormat = 1;
        $scope.validTo = "";
        $scope.ToTimeFormat = 2;
        $scope.selectedCouponId = "";
        $scope.couponAmount = "";

        $scope.selectedCouponEditId = "";
        $scope.editCouponTitle = "";
        $scope.editCouponCategory = "";
        $scope.editValidFrom = "";
        $scope.editValidTo = "";
        $scope.editCouponPassword = "";

        $scope.couponCode = "";

        $scope.addCouponModel = {
            selectedId: 0,
            selectedAmount: 0
        }

        $scope.amounts = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"]

        $scope.savedCoupons = [
            { id: 1, text: "One free hamburger" },
            { id: 2, text: "One free hamburger" },
            { id: 3, text: "One free hamburger" },
            { id: 4, text: "One free hamburger" },
        ];

        $scope.openMenu = function ($mdOpenMenu, ev) {
            originatorEv = ev;
            $mdOpenMenu(ev);
        };

        $scope.createCouponDialog = function () {

            $mdDialog.show({
                templateUrl: 'createcoupon.html',
                clickOutsideToClose: true
            });
        }

        $scope.addNewCouponDialog = function () {
            $mdDialog.show({
                templateUrl: 'addcoupon.html',
                clickOutsideToClose: true
            });
        }

        $scope.addNewCoupon = function () {

            onLoading();

            $.ajax({
                type: "POST",
                url: '/Business/AddCoupon',
                data: {
                    id: $scope.selectedCouponId,
                    amount: $scope.couponAmount
                },
                success: function (data) {

                    onLoadingFinish();

                    $("#MainBody").html(data);
                    $compile($("body"))($scope);

                    showNotificationSlider("Coupon(s) successfully added", 2000);

                    $mdDialog.cancel();
                }
            });
        }

        $scope.loadEditObject = function () {

            onLoading();

            $.ajax({
                type: "GET",
                url: '/Business/GetSavedCoupon',
                data: {
                    id: $scope.selectedCouponEditId
                },
                success: function (data) {

                    onLoadingFinish();

                    var coupon = JSON.parse(data);

                    $scope.editCouponTitle = coupon.Title;
                    $scope.editCouponCategory = coupon.Category;
                    $scope.editValidFrom = coupon.ValidFrom.substring(11, coupon.ValidFrom.indexOf(":"));
                    $scope.editValidTo = coupon.ValidTo.substring(11, coupon.ValidTo.indexOf(":"));
                }
            });
        }

        $scope.editCouponDialog = function () {
            $mdDialog.show({
                templateUrl: 'editcoupon.html',
                clickOutsideToClose: true
            });
        }



        $scope.editCoupon = function () {

            onLoading();

            $.ajax({
                type: "POST",
                url: '/Business/EditCoupon',
                data: {
                    id: $scope.selectedCouponEditId,
                    title: $scope.editCouponTitle,
                    category: $scope.editCouponCategory,
                    validFrom: $scope.editValidFrom,
                    validTo: $scope.editValidTo,
                    password: $scope.editCouponPassword
                },
                success: function (data) {

                    onLoadingFinish();

                    $("#MainBody").html(data);
                    $compile($("body"))($scope);

                    $mdDialog.cancel();

                    showNotificationSlider("Coupon successfully saved", 2000);
                }
            });
        };

        $scope.deleteCouponDialog = function () {
            $mdDialog.show({
                templateUrl: 'deletecoupon.html',
                clickOutsideToClose: true
            });
        }

        $scope.deleteSavedCoupon = function () {

            onLoading();

            $.ajax({
                type: "POST",
                url: '/Business/DeleteSavedCoupon',
                data: {
                    id: $scope.selectedCouponId
                },
                success: function (data) {

                    onLoadingFinish();

                    $("header div").attr("aria-busy", false);
                    $(".Button").prop('disabled', false);

                    $("#MainBody").html(data);
                    $compile($("body"))($scope);

                    $mdDialog.cancel();

                    showNotificationSlider("coupon successfully deleted", 2000);
                }
            });
        };

        $scope.deleteSingleActiveCoupon = function () {

            onLoading();

            $.ajax({
                type: "POST",
                url: '/Business/DeleteSingleActiveCoupon',
                data: {
                    id: $scope.selectedCouponId
                },
                success: function (data) {

                    onLoadingFinish();

                    $("header div").attr("aria-busy", false);
                    $(".Button").prop('disabled', false);

                    $("#MainBody").html(data);
                    $compile($("body"))($scope);

                    $mdDialog.cancel();

                    showNotificationSlider("Coupon successfully deleted", 2000);
                }
            });
        };

        $scope.deleteAllActiveCoupon = function () {

            onLoading();

            $.ajax({
                type: "POST",
                url: '/Business/DeleteAllActiveCoupon',
                data: {
                    id: $scope.selectedCouponId
                },
                success: function (data) {

                    onLoadingFinish();

                    $("header div").attr("aria-busy", false);
                    $(".Button").prop('disabled', false);

                    $("#MainBody").html(data);
                    $compile($("body"))($scope);

                    $mdDialog.cancel();

                    showNotificationSlider("All coupons successfully deleted", 2000);
                }
            });
        };


        $scope.createCoupon = function () {

            onLoading();

            $.ajax({
                type: "POST",
                url: '/Business/CreateCoupon',
                data: {
                    title: $scope.CouponTitle,
                    validFrom: $scope.validFrom,
                    validTo: $scope.validTo,
                    category: $scope.CouponCategory,
                    password: $scope.CouponPassword
                },
                success: function (data) {

                    onLoadingFinish();

                    $("#MainBody").html(data);
                    $compile($("body"))($scope);

                    showNotificationSlider("Coupon successfully created", 2000);

                    $mdDialog.cancel();
                },
                error: function () {

                    onLoadingFinish();

                    $mdDialog.cancel();

                    showNotificationSlider("Error creating coupon, please try again", 2000);

                }
            });
        }

        $scope.showRedeemCouponDialog = function () {

            $mdDialog.show({
                templateUrl: 'redeemcoupon.html',
                clickOutsideToClose: true
            });
        };

        $scope.redeemCoupon = function () {

            onLoading();

            $.ajax({
                type: "POST",
                url: '/Business/RedeemCoupon',
                data: {
                    code: $scope.couponCode
                },
                success: function (data) {

                    onLoadingFinish();

                    $("#MainBody").html(data);
                    $compile($("body"))($scope);

                    $mdDialog.cancel();

                    showNotificationSlider("Coupon successfully redeemed", 2000);

                }
            });
        }

        $scope.DeleteSingleCoupon = function (title) {

            var confirm = $mdDialog.confirm()
                  .title('Are you sure you want to delete this coupon?')
                  .ok('yes')
                  .cancel('no');

            $mdDialog.show(confirm).then(function () {

                $("header div").attr("aria-busy", true);

                $.ajax({
                    type: "POST",
                    url: '/Business/DeleteCoupon?couponTitle=' + title,
                    success: function (data) {
                        $("header div").attr("aria-busy", false);

                        $("#MainBody").html(data);
                        $compile($("body"))($scope);
                    },
                    error: function (data) {

                        $("header div").attr("aria-busy", false);

                        $mdToast.show({
                            template: data.responseText,
                            hideDelay: 6000,
                            position: 'top right'
                        });

                    }
                });
            });
        };
    }]);