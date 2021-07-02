(function (app) {
    app.controller('changePassController', changePassController);

    changePassController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function changePassController($scope, apiService, notificationService, $ngBootbox) {
        $scope.data = {

        };
        $scope.save = save;

        function save() {
           
            apiService.put('api/appUser/changepassword', $scope.data, function (result) {
                notificationService.displaySuccess('Password đã cập nhật');
            }, function () {
                console.log('load failed data');
            });
        }
    }
})(angular.module('nbtapp.appUsers'));