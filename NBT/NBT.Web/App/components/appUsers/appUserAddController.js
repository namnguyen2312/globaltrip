(function (app) {
    'use strict';

    app.controller('appUserAddController', appUserAddController);

    appUserAddController.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function appUserAddController($scope, apiService, notificationService, $location, commonService) {
        $scope.isUpdate = false;
        $scope.account = {
            IsActive: true,
            Groups: []
        };

        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.post('/api/appUser/add', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.FullName + ' đã được thêm mới.');
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

    }
})(angular.module('nbtapp.appUsers'));