(function () {
    'use strict';

    angular
        .module('app', [
            //Angular Modules
            'ngRoute',
            'ui.bootstrap'
        ]).directive('head', ['$rootScope', '$compile',
            function ($rootScope, $compile) {
                return {
                    restrict: 'E',
                    link: function (scope, elem) {
                        var html = '<link rel="stylesheet" ng-repeat="(routeCtrl, cssUrl) in routeStyles" ng-href="{{cssUrl}}" />';
                        elem.append($compile(html)(scope));
                        scope.routeStyles = {};
                        $rootScope.$on('$routeChangeStart', function (e, next, current) {
                            if (current && current.$$route && current.$$route.css) {
                                if (!angular.isArray(current.$$route.css)) {
                                    current.$$route.css = [current.$$route.css];
                                }
                                angular.forEach(current.$$route.css, function (sheet) {
                                    delete scope.routeStyles[sheet];
                                });
                            }
                            if (next && next.$$route && next.$$route.css) {
                                if (!angular.isArray(next.$$route.css)) {
                                    next.$$route.css = [next.$$route.css];
                                }
                                angular.forEach(next.$$route.css, function (sheet) {
                                    scope.routeStyles[sheet] = sheet;
                                });
                            }
                        });
                    }
                };
            }
        ])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');

            $routeProvider
                .when('/', {
                    controller: 'eleveCtrl',
                    templateUrl: '/app/templates/eleves.html',
                    css: '/app/styles/eleves.css'
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