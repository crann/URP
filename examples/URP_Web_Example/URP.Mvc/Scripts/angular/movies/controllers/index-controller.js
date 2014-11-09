urpApp.controller('moviesCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.onOpenAddNewMovieModal = function() {
        
    };

    $scope.movie = {
        Title: "test title",
        TagLine: "test tagline",
        Length: 130
    };
    
    $scope.onSaveNewMovie = function() {
        console.log("here");

        var url = 'http://localhost:49388/movies/add';

        $http({
            method: 'POST',
            url: url,
            dataType: 'json',
            data: angular.toJson($scope.movie),
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data, status, headers, config) {
            $scope.onCloseAddNewMovieModal();
        }).error(function (data, status, headers, config) {
            $scope.onCloseAddNewMovieModal();
        });
    };
    
    $scope.onCloseAddNewMovieModal = function () {

    };

    $scope.onOpenEditMovieModal = function () {
        
    };
    
    $scope.onSaveUpdatedMovie = function () {
        
    };
    
    $scope.onCloseEditMovieModal = function () {

    };

    $scope.onDeleteMovie = function () {
        
    };
}])