(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('registerController', [
        '$scope',
        function($scope) {

            $scope.errors = [];
            $scope.email = "";
            $scope.password = "";
            $scope.confirmPassword = "";

            $scope.register = function (form) {
                if (form.$valid) {
                    $("form").submit();
                    onLoading();
                }
            }
        }
    ]);
}());