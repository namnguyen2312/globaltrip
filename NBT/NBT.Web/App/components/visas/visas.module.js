
(function () {
    angular.module('nbtapp.visas', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('visas', {
            url: "/visas",
            templateUrl: "/app/components/visas/visasView.html",
            parent: 'base',
            controller: "visasController"
        })
        .state('addVisa', {
            url: "/addVisa",
            parent: 'base',
            templateUrl: "/app/components/visas/visaView.html",
            controller: "addVisaController"
        })
        .state('editVisa', {
            url: "/editVisa/:id",
            templateUrl: "/app/components/visas/visaView.html",
            controller: "editVisaController",
            parent: 'base',
        });
    }
})();