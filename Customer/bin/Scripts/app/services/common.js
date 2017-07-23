(function() {
    var module = angular.module('freeCouponsApp');

    module.factory('common',
        function() {
            return {
                showRemainingValidation: function(form) {
                    // touch all input fields to show any outstanding validation.
                    var fieldNames = Object.keys(form).filter(function(item) { return !item.startsWith('$') });
                    fieldNames.forEach(function(item) {
                        form[item].$setTouched();
                        form[item].$setDirty();
                    });
                }
            }
        }
    );
}());