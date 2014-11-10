urpApp.controller('moviesCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.onOpenAddNewMovieModal = function() {
        // Reset the input fields.
        $scope.movieEditorData.Title = null;
        $scope.movieEditorData.TagLine = null;
        $scope.movieEditorData.Length = 0;
        
        // Display the dialog.

    };
    
    $scope.onSaveNewMovie = function() {
        $http({
            method: 'POST',
            url: 'http://localhost:49388/movies/add',
            dataType: 'json',
            data: angular.toJson($scope.movieEditorData),
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data, status, headers, config) {

            $scope.movies.push({
                MovieId: data.MovieId,
                Title: $scope.movieEditorData.Title,
                TagLine: $scope.movieEditorData.TagLine,
                Length: $scope.movieEditorData.Length
            });
            
            $scope.onCloseAddNewMovieModal();
            
        }).error(function (data, status, headers, config) {
            // Ideally the api would provide some detailed error info, which can be
            // formatted and displayed.
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