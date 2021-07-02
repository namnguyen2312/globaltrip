(function (app) {

    app.controller('editStateProvinceController', editStateProvinceController);

    editStateProvinceController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams'];

    function editStateProvinceController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.data = {
            IsShow: true
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.put('api/stateProvince/update', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã cập nhật.');
                    $state.go('stateProvinces');
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
            apiService.get('api/stateProvince/getbyid/' + $stateParams.id, null, function (result) {
                $scope.data = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function loadCountryRegions() {
            apiService.get('api/countryRegion/getAllNoPaging', null, function (result) {
                $scope.countryRegions = result.data;
            }, function () {
                console.log('no load data');
            });
        }

        function loadAreas() {
            apiService.get('api/areas/getAll', null, function (result) {
                $scope.areas = result.data;
            }, function () {
                console.log('no load data');
            });
        }

        loadAreas();
        loadCountryRegions();
        loadDetail();
    }

})(angular.module('nbtapp.stateProvinces'));