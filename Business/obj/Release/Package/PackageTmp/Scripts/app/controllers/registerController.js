(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('registerController', [
        '$scope',
        function($scope) {

            $scope.errors = [];
            $scope.disableSubmit = true;
            $scope.email = "";
            $scope.password = "";
            $scope.confirmPassword = "";
            $scope.businessAddress = "";
            $scope.business = {
                name: "",
                lat: 0.0,
                lng: 0.0,
                formattedAddress: "",
                phoneNumber: "",
                formattedPhoneNumber: "",
                website: "",
                rating: "",
                placeId: ""
            }

            $scope.changeAddress = function () {
                $scope.disableSubmit = true;
            }

            var businessOptions = {
                types: ['establishment'],
                componentRestrictions: { country: "nz" }
            };

            var businessInput = $("#BusinessAddress")[0];

            var businessautocomplete = new google.maps.places.Autocomplete(businessInput, businessOptions);

            businessautocomplete.addListener('place_changed', function() {
                var object = businessautocomplete.getPlace();

                $scope.business.name = object.name;
                $scope.business.lat = object.geometry.location.lat();
                $scope.business.lng = object.geometry.location.lng();
                $scope.business.formattedAddress = object.formatted_address;
                $scope.business.phoneNumber = object.international_phone_number;
                $scope.business.website = object.website;
                $scope.business.rating = object.rating == null ? 0.0 : object.rating;
                $scope.business.placeId = object.place_id;
                $scope.business.formattedPhoneNumber = object.formatted_phone_number;
                $scope.disableSubmit = false;
                $scope.$apply();
            });

            $scope.register = function (form) {
                if (form.$valid) {
                    $("form").submit();
                    onLoading();
                }
            }
        }
    ]);
}());