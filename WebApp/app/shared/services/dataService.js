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
                $http.get('/EleveAg/Detail' + id).then(function (result) {
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

            return service;
        }]);
})();