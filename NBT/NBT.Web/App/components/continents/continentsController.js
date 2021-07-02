(function (app) {
    'use strict';

    app.controller('continentsController', continentsController);

    continentsController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function continentsController($scope, apiService, notificationService, $ngBootbox) {
        $scope.loading = true;
        $scope.data = [];
        $scope.search = search;

        function search(page) {
            page = page || 0;

            $scope.loading = true;
            
            apiService.get('api/continent/getAll', null, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
            $scope.data = result.data;
          
            $scope.loading = false;
        }
        function dataLoadFailed(response) {
            notificationService.displayError(response.data);
        }
        
        $scope.search();
    }
})(angular.module('nbtapp.continents'));