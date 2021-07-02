
(function () {
    angular.module('nbtapp.appRoles', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('appRoles', {
            url: "/appRoles",
            templateUrl: "/app/components/appRoles/appRolesView.html",
            parent: 'base',
            controller: "appRolesController"
        });
    }
})();