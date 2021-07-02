(function (app) {
    'use strict';

    app.controller('contactsController', contactsController);

    contactsController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function contactsController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
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
                apiService.del('api/contacts/delete', config, function () {
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
                    filter: $scope.filter
                }
            };
            apiService.get('/api/contacts/getAll', config, function (result) {
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
})(angular.module('nbtapp.contacts'));