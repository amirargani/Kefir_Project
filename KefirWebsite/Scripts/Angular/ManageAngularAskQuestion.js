var app = angular.module('myApp', []);
app.controller('ControllerQuestion', function ($scope, $http) {
    $scope.Question = "";
    $scope.SendData = function () {
        
        $http.get("/api/FAQ/SendQuestion?Question="+ $scope.Question )
       .success(function (data, status) {
           alertify.success(data);

       });
    }

});


