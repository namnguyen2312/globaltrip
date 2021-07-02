(function (app) {
    'use strict';

    app.controller('ordersController', ordersController);

    ordersController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox','$state','$rootScope'];

    function ordersController($scope, apiService, notificationService, $ngBootbox, $state, $rootScope) {
        $scope.loading = true;
        $scope.page = 0;
        $scope.pageSize = "50";
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.isVerify = false;
        $scope.filter = '';
        $scope.fromDate = moment(new Date()).format('DD/MM/YYYY');
        $scope.toDate = moment(new Date()).format('DD/MM/YYYY');

        $scope.data = [];

        $scope.search = search;
        $scope.orderDetail = orderDetail;

        function orderDetail(item) {
            $rootScope.orderTour = item;
            $state.go('orderDetail', {id: item.Id });
        }

        function search(page) {
            $scope.loading = true;
            page = page || 0;
            var config = {
                params: {
                    filter: $scope.filter,
                    fromDate: moment($scope.fromDate, "DD-MM-YYYY").format(),
                    toDate: moment($scope.toDate, "DD-MM-YYYY").format(),
                    isVerify: $scope.isVerify,
                    page: page,
                    pageSize: $scope.pageSize
                }
            };
            apiService.get('/api/orders/getAll', config, function (result) {
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


        $('#fromDate').datepicker({
            value: $scope.fromDate,//moment(new Date()).format('DD/MM/YYYY'),
            format: 'dd/mm/yyyy',
            language: 'vi',
            autoclose: true
        });
        $('#toDate').datepicker({
            value: $scope.toDate,//moment(new Date()).format('DD/MM/YYYY'),
            format: 'dd/mm/yyyy',
            language: 'vi',
            autoclose: true
        });

        $scope.search();
    }
})(angular.module('nbtapp.orders'));