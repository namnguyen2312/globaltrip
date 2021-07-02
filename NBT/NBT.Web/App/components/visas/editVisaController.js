(function (app) {

    app.controller('editVisaController', editVisaController);

    editVisaController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams'];

    function editVisaController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
            IsShow: true
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;

        $scope.ckeditorOptions = function () {

        };

        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/visas/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
                    $state.go('visas');
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
        }

        function loadDetail() {
            apiService.get('api/visas/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        loadDetail();
    }

})(angular.module('nbtapp.visas'));