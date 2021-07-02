
(function () {
    angular.module('nbtapp.blogPosts', ['nbtapp.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('blogPosts', {
            url: "/blogPosts",
            templateUrl: "/app/components/blogPosts/blogPostsView.html",
            parent: 'base',
            controller: "blogPostsController"
        })
        .state('addBlogPost', {
            url: "/addBlogPost",
            parent: 'base',
            templateUrl: "/app/components/blogPosts/blogPostView.html",
            controller: "addBlogPostController"
        })
        .state('editBlogPost', {
            url: "/editBlogPost/:id",
            templateUrl: "/app/components/blogPosts/blogPostView.html",
            controller: "editBlogPostController",
            parent: 'base',
        });
    }
})();