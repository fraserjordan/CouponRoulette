(function () {
    var module = angular.module('freeCouponsApp');

    module.controller('addressVerificationController', [
        '$scope', '$mdDialog', 'alertService',
        function ($scope, $mdDialog, alertService) {

            $scope.email = '';
            $scope.verificationCode = '';

            $scope.submit = function (form)
            {
                if (form.$valid) {
                    onLoading();
                    $scope.isLoading = true;
                    $.ajax({
                        type: "POST",
                        url: '/Account/VerifyPhysicalAddress',
                        data: {
                            email: $scope.email,
                            code: $scope.verificationCode
                        },
                        success: function (data) {
                            if (data.Success) {
                                window.location = "/Account/VerifiedPhysicalAddress";
                            } else {
                                onLoadingFinish();
                                $scope.isLoading = false;
                                alertService.showAlert(data.Success, data.Messages[0]);
                            }
                        }
                    });
                } else {
                    common.showRemainingValidation(form);
                }
            }
        }
    ]);
}());