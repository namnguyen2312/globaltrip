
(function () {
    angular.module('nbtapp.tourAttributes', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('tourAttributes', {
            url: "/tourAttributes",
            templateUrl: "/app/components/tourAttributes/tourAttributesView.html",
            parent: 'base',
            controller: "tourAttributesController"
        })
        .state('addTourAttribute', {
            url: "/addTourAttribute",
            parent: 'base',
            templateUrl: "/app/components/tourAttributes/tourAttributeView.html",
            controller: "addTourAttributesController"
        })
        .state('editTourAttribute', {
            url: "/editTourAttribute/:id",
            templateUrl: "/app/components/tourAttributes/tourAttributeView.html",
            controller: "editTourAttributesController",
            parent: 'base',
        });
    }
})();