(function () {
    'use strict';

    angular
        .module('app')
        .controller('classeCtrl', ['$scope', '$filter', 'dataService', function ($scope, $filter, dataService) {
            $scope.classes = [];

            getData();

            function getData() {
                dataService.getClassesView().then(function (result) {

                    result.forEach((classe, index) => {
                        classe.nbEleves = classe.Eleves.length;
                    });

                    $scope.classes = result

                });
            };

            $scope.deleteClasse = function (id) {
                dataService.deleteClasse(id).then(function () {
                    toastr.success("Classe correctement supprimée, ainsi que ses élèves");
                    getData();
                }, function () {
                    toastr.error("Erreur durant la suppression de la classe identifié par : " + id);
                });
            };
        }])

        .controller('classeAddCtrl', ['$scope', '$location', 'dataService', function ($scope, $location, dataService) {
            $scope.createClasse = function (classe) {
                dataService.addClasse(classe).then(function () {
                    toastr.success('Classe correctement créée !');
                    $location.path('/classes');
                }, function () {
                    toastr.error("Erreur de création de la classe")
                });
            };
        }])
        .controller('classeEditCtrl', ['$scope', '$routeParams', '$location', 'dataService', function ($scope, $routeParams, $location, dataService) {

            $scope.classe = {};
            $scope.states = {
                showUpdateButton: false
            };

            dataService.getClasseById($routeParams.id).then(function (result) {
                $scope.classe = result;
                $scope.states.showUpdateButton = true;
            }, function () {
                toastr.error("Erreur de chargement de la classe identifié par : " + $routeParams.id);
                $location.path('/classes');
            });

            $scope.updateClasse = function (classe) {
                dataService.editClasse(classe).then(function () {
                    toastr.success('Classe correctement modifiée');
                    $location.path('/classes');
                }, function () {
                    toastr.error("Erreur durant la mise à jour de la classe");
                });
            };
        }])
        .controller('classeDetailCtrl', ['$scope', '$routeParams', '$location', 'dataService', function ($scope, $routeParams, $location, dataService) {
            $scope.classe = {};

            dataService.getClasseById($routeParams.id).then(function (result) {
                $scope.classe = result;
                $scope.classe.nbEleves = $scope.classe.Eleves.length;

            }, function () {
                toastr.error("Erreur de chargement de la classe identifiée par : " + $routeParams.id);
                $location.path('/classes');
            });
        }]);
})();