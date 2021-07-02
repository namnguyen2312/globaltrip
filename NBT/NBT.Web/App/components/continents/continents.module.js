
(function () {
    angular.module('nbtapp.continents', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('continents', {
            url: "/continents",
            templateUrl: "/app/components/continents/continentsView.html",
            parent: 'base',
            controller: "continentsController"
        })
        .state('addContinent', {
            url: "/addContinent",
            parent: 'base',
            templateUrl: "/app/components/continents/continentView.html",
            controller: "addContinentController"
        })
        .state('editContinent', {
            url: "/editContinent/:id",
            templateUrl: "/app/components/continents/continentView.html",
            controller: "editContinentController",
            parent: 'base',
        });
    }
})();