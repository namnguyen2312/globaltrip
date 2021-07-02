(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', '$scope', '$window', 'apiService'];

    function rootController($state, $scope, $window, apiService) {

        $scope.authentication = {};
        $scope.logOut = logOut;



        function logOut () {
            $window.location.href = '/account/LogOutAdmin';
        };

        function loadInfoUser() {

        }
        
    }
})(angular.module('nbtapp'));