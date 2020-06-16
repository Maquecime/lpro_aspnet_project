(function () {
    'use strict';

    angular
        .module('app')
        .controller('homeCtrl', ['$scope', '$filter', 'dataService', function ($scope, $filter, dataService) {
            $scope.eleves = [];
            $scope.absences = [];

            const arrAvg = arr => arr.reduce((a, b) => a + b, 0) / arr.length;

            getData();

            function getData() {
                dataService.getBestEleves().then(function (result) {
                    result.forEach((eleve, index) => {
                        eleve.moy = 0;
                        eleve.nbNotes = eleve.Notes.length;
                        const noteValues = eleve.Notes.map(n => n.NoteValue);
                        if (noteValues.length > 0) {
                            eleve.moy = arrAvg(noteValues);
                        }
                    });

                    $scope.eleves = result
                });
            };

            function getLatestAbsences() {
                dataService.getLatestAbsences().then(function (result) {
                    console.log(result);
                    $scope.absences = result;
                })
            }

            getLatestAbsences();
           
        }]);
})();