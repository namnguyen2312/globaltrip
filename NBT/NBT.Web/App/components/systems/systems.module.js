
(function () {
    angular.module('nbtapp.systems', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('settings', {
            url: "/settings",
            templateUrl: "/app/components/systems/settingsView.html",
            parent: 'base',
            controller: "settingsController"
        });
    }
})();