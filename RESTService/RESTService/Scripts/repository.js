/*angular.module('Repository', [])
	.service('Tasks', ['$http', function ($http) {
	    return {
	        getAll: function () {
	            return $http.get('http://localhost:51004/api/tasks');
	        }
	    };
	}])
*/

var repository = angular.module('Repository', []);

repository.service('Tasks', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http.get('http://localhost:51004/api/tasks');
        }
    };
}]);

repository.service('Users', ['$http', function ($http) {
    return {
        getAll: function () {
            return $http.get('http://localhost:51004/api/users');
        }
    };
}]);