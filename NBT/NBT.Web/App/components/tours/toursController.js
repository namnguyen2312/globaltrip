(function (app) {
    'use strict';

    app.controller('toursController', toursController);

    toursController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function toursController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.page = 0;
        $scope.pageSize = "50";
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.filter = '';

        $scope.condition = {};
        $scope.data = [];

        $scope.search = search;
        $scope.del = del;

        function del(item) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: item.Id
                    }
                }
                apiService.del('api/tours/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function search(page) {
            $scope.loading = true;
            page = page || 0;
            var config = {
                params: {
                    filter: $scope.filter,
                    countryRegionId: $scope.condition.countryRegionId,
                    stateProvinceId: $scope.condition.stateProvinceId,
                    tourType: $scope.condition.tourType,
                    page: page,
                    pageSize: $scope.pageSize
                }
            };
            apiService.get('/api/tours/getAll', config, function (result) {
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
            apiService.get('api/countryRegion/getAllNoPaging', null, function (result) {
                $scope.countryRegions = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        function loadStateProvinces() {
            apiService.get('api/stateProvince/getAllNoPaging', null, function (result) {
                $scope.stateProvinces = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        function loadTourTypes() {
            apiService.get('api/tourTypes/getAll', null, function (result) {
                $scope.tourTypes = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        loadTourTypes();
        loadCountryRegions();
        loadStateProvinces();
        $scope.search();
    }
})(angular.module('nbtapp.tours'));