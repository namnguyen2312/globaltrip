(function (app) {
    'use strict';

    app.controller('areasController', areasController);

    areasController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function areasController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;

        $scope.data = [];
        $scope.search = search;

        function search(page) {
            $scope.loading = true;
            page = page || 0;
            var config = {
                params: {
                    filter: $scope.filter
                }
            };
            apiService.get('/api/areas/getAll', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.data = result.data;
                $scope.loading = false;
            }, function () {
                console.log('load failed data');
                $scope.loading = false;
            });
        }

        $scope.search();
    }
})(angular.module('nbtapp.areas'));