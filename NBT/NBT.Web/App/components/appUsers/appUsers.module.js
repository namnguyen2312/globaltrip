
(function () {
    angular.module('nbtapp.appUsers', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('appUsers', {
                url: "/appUsers",
                templateUrl: "/app/components/appUsers/appUsersView.html",
                parent: 'base',
                controller: "appUsersController"
            })
            .state('addAppUser', {
                url: "/addAppUser",
                parent: 'base',
                templateUrl: "/app/components/appUsers/appUserView.html",
                controller: "appUserAddController"
            })
            .state('editAppUser', {
                url: "/editAppUser/:id",
                templateUrl: "/app/components/appUsers/appUserView.html",
                controller: "appUserEditController",
                parent: 'base',
            })
            .state('changePass', {
                url: "/changePass",
                templateUrl: "/app/components/appUsers/changePassView.html",
                controller: "changePassController",
                parent: 'base',
            });
    }
})();