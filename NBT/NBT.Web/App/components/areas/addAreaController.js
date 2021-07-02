(function (app) {

    app.controller('addAreaController', addAreaController);

    addAreaController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addAreaController(apiService, $scope, notificationService, $state) {
        $scope.data = {
            IsShow: true
        };
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.post('api/areas/create', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
                    $state.go('areas');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

    }

})(angular.module('nbtapp.areas'));