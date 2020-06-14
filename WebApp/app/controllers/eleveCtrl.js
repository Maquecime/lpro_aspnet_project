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
        }])
        .controller('eleveAddCtrl', ['$scope','$location', 'dataService', function ($scope, $location, dataService) {
            $scope.createEleve = function (eleve) {
                dataService.addEleve(eleve).then(function () {
                    $location.path('/');
                });
            };

            $scope.classes = [];

            getClassesData();

            function getClassesData() {
                dataService.getClasses().then(function (result) {
                    console.log(result);
                    $scope.classes = result
                });
            };
        }]);
})();