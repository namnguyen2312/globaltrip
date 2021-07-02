
(function () {
    angular.module('nbtapp.orders', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('orders', {
            url: "/orders",
            templateUrl: "/app/components/orders/ordersView.html",
            parent: 'base',
            controller: "ordersController"
        })
            .state('orderDetail', {
                url: "/orderDetail/:id",
                parent: 'base',
                templateUrl: "/app/components/orders/orderDetailView.html",
                controller: "orderDetailController"
            })
            ;
    }
})();