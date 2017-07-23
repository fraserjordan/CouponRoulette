(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('forgotPasswordController', [
        '$scope',
        function($scope) {

            $scope.email = "";

            $scope.submit = function(form) {
                if (form.$valid) {
                    $("form").submit();
                    onLoading();
                }
            }
        }
    ]);
}());