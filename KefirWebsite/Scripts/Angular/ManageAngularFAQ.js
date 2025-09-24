var app = angular.module('myApp', []);
app.controller('ControllerFAQ', function ($scope, $http) {
    $http.get("/api/FAQ/GetFAQs")
   .success(function (data, status) {
       $scope.FAQs = data;

   });
   

});


