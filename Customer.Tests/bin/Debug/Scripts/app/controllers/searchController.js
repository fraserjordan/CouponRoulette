(function() {
var module = angular.module('freeCouponsApp');

module.controller('searchController', ['$scope', '$compile',
    function ($scope, $compile) {

        $scope.latitude = '';
        $scope.longitude = '';
        $scope.category = 0;
        $scope.address = '';
        $scope.businessName = '';
        $scope.validFrom = '';
        $scope.validTo = '';

        var searchOptions = {
            componentRestrictions: { country: "nz" }
        };

        var searchInput = $("#BusinessAddress")[0];

        var searchautocomplete = new google.maps.places.Autocomplete(searchInput, searchOptions);

        searchautocomplete.addListener('place_changed', function () {
            $scope.latitude = searchautocomplete.getPlace().geometry.location.lat();
            $scope.longitude = searchautocomplete.getPlace().geometry.location.lng();
        });

        $scope.search = function () {

            $(".CustomerSearch").bind("transitionend webkitTransitionEnd oTransitionEnd MSTransitionEnd", function () {

            $(".CustomerSearch").unbind();

            onLoading();

            $.ajax({
                type: "POST",
                url: '/Customer/Search',
                data: {
                    Address: $scope.address,
                    Latitude: $scope.latitude,
                    Longitude: $scope.longitude,
                    Category: $scope.category,
                    Name: $scope.businessName
                },
                success: function (data) {
                    onLoadingFinish();

                    $scope.latitude = '';
                    $scope.longitude = '';
                    $scope.category = 0;
                    $scope.address = '';
                    $scope.businessName = '';
                    $scope.validFrom = '';
                    $scope.validTo = '';

                    $(".Coupons").html(data);
                    $compile($(".Coupons"))($scope);
                }
                });
            });
            $(".CustomerSearch").removeClass('Expand');
        }
    }]);
}());