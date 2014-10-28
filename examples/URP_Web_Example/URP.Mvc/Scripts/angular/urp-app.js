var urpApp = angular.module('urpApp', ['ngRoute']);

// Configure the routes
urpApp.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: '/countries/details',
            controller: 'detailsController'
        })

        // route for the about page
        .when('/countries/add', {
            templateUrl: '/countries/add',
            controller: 'addController'
        })

        // route for the contact page
        .when('/countries/edit', {
            templateUrl: '/countries/edit',
            controller: 'editController'
        });
});

