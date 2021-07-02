(function (app) {

    app.controller('addContactController', addContactController);

    addContactController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addContactController(apiService, $scope, notificationService, $state) {
        $scope.data = {
            IsShow: false
        };
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.post('api/contacts/create', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
                    $state.go('contacts');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

    }

})(angular.module('nbtapp.contacts'));