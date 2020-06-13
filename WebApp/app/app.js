(function () {
    'use strict';

    angular
        .module('app', [
            //Angular Modules
            'ngRoute'
        ]).config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');

            $routeProvider
                .when('/', {
                    controller: 'eleveCtrl',
                    templateUrl: '/app/templates/eleves.html'
                })
                .otherwise({ redirectTo: '/' });
        }]);
})();