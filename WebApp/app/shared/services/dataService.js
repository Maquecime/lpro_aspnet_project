(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataService', ['$http', '$q', function ($http, $q) {
            let service = {};

            service.getEleves = function () {
                let deferred = $q.defer();
                $http.get('/EleveAg/Index').then(function (result) {
                    deferred.resolve(JSON.parse(result.data));
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getEleveById = function (id) {
                let deferred = $q.defer();
                $http.get('/EleveAg/Detail/' + id).then(function (result) {
                    deferred.resolve(JSON.parse(result.data));
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addEleve = function (eleve) {
                var deferred = $q.defer();
                $http.post('/EleveAg/Create', eleve).then(function () {
                    deferred.resolve();
                }, function () {
                        deferred.reject();
                });
                return deferred.promise;
            };

            service.editEleve = function (eleve) {
                var deferred = $q.defer();
                $http.post('/EleveAg/Edit', eleve).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.deleteEleve = function (id) {
                var deferred = $q.defer();
                $http.post('/EleveAg/Delete', { id: id }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getClasses = function () {
                var deferred = $q.defer();
                $http.get('/EleveAg/GetClasses').then(function (result) {
                    deferred.resolve(JSON.parse(result.data));
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            }

            service.addNote = function (note, id) {
                var deferred = $q.defer();
                $http.post('/EleveAg/AddNote', { n: note, eleveId: id }).then(function (result) {
                    deferred.resolve();
                }, function () {
                        deferred.reject();
                });
                return deferred.promise;
            }

            service.addAbsence = function (absence, id) {
                var deferred = $q.defer();
                $http.post('/EleveAg/AddAbsence', { a: absence, eleveId: id }).then(function (result) {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            }

            service.getBestEleves = function () {
                let deferred = $q.defer();
                $http.get('/Home/GetBestEleves').then(function (result) {
                    deferred.resolve(JSON.parse(result.data));
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getLatestAbsences = function () {
                let deferred = $q.defer();
                $http.get('/Home/GetLatestAbsences').then(function (result) {
                    deferred.resolve(JSON.parse(result.data));
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            }

            service.getClassesView = function () {
                let deferred = $q.defer();
                $http.get('/Classe/Index').then(function (result) {
                    deferred.resolve(JSON.parse(result.data));
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.addClasse = function (classe) {
                var deferred = $q.defer();
                $http.post('/Classe/Create', classe).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };


            service.editClasse = function (classe) {
                var deferred = $q.defer();
                $http.post('/Classe/Edit', classe).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.getClasseById = function (id) {
                let deferred = $q.defer();
                $http.get('/Classe/Detail/' + id).then(function (result) {
                    deferred.resolve(JSON.parse(result.data));
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            service.deleteClasse = function (id) {
                var deferred = $q.defer();
                $http.post('/Classe/Delete', { id: id }).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });
                return deferred.promise;
            };

            return service;
        }]);
})();