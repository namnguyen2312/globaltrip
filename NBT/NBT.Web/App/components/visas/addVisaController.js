(function (app) {

    app.controller('addVisaController', addVisaController);

    addVisaController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addVisaController(apiService, $scope, notificationService, $state) {
        $scope.data = {
            IsWeb: false
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.post('api/visas/create', $scope.data,
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
        };

    }

})(angular.module('nbtapp.visas'));