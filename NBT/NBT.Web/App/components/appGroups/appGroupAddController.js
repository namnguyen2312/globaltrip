(function (app) {
    'use strict';

    app.controller('appGroupAddController', appGroupAddController);

    appGroupAddController.$inject = ['$scope', 'apiService', 'notificationService', '$location', 'commonService'];

    function appGroupAddController($scope, apiService, notificationService, $location, commonService) {
        $scope.group = {
            ID: 0,
            Roles: []
        }

        $scope.save = save;

        function save() {
            apiService.post('/api/appGroup/create', $scope.group, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.group.Name + ' đã được thêm mới.');

            $location.url('appGroups');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
        function loadRoles() {
            apiService.get('/api/appRole/getlistall',
                null,
                function (response) {
                    $scope.roles = response.data;
                }, function (response) {
                    notificationService.displayError('Không tải được danh sách quyền.');
                });

        }

        loadRoles();

    }
})(angular.module('nbtapp.appGroups'));