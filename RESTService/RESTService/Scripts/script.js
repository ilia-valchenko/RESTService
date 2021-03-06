(function () {
    var todoListModule = angular.module('TodoList', ['Repository']);

    todoListModule.controller('TodoListController', ['$scope', '$http', 'Tasks', 'Users', function ($scope, $http, Tasks, Users) {

        $scope.tasks = [];
        $scope.users = [];
        $scope.isVisiblePopup = true;
        
        function Init() {


            Tasks.getAll().then(function (response) {
                var objectsFromJson = response.data;

                for (var i = 0; i < objectsFromJson.length; i++)
                    $scope.tasks.push(objectsFromJson[i]);
            }), function () {
                alert("Oops! Something went wrong. I can't get list of tasks.");
            };

            Users.getAll().then(function (response) {
                var usersFromJson = response.data;

                for (var i = 0; i < usersFromJson.length; i++)
                    $scope.users.push(usersFromJson[i]);
            }), function () {
                alert("Ooops! Something went wrong. I can't get list of users.");
            }


        };

        Init();

        $scope.showPopup = function () {
            console.log("Show popup");
            $scope.isVisiblePopup = true;
            console.log("The variable is: " + $scope.isVisiblePopup);
        };

        $scope.hidePopup = function () {
            console.log("Hide popup");
            $scope.isVisiblePopup = false;
        };

        $scope.submitNewTask = function () {
            console.log("Title: " + $scope.title);
            console.log("Description: " + $scope.description);

            var data = { "title": $scope.title, "description": $scope.description };

            $http.post(
                '/api/tasks',
                JSON.stringify(data),
                {
                    headers: { 'Content-Type': 'application/json' }
                }
            ).then(function (response) {
                console.log("A new task was successfully sent.");
                console.log(response.data);
                $scope.tasks.push(response.data);
            },
                function () {
                    console.log("Something went wrong. New task wasn't added.");
                });
        };

    }]);

})();
