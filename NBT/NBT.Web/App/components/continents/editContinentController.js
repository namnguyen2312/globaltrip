(function (app) {

    app.controller('editContinentController', editContinentController);

    editContinentController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function editContinentController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
        };

        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/continent/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã cập nhật');
                    $state.go('continents');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        function loadDetail() {
            apiService.get('api/continent/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        loadDetail();
    }

})(angular.module('nbtapp.continents'));