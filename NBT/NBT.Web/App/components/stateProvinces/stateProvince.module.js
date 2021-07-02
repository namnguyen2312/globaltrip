
(function () {
	angular.module('nbtapp.stateProvinces', ['nbtapp.common']).config(config);

	config.$inject = ['$stateProvider', '$urlRouterProvider'];

	function config($stateProvider, $urlRouterProvider) {

		$stateProvider.state('stateProvinces', {
			url: "/stateProvinces",
			templateUrl: "/app/components/stateProvinces/stateProvincesView.html",
			parent: 'base',
			controller: "stateProvincesController"
		})
		.state('addStateProvince', {
			url: "/addStateProvince",
			parent: 'base',
			templateUrl: "/app/components/stateProvinces/stateProvinceView.html",
			controller: "addStateProvinceController"
		})
		.state('editStateProvince', {
			url: "/editStateProvince/:id",
			templateUrl: "/app/components/stateProvinces/stateProvinceView.html",
			controller: "editStateProvinceController",
			parent: 'base',
		});
	}
})();