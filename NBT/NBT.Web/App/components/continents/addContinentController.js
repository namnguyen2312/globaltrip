(function (app) {

    app.controller('addContinentController', addContinentController);

    addContinentController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addContinentController(apiService, $scope, notificationService, $state) {
        $scope.data = {
            IsShow: true
        };

        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.post('api/continent/create', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
                    $state.go('continents');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

    }

})(angular.module('nbtapp.continents'));