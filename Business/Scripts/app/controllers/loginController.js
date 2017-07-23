(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('loginController', [
        '$scope', '$mdToast', '$compile',
        function($scope, $mdToast, $compile) {

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
            function onSignIn(googleUser) {
                var profile = googleUser.getBasicProfile();
                console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
                console.log('Name: ' + profile.getName());
                console.log('Image URL: ' + profile.getImageUrl());
                console.log('Email: ' + profile.getEmail());
            }

        }
    ]);
}());