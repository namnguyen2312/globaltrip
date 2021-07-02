(function (app) {

    app.controller('addStateProvinceController', addStateProvinceController);

    addStateProvinceController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addStateProvinceController(apiService, $scope, notificationService, $state) {
        $scope.data = {
            IsShow: true
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.post('api/stateProvince/create', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
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
    }

})(angular.module('nbtapp.stateProvinces'));