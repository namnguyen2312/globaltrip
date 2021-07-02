(function (app) {
    'use strict';

    app.controller('blogPostsController', blogPostsController);

    blogPostsController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function blogPostsController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.page = 0;
        $scope.pageSize = "50";
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.condition = {};
        $scope.filter = '';

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
                apiService.del('api/blogPosts/delete', config, function () {
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
                    blogPostType: $scope.condition.blogPostType,
                    page: page,
                    pageSize: $scope.pageSize
                }
            };
            apiService.get('/api/blogPosts/getAll', config, function (result) {
                if (result.data.TotalCount === 0) {
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

        function loadBlogPostTypes() {
            apiService.get('api/blogPostTypes/getAll', null, function (result) {
                $scope.blogPostTypes = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        loadBlogPostTypes();
        $scope.search();
    }
})(angular.module('nbtapp.blogPosts'));