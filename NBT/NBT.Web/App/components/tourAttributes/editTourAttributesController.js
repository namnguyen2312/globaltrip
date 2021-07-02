(function (app) {

    app.controller('editTourAttributesController', editTourAttributesController);

    editTourAttributesController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function editTourAttributesController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
        };

        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/tourAttributes/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã cập nhật');
                    $state.go('tourAttributes');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        function loadDetail() {
            apiService.get('api/tourAttributes/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        loadDetail();
    }

})(angular.module('nbtapp.tourAttributes'));