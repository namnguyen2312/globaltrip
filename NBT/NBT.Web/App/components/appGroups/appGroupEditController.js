(function (app) {
    'use strict';

    app.controller('appGroupEditController', appGroupEditController);

    appGroupEditController.$inject = ['$scope', 'apiService', 'notificationService', '$location', '$stateParams'];

    function appGroupEditController($scope, apiService, notificationService, $location, $stateParams) {
        $scope.group = {}


        $scope.save = save;

        function save() {
            apiService.put('/api/appGroup/update', $scope.group, addSuccessed, addFailed);
        }
        function loadDetail() {
            apiService.get('/api/appGroup/detail/' + $stateParams.id, null,
                function (result) {
                    $scope.group = result.data;
                },
                function (result) {
                    notificationService.displayError(result.data);
                });
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.group.Name + ' đã được cập nhật thành công.');

            $location.url('appGroups');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
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
        loadDetail();
    }
})(angular.module('nbtapp.appGroups'));