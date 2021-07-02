(function (app) {

    app.controller('editAreaController', editAreaController);

    editAreaController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function editAreaController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
        };
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/areas/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã cập nhật');
                    $state.go('countryRegions');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        function loadDetail() {
            apiService.get('api/areas/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        loadDetail();
    }

})(angular.module('nbtapp.areas'));