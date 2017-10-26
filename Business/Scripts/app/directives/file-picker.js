(function() {
    var module = angular.module('freeCouponsApp');
    module.directive('filePicker',
        function() {
            return {
                link: function(scope, elem, attrs) {
                    var button = elem.find('button');
                    var input = angular.element(elem[0].querySelector('input#fileInput'));
                    button.bind('click',
                        function() {
                            input[0].click();
                            scope.csvErrors = [];
                        });
                    input.bind('change',
                        function(e) {
                            scope.$apply(function() {
                                var files = e.target.files;
                                if (files[0]) {
                                    const file = files[0];
                                    scope.fileName = file.name;
                                    scope.file = file;
                                } else {
                                    scope.fileName = null;
                                }
                            });
                        });
                }
            };
        });
})();