(function() {
    var app = angular.module('freeCouponsApp', [
        'ngMaterial',
        'freestuffServices',
        'ngMessages',
        'ngFileUpload',
        'angular.filter',
        'angular-ladda',
        'material.svgAssetsCache'
    ]).filter("jsDate", function() {
        return function(x) {
            return new Date(parseInt(x.substr(6)));
        };
    });
}());

