(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('manageAccountController', [
        '$scope', 'state', 'alertService', 'Upload',
        function ($scope, state, alertService, Upload) {

            $scope.menuName = '';

            $scope.model = JSON.parse(state('index.model')).Model;
            $scope.changePasswordModel = {
                OldPassword: "",
                NewPassword: "",
                ConfirmPassword: ""
            };

            $scope.validateNewPassword = function(form) {
                form.NewPassword.$validate();
            }

            $scope.validateConfirmPassword = function(form) {
                form.ConfirmPassword.$validate();
            }

            function reloadPage() {
                window.location.reload();
            }

            $scope.updateInfoFromGoogle = function() {
                onLoading();
                var request = {
                    placeId: $scope.model.GooglePlaceId
                };

                var service = new google.maps.places.PlacesService(document.createElement('div'));
                service.getDetails(request, callback);

                function callback(place, status) {
                    if (status == google.maps.places.PlacesServiceStatus.OK) {
                        $scope.applyPlaceUpdate(place);
                    }
                }
            }

            $scope.changePassword = function() {
                onLoading();
                $.ajax({
                    type: "POST",
                    url: '/Manage/ChangePassword',
                    data: $scope.changePasswordModel,
                    success: function(data) {
                        onLoadingFinish();
                        alertService.showAlert(data.Success, data.Messages[0], reloadPage);
                    }
                });
            }

            $scope.applyPlaceUpdate = function(place) {
                $scope.model.BusinessName = place.name;
                $scope.model.InternationalPhoneNumber = place.international_phone_number;
                $scope.model.FormattedPhoneNumber = place.formatted_phone_number;
                $scope.model.WebsiteUrl = place.website == null ? "https://www.google.co.nz/search?q=" + place.name.Replace(" ", "+") : place.website;
                $scope.model.FormattedAddress = place.formatted_address;
                $scope.model.Lat = place.geometry.location.lat();
                $scope.model.Lng = place.geometry.location.lng();
                onLoading();

                $.ajax({
                    type: "POST",
                    url: '/Manage/UpdateBusinessInfo',
                    data: {
                        model: $scope.model
                    },
                    success: function(data) {
                        onLoadingFinish();
                        alertService.showAlert(data.Success, data.Messages[0]);
                    }
                });
            }

            $scope.uploadMenu = function() {
                $("#menuUpload").click();
            }

            // upload on file select or drop
            $scope.upload = function (file) {
                onLoading();
                Upload.upload({
                    url: 'Manage/UploadMenu',
                    data: {
                        file: file,
                        'businessInfoId': $scope.model.Id
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
            };
        }
    ]);
}());