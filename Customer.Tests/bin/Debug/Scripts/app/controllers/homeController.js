(function() {
var module = angular.module('freeCouponsApp');

module.controller('homeController', ['$scope', '$mdDialog', '$mdToast', '$compile', 'state',
    function ($scope, $mdDialog, $mdToast, $compile, state) {

        $scope.model = JSON.parse(state('index.model')).Model;

        // Initialize the maps for each business
        $('document').ready(function() {
            var model = $scope.model;

            for (var i = 0; i < model.Businesses.length; i++) {

                var business = model.Businesses[i];
                var id = business.Id + "map";
                var myLatLng = { lat: business.Lat, lng: business.Lng };

                map = new google.maps.Map(document.getElementById(id), {
                    center: myLatLng,
                    disableDefaultUI: true,
                    zoom: 15,
                    draggable: false,
                    scrollwheel: false
                });
                var marker = new google.maps.Marker({
                    position: myLatLng,
                    map: map,
                });
            }
        });

        $scope.latitude = "";
        $scope.longitude = "";
        $scope.html = "";

        $scope.RedeemCoupon = function (businessId, coupon) {
            $scope.businessAddress = "";

            var confirm = $mdDialog.confirm()
                  .title('Are you sure you want to redeem this coupon?')
                  .ok('yes')
                  .cancel('no');

            $mdDialog.show(confirm).then(function () {

                $(".Expand").removeClass("Expand");

                onLoading();

                $.ajax({
                    type: "POST",
                    url: '/Customer/RedeemCoupon',
                    data: {
                        couponTitle: coupon.Title
                    },
                    success: function (data) {

                        var businessIndex = _.findIndex($scope.model, function (o) { return o.Id == businessId; });

                        _.remove($scope.model[businessIndex].Coupons, function (o) { return o.Id == coupon.Id; });

                        onLoadingFinish();

                        showNotificationSlide(data.responseText, 2000);
                    },
                    error: function (data) {

                        onLoadingFinish();

                        showNotificationSlider(data.responseText, 5000);
                    }
                });
            });
            };  
    }]);
}());