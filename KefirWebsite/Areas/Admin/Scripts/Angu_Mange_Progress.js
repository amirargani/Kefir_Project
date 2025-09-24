Adminapp.controller('ProgressTitleController', function ($scope, $http) {
    $scope.Title = {};
    $scope.Title.AbstractText = "درحال بارگیری";
    $scope.Title.AbstractTitle = "درحال بارگیری";
    $scope.SendData = function () {
        $http.get("/api/Setting/SendProgress?AbstractTitle=" + $scope.Title.AbstractTitle + "&AbstractText=" + $scope.Title.AbstractText)
        .success(function (data, status) {
            alertify.success("با موفقیت ثبت شد");

        });
    }
    $scope.GetData = function()
    {
        $http.get("/api/Setting/GetProgress")
        .success(function (data, status) {
            $scope.Title.AbstractText = data.AbstractText;
            $scope.Title.AbstractTitle = data.AbstractTitle;

        });
    }
    $scope.GetData();
});




Adminapp.controller('ProgressController', function ($scope, $http) {
    $scope.currentProgress = {};
    $scope.getData = function(){
        $http.get("/api/Progress/GetProgresses")
        .success(function (data, status) {
            $scope.Progresses = data;

        });
    }
    $scope.getData();

   
    $scope.DeleteData = function (id) {

        $http.get("/api/Progress/DeleteProgress/"+id)
        .success(function (data, status) {
            alertify.success("با موفقیت حذف شد");

        }).error(function (data, status) {
            alertify.error(data.Message);
        }).then(function () {
            $scope.getData();
        });
    }
    $scope.SaveData = function () {
        
        $http.post("/api/Progress/Register", $scope.currentProgress)
            .success(function (data, status, headers, config) {
                alertify.success("با موفقیت ذخیره شد");
            }).error(function (data, status) {
                alertify.error(data.Message);
            }).then(function () {
                $('#myModal').modal('toggle');
                $scope.getData();
            });
    }

    $scope.ClearData=function()
    {
        $scope.currentProgress = {};
        $scope.currentProgress.ProgressId = 0;
    }
    $scope.FillData = function (x) {
        $scope.currentProgress = x;
    }
    


});
