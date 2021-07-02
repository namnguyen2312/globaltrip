(function (app) {
    'use strict';

    app.controller('visasController', visasController);

    visasController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function visasController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.page = 0;
        $scope.pageSize = "50";
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.filter = '';

        $scope.data = [];
        $scope.search = search;

        function search(page) {
            $scope.loading = true;
            page = page || 0;
            var config = {
                params: {
                    filter: $scope.filter,
                    page: page,
                    pageSize: $scope.pageSize
                }
            };
            apiService.get('/api/visas/getAll', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.data = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.loading = false;
            }, function () {
                console.log('load failed data');
                $scope.loading = false;
            });
        }

       
        $scope.search();
    }
})(angular.module('nbtapp.visas'));