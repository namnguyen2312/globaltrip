(function (app) {

    app.controller('orderDetailController', orderDetailController);

    orderDetailController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','$rootScope'];

    function orderDetailController(apiService, $scope, notificationService, $state, $stateParams, $rootScope) {
        $scope.data = {

        };

        $scope.tourInfo = $rootScope.orderTour;
        $scope.save = save;
        
        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/orders/update', $scope.tourInfo,
                function (result) {
                    notificationService.displaySuccess('Đã duyệt');
                    $state.go('tours');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        function loadDetil() {
            apiService.get('api/orderDetail/getById/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        
        loadDetil();
    }

})(angular.module('nbtapp.orders'));