(function (app) {
    'use strict';

    app.controller('appUserEditController', appUserEditController);

    appUserEditController.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams'];

    function appUserEditController($scope, apiService, notificationService, $location, $stateParams) {
        $scope.isUpdate = true;
        $scope.account = {}
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.put('/api/appUser/update', $scope.account, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('/api/appUser/detail/' + $stateParams.id, null,
                function (result) {
                    $scope.account = result.data;
                },
                function (result) {
                    notificationService.displayError(result.data);
                });
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.UserName + ' đã được cập nhật thành công.');

            $location.url('appUsers');
        }
        function addFailed(response) {
            $("input").prop('disabled', false);
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
        function loadGroups() {
            apiService.get('/api/appGroup/getlistall',
                null,
                function (response) {
                    $scope.groups = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách nhóm.');
                });

        }
        loadGroups();
        loadDetail();

    }
})(angular.module('nbtapp.appUsers'));