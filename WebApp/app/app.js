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
                    controller: 'homeCtrl',
                    templateUrl: '/app/templates/Home/home.html',
                    css: '/app/styles/eleves.css'
                })
                .when('/classes', {
                    controller: 'classeCtrl',
                    templateUrl: '/app/templates/Classes/classes.html',
                    css: '/app/styles/eleves.css'
                })
                .when('/addclasse', {
                    controller: 'classeAddCtrl',
                    templateUrl: '/app/templates/Classes/classeAdd.html'
                })
                .when('/editclasse/:id', {
                    controller: 'classeEditCtrl',
                    templateUrl: '/app/templates/Classes/classeEdit.html'
                })
                .when('/eleves', {
                    controller: 'eleveCtrl',
                    templateUrl: '/app/templates/Eleves/eleves.html',
                    css: '/app/styles/eleves.css'
                })
                .when('/addeleve', {
                    controller: 'eleveAddCtrl',
                    templateUrl: '/app/templates/Eleves/eleveAdd.html'
                })
                .when('/editeleve/:id', {
                    controller: 'eleveEditCtrl',
                    templateUrl: '/app/templates/Eleves/eleveEdit.html'
                })
                .when('/addnote/:id', {
                    controller: 'eleveAddNoteCtrl',
                    templateUrl:'/app/templates/Eleves/addNote.html'
                })
                .when('/addabsence/:id', {
                    controller: 'eleveAddAbsenceCtrl',
                    templateUrl: '/app/templates/Eleves/addAbsence.html'
                })
                .when('/elevedetail/:id', {
                    controller: 'eleveDetailCtrl',
                    templateUrl: '/app/templates/Eleves/eleveDetail.html',
                    css: '/app/styles/eleveDetail.css'

                })
                .otherwise({ redirectTo: '/' });
        }]);
})();