angular.module('freestuffServices')
    .factory('state', ['$window',
    function ($window) {
        return function (name, initial) {
            if (initial) {
                $window.freestuff.state[name] = initial;
            }
            return $window.freestuff.state[name] || ($window.freestuff.state[name] = {});
        };
    }]);