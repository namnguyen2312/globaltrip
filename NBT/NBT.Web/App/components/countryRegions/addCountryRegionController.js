(function (app) {

    app.controller('addCountryRegionController', addCountryRegionController);

    addCountryRegionController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addCountryRegionController(apiService, $scope, notificationService, $state) {
        $scope.data = {
            IsShow: true
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;

        function save() {
            $("input").prop('disabled', true);
            apiService.post('api/countryRegion/create', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
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

        function loadContinents() {
            apiService.get('api/continent/getAll', null, function (result) {
                $scope.continents = result.data;
            }, function () {
                console.log('no load data');
            });
        }

        loadContinents();
    }

})(angular.module('nbtapp.countryRegions'));