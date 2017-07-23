(function() {
var module = angular.module('freeCouponsApp');

module.controller('navbarController', ['$scope', '$compile',
    function ($scope, $compile) {

        $scope.registerSwitch = false;
        $scope.HideCustomerInput = false;
        $scope.HideBusinessInput = true;

        $scope.email = "";
        $scope.password = "";
        $scope.confirmPassword = "";
        $scope.firstName = "";
        $scope.lastName = "";

        $scope.SwitchCustomerBusiness = function () {
            $scope.HideCustomerInput = $scope.registerSwitch;
            $scope.HideBusinessInput = !$scope.registerSwitch;
        }

        $scope.login = function () {
            onLoading();
            $.ajax({
                type: "GET",
                url: '/Account/Login',
                success: function (data) {
                    onLoadingFinish();
                    $("#MainBody").html(data);
                    $compile($("body"))($scope);
                }
            });
        }

        $scope.home = function () {
            onLoading();
            $.ajax({
                type: "GET",
                url: '/Home/HomePage',
                success: function (data) {
                    onLoadingFinish();
                    $("#MainBody").html(data);
                    $compile($("body"))($scope);
                }
            });
        }

        $scope.account = function () {
            onLoading();
            $.ajax({
                type: "GET",
                url: '/Manage/Index',
                success: function (data) {
                    onLoadingFinish();
                    $("#MainBody").html(data);
                    $compile($("body"))($scope);
                }
            });
        }

        $scope.register = function () {
            onLoading();
            $.ajax({
                type: "GET",
                url: '/Account/Register',
                success: function (data) {
                    onLoadingFinish();
                    $("#MainBody").html(data);
                    $compile($("body"))($scope);
                }
            });
        }

        $scope.logoff = function () {
            onLoading();
            $.ajax({
                type: "GET",
                url: '/Account/Logoff',
                success: function (data) {
                    onLoadingFinish();
                    $("#MainBody").html(data);
                    $compile($("body"))($scope);
                }
            });
        }

        $scope.expandSearch = function() {
            $(".CustomerSearch").addClass('Expand');
        }

        $scope.collapseSearch = function () {
            $(".CustomerSearch").removeClass('Expand');
        }
    }]);
}());