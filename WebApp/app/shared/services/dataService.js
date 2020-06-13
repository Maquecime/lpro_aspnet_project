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

            return service;
        }]);
})();