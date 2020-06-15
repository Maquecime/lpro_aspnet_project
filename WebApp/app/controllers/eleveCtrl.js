(function () {
    'use strict';

    angular
        .module('app')
        .directive("formatDate", function () {
            return {
                require: 'ngModel',
                link: function (scope, elem, attr, modelCtrl) {
                    modelCtrl.$formatters.push(function (modelValue) {
                        return new Date(modelValue);
                    })
                }
            }
        })
        .controller('eleveCtrl', ['$scope','$filter', 'dataService', function ($scope,$filter ,dataService) {
            $scope.eleves = [];
            $scope.currentPage = 1;
            $scope.itemsPerPage = 6;
            $scope.sortColumn = "Classe";
            $scope.reverse = true;

            getData();

            function getData() {
                dataService.getEleves().then(function (result) {
                    console.log(result);
                    $scope.$watch('searchText', function (term) {
                        $scope.eleves = $filter('filter')(result, term);
                    })
                });
            };

            $scope.deleteEleve = function (id) {
                dataService.deleteEleve(id).then(function () {
                    toastr.success("Eleve correctement supprimé");
                    getData();
                }, function () {
                    toastr.error("Erreur durant la suppression de l'élève identifié par : " + id);
                });
            };

            $scope.sortBy = function (columnName) {
                $scope.sortColumn = columnName;
                $scope.reverse = !$scope.reverse;
            };
        }])

        .controller('eleveAddCtrl', ['$scope','$location', 'dataService', function ($scope, $location, dataService) {
            $scope.createEleve = function (eleve) {
                dataService.addEleve(eleve).then(function () {
                    toastr.success('Eleve correctement crée !');
                    $location.path('/');
                }, function () {
                    toastr.error("Erreur de création de l'élève")
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
        }])
        .controller('eleveEditCtrl', ['$scope', '$routeParams', '$location', 'dataService', function ($scope, $routeParams, $location, dataService) {
            $scope.classes = [];

            getClassesData();

            function getClassesData() {
                dataService.getClasses().then(function (result) {
                    console.log(result);
                    $scope.classes = result
                });
            };

            $scope.eleve = {};
            $scope.states = {
                showUpdateButton: false
            };

            dataService.getEleveById($routeParams.id).then(function (result) {
                console.log(result);
                $scope.eleve = result;
                $scope.states.showUpdateButton = true;
            }, function () {
                    toastr.error("Erreur de chargement de l'élève identifié par : " + $routeParams.id);
                    $location.path('/');
            });

            $scope.updateEleve = function (eleve) {
                dataService.editEleve(eleve).then(function () {
                    toastr.success('Eleve correctement modifié');
                    $location.path('/');
                }, function () {
                    toastr.error("Erreur durant la mise à jour de l'élève");
                });
            };
        }]);
})();