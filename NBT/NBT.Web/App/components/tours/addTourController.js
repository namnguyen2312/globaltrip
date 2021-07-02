(function (app) {

    app.controller('addTourController', addTourController);

    addTourController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function addTourController(apiService, $scope, notificationService, $state) {
        $scope.data = {
            IsShow: false,
            TourAttr: []
        };
        $scope.chooseImage = chooseImage;
        $scope.save = save;
        $scope.addAttr = addAttr;
        $scope.addValue = addValue;

        $scope.ckeditorOptions = function () {
            
        };

        function addValue(item) {
            if (item.Checked) {
                for (var i in $scope.data.TourAttr) {
                    if ($scope.data.TourAttr[i].TourAttributeId === item.Id) {
                        $scope.data.TourAttr[i].Value = item.Value;
                        break;
                    }
                }
            }
        }

        function addAttr(item) {
            if (item.Checked) {
                var attr = {
                    TourAttributeId: item.Id,
                    Value: item.Value
                };
                $scope.data.TourAttr.push(attr);
            } else {
                for (var i in $scope.data.TourAttr) {
                    if ($scope.data.TourAttr[i].TourAttributeId === item.Id) {
                        $scope.data.TourAttr.splice(i, 1);
                        break;
                    }
                }
            }

        }

        function save() {
            $("input").prop('disabled', true);

            //$scope.data.ToDate = moment($scope.data.ToDate, "DD/MM/YYYY").format();
            //$scope.data.FromDate = moment($scope.data.FromDate, "DD/MM/YYYY").format();

            if ($scope.data.AreaId == null)
                $scope.data.AreaId = 0;
            apiService.post('api/tours/create', $scope.data,
                function (result) {
                    notificationService.displaySuccess($scope.data.Name + ' đã được thêm mới.');
                    $state.go('tours');
                }, function (error) {
                    $("input").prop('disabled', false);
                    notificationService.displayError(error.data.Message);
                });
        }

        function chooseImage(item) {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl, fileSize) {
                if (fileSize > 4096) {
                    notificationService.displayError("File lớn hơn 4 MB");
                    return;
                }
                $scope.$apply(function () {
                    switch (item) {
                        case 1:
                            $scope.data.LargeImage = fileUrl;
                            break;
                        default:
                            $scope.data.Image = fileUrl;
                    }
                });
            };
            finder.popup();
        }

        function loadCountryRegions() {
            apiService.get('api/countryRegion/getAllNoPaging', null, function (result) {
                $scope.countryRegions = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        function loadStateProvinces() {
            apiService.get('api/stateProvince/getAllNoPaging', null, function (result) {
                $scope.stateProvinces = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        function loadTourAttr() {
            apiService.get('api/tourAttributes/getAll', null, function (result) {
                $scope.dataAttr = result.data;
            }, function () {
                console.log('Cannot get data');
            });
        }

        function loadTourTypes() {
            apiService.get('api/tourTypes/getAll', null, function (result) {
                $scope.tourTypes = result.data;
            }, function () {
                console.log('Cannot get data');
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
        loadTourTypes();
        loadCountryRegions();
        loadStateProvinces();
        loadTourAttr();

        //$('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' });
        //$('#datemask2').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' });
        //$('[data-mask]').inputmask();
    }

})(angular.module('nbtapp.tours'));