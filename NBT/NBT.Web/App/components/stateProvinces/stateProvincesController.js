(function (app) {
    'use strict';

    app.controller('stateProvincesController', stateProvincesController);

    stateProvincesController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function stateProvincesController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.page = 0;
        $scope.pageSize = "50";
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.countryRegionId = 0;

        $scope.data = [];
        $scope.search = search;

        function search(page) {
            $scope.loading = true;
            page = page || 0;
            var config = {
                params: {
                    filter: $scope.filter,
                    countryRegionId: $scope.countryRegionId,
                    page: page,
                    pageSize: $scope.pageSize
                }
            };
            apiService.get('/api/stateProvince/getAll', config, function (result) {
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

        function loadCountryRegions() {
            apiService.get('api/countryRegion/getAllNoPaging', params, function (result) {
                $scope.countryRegions = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        $scope.search();
    }
})(angular.module('nbtapp.stateProvinces'));