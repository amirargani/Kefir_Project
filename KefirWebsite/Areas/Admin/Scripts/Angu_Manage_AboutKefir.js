
Adminapp.controller('AboutKefirController', function ($scope, $http) {
    $scope.Obj = {};
    $scope.getData = function () {
        $http.get("/api/Setting/GetAboutKefir")
        .success(function (data, status) {
            data.AboutKefirText = data.AboutKefirText.replace("<br />", "\n");
            $scope.Obj = data;

        });
    }
    $scope.getData();
    $scope.SendData = function () {
        $http.post("/api/Setting/SetAboutKefir", $scope.Obj)
     .success(function (data, status) {
         alertify.success("با موفقیت ثبت شد");

     });
    }


});


