var module = angular.module('freeCouponsApp');

module.controller('loginController', ['$scope', '$mdToast', '$compile',
    function ($scope, $mdToast, $compile) {

        $scope.email = "";
        $scope.password = "";
        $scope.rememberMe = false;

        $scope.onLoading = function() {
            onLoading();
        };

    }]);