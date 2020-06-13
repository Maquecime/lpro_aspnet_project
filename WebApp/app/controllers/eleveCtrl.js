(function () {
    'use strict';

    angular
        .module('app')
        .controller('eleveCtrl', ['$scope', 'dataService', function ($scope, dataService) {
            $scope.eleves = [];

            getData();

            function getData() {
                dataService.getEleves().then(function (result) {
                    console.log(result);
                    $scope.eleves = result;
                });
            };
        }]);
})();