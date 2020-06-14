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
                .when('/addeleve', {
                    controller: 'eleveAddCtrl',
                    templateUrl: '/app/templates/eleveAdd.html'
                })
                .when('/editeleve/:id', {
                    controller: 'eleveEditCtrl',
                    templateUrl: '/app/templates/eleveEdit.html'
                })
                .otherwise({ redirectTo: '/' });
        }]);
})();