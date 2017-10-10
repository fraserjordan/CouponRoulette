(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('loginController', [
        '$scope',
        function($scope) {

            $scope.isSubmitting = false;
            $scope.email = "";
            $scope.password = "";
            $scope.rememberMe = false;

            $scope.SwitchRememberMe = function() {
                $("#RememberMe").prop('checked', $scope.rememberMe);
            }

            $scope.login = function() {
                $("form").submit();
                $scope.isSubmitting = true;
                onLoading();
            }
        }
    ]);
}());