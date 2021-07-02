(function (app) {

    app.controller('editBlogPostController', editBlogPostController);

    editBlogPostController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams'];

    function editBlogPostController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
            
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;
        $scope.ckeditorOptions = function () {

        };
        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/blogPosts/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Title + ' đã cập nhật');
                    $state.go('blogPosts');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        function chooseImage(item) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    switch (item) {
                        case 1:
                            $scope.data.Image = fileUrl;
                            break;
                        default:
                            $scope.data.Image = fileUrl;
                    }
                });
            };
            finder.popup();
        };

        function loadDetil() {
            apiService.get('api/blogPosts/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
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
        loadDetil();
    }

})(angular.module('nbtapp.blogPosts'));