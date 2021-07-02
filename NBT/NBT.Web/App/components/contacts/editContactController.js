(function (app) {

    app.controller('editContactController', editContactController);

    editContactController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function editContactController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
        };
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/contacts/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã cập nhật');
                    $state.go('contacts');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        function loadDetail() {
            apiService.get('api/contacts/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        loadDetail();
    }

})(angular.module('nbtapp.contacts'));