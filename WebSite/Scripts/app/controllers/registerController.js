var module = angular.module('freeCouponsApp');

module.controller('registerController', ['$scope', '$mdToast', '$compile',
    function ($scope, $mdToast, $compile) {

        $scope.errors = [];

        $scope.registerSwitch = false;
        $scope.HideCustomerInput = false;
        $scope.HideBusinessInput = true;
        $scope.BusinessRequired = false;
        $scope.CustomerRequired = true;
        $scope.HideBusinessAddressValidation = true;
        $scope.HideCustomerAddressValidation = true;
        $scope.DisableSubmit = false;

        $scope.businessWebsite = "";
        $scope.latitude = "";
        $scope.longitude = "";
        $scope.city = "";

        $scope.email = "";
        $scope.password = "";
        $scope.confirmPassword = "";
        $scope.firstName = "";
        $scope.lastName = "";
        var customerCity = "";
        $scope.businessName = "";
        $scope.businessPhone = "";
        $scope.businessPhoneArea = "";
        var businessAddress = "";
        $scope.AccountType = "Customer";

        $scope.SwitchCustomerBusiness = function () {
            if ($scope.registerSwitch) {
                $scope.AccountType = "Business";
                $scope.BusinessRequired = true;
                $scope.CustomerRequired = false;
            }
            else {
                $scope.AccountType = "Customer";
                $scope.BusinessRequired = false;
                $scope.CustomerRequired = true;
            }
            $scope.HideCustomerInput = $scope.registerSwitch;
            $scope.HideBusinessInput = !$scope.registerSwitch;
        }

        var customerOptions = {
            types: ['(cities)'],
            componentRestrictions: { country: "nz" }
        };

        var businessOptions = {
            types: ['establishment'],
            componentRestrictions: { country: "nz" }
        };

        $scope.ChangeAddress = function () {
            $("#RegisterSubmit").attr('disabled', 'disabled');
        }

        var businessInput = $("#BusinessAddress")[0];
        var customerInput = $("#CustomerAddress")[0];

        var businessautocomplete = new google.maps.places.Autocomplete(businessInput, businessOptions);
        var customerautocomplete = new google.maps.places.Autocomplete(customerInput, customerOptions);

        $scope.RegisterUser = function (form) {
            onLoading();
            form.submit();
        }

        $scope.Register = function () {
            document.getElementById("RegisterForm").submit();
        }

        businessautocomplete.addListener('place_changed', function () {
            $scope.DisableSubmit = false;
            businessAddress = businessautocomplete.getPlace().formatted_address;
            $scope.latitude = businessautocomplete.getPlace().geometry.location.lat();
            $scope.longitude = businessautocomplete.getPlace().geometry.location.lng();
            $("#RegisterSubmit").removeAttr("disabled");
        });
        customerautocomplete.addListener('place_changed', function () {
            customerCity = customerautocomplete.getPlace().formatted_address;
            $("#RegisterSubmit").removeAttr("disabled");
        });
    }]);