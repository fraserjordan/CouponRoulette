(function() {
    var module = angular.module('freeCouponsApp');

    module.factory('alertService', [
        '$mdDialog',
        function($mdDialog) {

            return {
                showAlert: function showAlert(success, message, thenFunction) {
                    var title = success === true ? "Success" : "Error";
                    var alert = $mdDialog.alert({
                        title: title,
                        textContent: message,
                        ok: 'Ok'
                    });

                    $mdDialog
                        .show(alert)
                        .then(function() {
                            thenFunction();
                        })
                        .finally(function() {
                            alert = undefined;
                        });
                }
            }
        }
    ]);
}());