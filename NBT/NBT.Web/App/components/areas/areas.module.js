
(function () {
    angular.module('nbtapp.areas', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('areas', {
            url: "/areas",
            templateUrl: "/app/components/areas/areasView.html",
            parent: 'base',
            controller: "areasController"
        })
            .state('addArea', {
                url: "/addArea",
                parent: 'base',
                templateUrl: "/app/components/areas/areaView.html",
                controller: "addAreaController"
            })
            .state('editArea', {
                url: "/editArea/:id",
                templateUrl: "/app/components/areas/areaView.html",
                controller: "editAreaController",
                parent: 'base'
            })
            ;
    }
})();