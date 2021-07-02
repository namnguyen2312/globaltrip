
(function () {
    angular.module('nbtapp.contacts', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('contacts', {
            url: "/contacts",
            templateUrl: "/app/components/contacts/contactsView.html",
            parent: 'base',
            controller: "contactsController"
        })
            .state('addContact', {
                url: "/addContact",
                parent: 'base',
                templateUrl: "/app/components/contacts/contactView.html",
                controller: "addContactController"
            })
            .state('editContact', {
                url: "/editContact/:id",
                templateUrl: "/app/components/contacts/contactView.html",
                controller: "editContactController",
                parent: 'base',
            });
    }
})();