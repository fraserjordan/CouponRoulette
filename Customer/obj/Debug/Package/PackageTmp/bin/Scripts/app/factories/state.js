(function() {
    angular.module('freeCouponsApp')
        .factory('state', [
            '$window',
            function($window) {
                return function(name, initial) {
                    if (initial) {
                        $window.simplecoupons.state[name] = initial;
                    }
                    return $window.simplecoupons.state[name] || ($window.simplecoupons.state[name] = {});
                };
            }
        ]);
}());