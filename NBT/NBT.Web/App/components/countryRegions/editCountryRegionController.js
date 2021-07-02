(function (app) {

    app.controller('editCountryRegionController', editCountryRegionController);

    editCountryRegionController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams'];

    function editCountryRegionController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/countryRegion/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã cập nhật');
                    $state.go('countryRegions');
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

        function loadDetail() {
            apiService.get('api/countryRegion/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function loadContinents() {
            apiService.get('api/continent/getAll', null, function (result) {
                $scope.continents = result.data;
            }, function () {
                console.log('no load data');
            });
        }

        loadDetail();
        loadContinents();
    }

})(angular.module('nbtapp.countryRegions'));