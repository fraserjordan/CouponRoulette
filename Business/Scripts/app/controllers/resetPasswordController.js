(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('resetPasswordController', [
        '$scope',
        function($scope) {

            $scope.email = "";
            $scope.password = "";
            $scope.confirmPassword = "";

            $scope.submit = function (form) {
                if (form.$valid) {
                    $("form").submit();
                    onLoading();
                }
            }
        }
    ]);
}());