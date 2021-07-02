
(function () {
    angular.module('nbtapp.countryRegions', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

            $stateProvider.state('countryRegions', {
                url: "/countryRegions",
                templateUrl: "/app/components/countryRegions/countryRegionsView.html",
                parent: 'base',
                controller: "countryRegionsController"
            })
            .state('addCountryRegion', {
                url: "/addCountryRegion",
                parent: 'base',
                templateUrl: "/app/components/countryRegions/countryRegionView.html",
                controller: "addCountryRegionController"
            })
            .state('editCountryRegion', {
                url: "/editCountryRegion/:id",
                templateUrl: "/app/components/countryRegions/countryRegionView.html",
                controller: "editCountryRegionController",
                parent: 'base',
            });
    }
})();