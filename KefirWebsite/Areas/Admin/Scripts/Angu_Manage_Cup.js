
Adminapp.controller('ControllerCup', function ($scope, $http) {
    $scope.Cup = {};

    $http.get("/api/Setting/GetCup")
        .success(function (data, status) {
         
            $scope.Cup = data;

        });

    $scope.SendData = function () {
        $scope.Cup.CupFirstPercent = parseFloat($scope.Cup.CupFirstPercent);
        $scope.Cup.CupSecoundPercent = parseFloat($scope.Cup.CupSecoundPercent);
        $scope.Cup.CupThirdPercent = parseFloat($scope.Cup.CupThirdPercent);
        $scope.Cup.CupFourthPercent = parseFloat($scope.Cup.CupFourthPercent);
        $http.post("/api/Setting/SetCup",$scope.Cup)
        .success(function (data, status) {
            alertify.success("با موفقیت ذخیره شد");

        });
    }


});
