(function() {
    var module = angular.module('freeCouponsApp');

    module.controller('searchController', [
        '$scope',
        function($scope) {

            $scope.searchTerm = "";

            var searchOptions = {
                componentRestrictions: { country: "nz" }
            };

            var searchInput = $("#SearchInput")[0];

            var searchAutocomplete = new google.maps.places.Autocomplete(searchInput, searchOptions);

            searchAutocomplete.addListener('place_changed', function() {
                var object = searchAutocomplete.getPlace();


            });

            $scope.searchNearby = function() {

            }

            $scope.searchForBusiness = function() {

            }
        }
    ]);
}());