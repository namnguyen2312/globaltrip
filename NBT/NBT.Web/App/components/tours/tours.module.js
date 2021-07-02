
(function () {
    angular.module('nbtapp.tours', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('tours', {
            url: "/tours",
            templateUrl: "/app/components/tours/toursView.html",
            parent: 'base',
            controller: "toursController"
        })
        .state('addTour', {
            url: "/addTour",
            parent: 'base',
            templateUrl: "/app/components/tours/tourView.html",
            controller: "addTourController"
        })
        .state('editTour', {
            url: "/editTour/:id",
            templateUrl: "/app/components/tours/tourView.html",
            controller: "editTourController",
            parent: 'base',
        });
    }
})();