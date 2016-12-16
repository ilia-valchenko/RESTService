angular.module('Repository', []) 
	.service('Tasks', ['$http', function ($http) {
	    return {
	        getAll: function () {
	            return $http.get('http://localhost:51004/api/webapi');
	        }
	    };
	}])