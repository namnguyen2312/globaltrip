(function (app) {
    'use strict';

    app.controller('settingsController', settingsController);

    settingsController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function settingsController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;

        $scope.data = [];

        $scope.save = save;
        function loadData() {
            apiService.get('/api/settings/getAll', null, function (result) {
                $scope.data = result.data;
                $scope.loading = false;
            }, function () {
                console.log('load failed data');
                $scope.loading = false;
            });
        }

        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/settings/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess('Đã cập nhật');
                    $("input").prop('disabled', false);
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        loadData();
    }
})(angular.module('nbtapp.systems'));