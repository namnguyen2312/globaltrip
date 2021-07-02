
(function () {
    angular.module('nbtapp.appGroups', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('appGroups', {
            url: "/appGroups",
            templateUrl: "/app/components/appGroups/appGroupsView.html",
            parent: 'base',
            controller: "appGroupsController"
        })
            .state('addAppGroup', {
                url: "/addAppGroup",
                parent: 'base',
                templateUrl: "/app/components/appGroups/appGroupView.html",
                controller: "appGroupAddController"
            })
            .state('editAppGroup', {
                url: "/editAppGroup/:id",
                templateUrl: "/app/components/appGroups/appGroupView.html",
                controller: "appGroupEditController",
                parent: 'base',
            });
    }
})();