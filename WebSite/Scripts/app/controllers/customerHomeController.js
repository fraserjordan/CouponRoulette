var module = angular.module('freeCouponsApp');

module.controller('customerHomeController', ['$scope', '$mdDialog', '$mdToast', '$compile', 'state',
    function ($scope, $mdDialog, $mdToast, $compile, state) {

        onLoading();
        $.ajax({
            type: "GET",
            url: '/Customer/GetModel',
            success: function (data) {
                onLoadingFinish();
                $scope.model = JSON.parse(data);
                $scope.$apply();
                $scope.initializeMaps();
            },
            error: function (data) {
            }
        });

        $scope.initializeMaps = function () {
            $('document').ready(function() {
                var model = $scope.model;

                for (var i = 0; i < model.Businesses.length; i++) {

                    var business = model.Businesses[i];
                    var id = business.Id + "map";
                    var ratingId = business.Id + "rating";
                    var myLatLng = { lat: business.Lat, lng: business.Lng };

                    map = new google.maps.Map(document.getElementById(id), {
                        center: myLatLng,
                        zoom: 15,
                        draggable: false,
                        scrollwheel: false
                });
                    var marker = new google.maps.Marker({
                        position: myLatLng,
                        map: map,
                        title: business.BusinessName
                    });

                    $.fn.stars = function () {
                        return $(this).each(function () {
                            $(this).html($('<span />').width(Math.max(0, (Math.min(5, parseFloat($(this).html())))) * 16));
                        });
                    }

                    $('#' + ratingId).stars();
                }
            });
        };

        $(".details").hide();

        //$scope.model = state('model.data');

        $scope.latitude = "";
        $scope.longitude = "";
        $scope.html = "";

        $scope.ExpandCoupons = function (elementId) {
            $("." + elementId + "expander").hide();
            $("." + elementId + "collapser").show();

            var element = $("#" + elementId);
            $(".CouponCard").css('z-index', 0);
            element.css('z-index', 20);
            $(".CouponCard").removeClass('MaxHeight');
            element.addClass('MaxHeight');
            $(".CouponsContainer").slideDown(500);
            $('html,body').animate({ scrollTop: element.offset().top }, 500, function () {
                //element.animate({ height: '100%' });
                $('body').addClass('stop-scrolling');
                $('body').bind('touchmove', function(e) { e.preventDefault() });
            });
        }

        $scope.SrinkCoupons = function (elementId) {
            $("." + elementId + "expander").show();
            $("." + elementId + "collapser").hide();

            $(".CouponCard").removeClass('MaxHeight');
            $(".CouponsContainer").slideUp(500);
            setTimeout(function () {
                $(".CouponCard").css('z-index', 0);
                $('body').removeClass('stop-scrolling');
                $('body').unbind('touchmove');
            }, 500);
        }

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