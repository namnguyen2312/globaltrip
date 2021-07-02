(function (app) {
    'use strict';

    app.controller('appUsersController', appUsersController);

    appUsersController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function appUsersController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.data = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.pageSize = "50";

        $scope.search = search;
        $scope.clearSearch = clearSearch;
        $scope.deleteItem = deleteItem;
        $scope.resetPassword = resetPassword;

        function resetPassword(id) {
            $ngBootbox.confirm('Đặt lại mật khẩu account này?')
                .then(function () {
                    var config = {
                        Id: id
                    };
                    apiService.put('/api/appUser/resetPassword', config, function (result) {
                        notificationService.displaySuccess('Đã đặt lại mật khẩu.');
                        $ngBootbox.alert('Mật khẩu: ' + result.data);
                    },
                        function () {
                            notificationService.displayError('Không cập nhật được.');
                        });
                },
                function () {
                });
        }

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            id: id
                        }
                    };
                    apiService.del('/api/appUser/delete', config, function () {
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                        function () {
                            notificationService.displayError('Xóa không thành công.');
                        });
                },
                function () {
                });
        }
        function search(page) {
            page = page || 0;

            $scope.loading = true;
            var config = {
                params: {
                    page: page,
                    pageSize: $scope.pageSize,
                    filter: $scope.filterExpression
                }
            };

            apiService.get('api/appUser/getlistpaging', config, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
            $scope.data = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loading = false;

            if ($scope.filterExpression && $scope.filterExpression.length) {
                notificationService.displayInfo(result.data.Items.length + ' items found');
            }
        }
        function dataLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterExpression = '';
            search();
        }

        $scope.search();
    }
})(angular.module('nbtapp.appUsers'));