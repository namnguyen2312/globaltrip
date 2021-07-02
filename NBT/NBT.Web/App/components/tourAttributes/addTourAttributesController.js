(function (app) {

    app.controller('addTourAttributesController', addTourAttributesController);

    addTourAttributesController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addTourAttributesController(apiService, $scope, notificationService, $state) {
        $scope.data = {
            IsShow: false
        };

        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.post('api/tourAttributes/create', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
                    $state.go('tourAttributes');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

    }

})(angular.module('nbtapp.tourAttributes'));