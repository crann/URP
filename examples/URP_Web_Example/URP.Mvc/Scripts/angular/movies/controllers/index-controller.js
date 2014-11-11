urpApp.controller('moviesCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.onOpenAddNewMovieModal = function() {
        $scope.resetEditor();
        
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

    $scope.onOpenEditMovieModal = function (movie) {
        $scope.resetEditor();
        $scope.loadEditor(movie);
    };
    
    $scope.onSaveUpdatedMovie = function () {
        $http({
            method: 'POST',
            url: 'http://localhost:49388/movies/update',
            dataType: 'json',
            data: angular.toJson($scope.movieEditorData),
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data, status, headers, config) {

            
            $scope.onCloseEditMovieModal();

        }).error(function (data, status, headers, config) {
            // Ideally the api would provide some detailed error info, which can be
            // formatted and displayed.
        });
    };
    
    $scope.onCloseEditMovieModal = function () {

    };

    $scope.onDeleteMovie = function (movieId) {
        $http({
            method: 'POST',
            url: 'http://localhost:49388/movies/delete',
            dataType: 'json',
            data: { id: movieId },
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data, status, headers, config) {
            
            var movieToDelete = {};
            $scope.movies.forEach(function (movie) {
                if (movie.MovieId === movieId) {
                    movieToDelete = movie;
                }
            });

            if (movieToDelete) {
                $scope.movies.splice($scope.movies.indexOf(movieToDelete), 1);
            }

        }).error(function (data, status, headers, config) {
            // Ideally the api would provide some detailed error info, which can be
            // formatted and displayed.
        });
    };

    $scope.resetEditor = function() {
        $scope.movieEditorData.MovieId = 0;
        $scope.movieEditorData.Title = null;
        $scope.movieEditorData.TagLine = null;
        $scope.movieEditorData.Length = 0;
    };

    $scope.loadEditor = function(movie) {
        $scope.movieEditorData.Title = movie.Title;
        $scope.movieEditorData.TagLine = movie.TagLine;
        $scope.movieEditorData.Length = movie.Length;
    };
}])