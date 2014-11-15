moviesApp.controller('moviesCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.movieEditorData = {};

    $scope.onOpenAddNewMovieModal = function() {
        $scope.resetEditor();
        // Move to angular directive.
        $('#addMovieModal').modal('show');
    };
    
    $scope.onSaveNewMovie = function() {
        $http({
            method: 'POST',
            url: '/movies/add',
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
        // Move to angular directive.

        $('#addMovieModal').modal('hide');
    };

    $scope.onOpenEditMovieModal = function (movie) {
        $scope.resetEditor();
        $scope.loadEditor(movie);
        
        // Move to angular directive.
        $('#editMovieModal').modal('show');
    };
    
    $scope.onSaveUpdatedMovie = function () {
        $http({
            method: 'POST',
            url: '/movies/update',
            dataType: 'json',
            data: angular.toJson($scope.movieEditorData),
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data, status, headers, config) {

            $scope.movies.forEach(function (movie) {
                if (movie.MovieId === $scope.movieEditorData.MovieId) {
                    $scope.updateMovieFromEditor(movie);
                }
            });

            $scope.onCloseEditMovieModal();

        }).error(function (data, status, headers, config) {
            // Ideally the api would provide some detailed error info, which can be
            // formatted and displayed.
        });
    };
    
    $scope.onCloseEditMovieModal = function () {
        // Move to angular directive.
        $('#editMovieModal').modal('hide');
    };

    $scope.onDeleteMovie = function (movieId) {
        $http({
            method: 'POST',
            url: '/movies/delete',
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

    $scope.loadEditor = function (movie) {
        $scope.movieEditorData.MovieId = movie.MovieId;
        $scope.movieEditorData.Title = movie.Title;
        $scope.movieEditorData.TagLine = movie.TagLine;
        $scope.movieEditorData.Length = movie.Length;
    };

    $scope.updateMovieFromEditor = function(movie) {
        movie.Title = $scope.movieEditorData.Title;
        movie.TagLine = $scope.movieEditorData.TagLine;
        movie.Length = $scope.movieEditorData.Length;
    };
}])