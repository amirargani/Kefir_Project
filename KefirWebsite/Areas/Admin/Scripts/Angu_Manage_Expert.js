
Adminapp.controller('ExpertController', function ($scope, $http) {
    $scope.Title = {};
    $scope.Title.ExpertTitle = "درحال بارگیری";
    $scope.Title.ExpertText = "درحال بارگیری";
    $http.get("/api/Setting/GetExpert")
       .success(function (data, status) {
           $scope.Title.ExpertTitle = data.ExpertTitle;
           $scope.Title.ExpertText = data.ExpertText;

       });

    $scope.SendTitleData = function()
    {
        $http.get("/api/Setting/SendExpert?ExpertTitle=" + $scope.Title.ExpertTitle + "&ExpertText=" + $scope.Title.ExpertText)
        .success(function (data, status) {
            alertify.success("با موفقیت ذخیره شد");

        });
    }

    $scope.getData = function () {
        $http.get("/api/Experts/GetExperts")
        .success(function (data, status) {
            $scope.Experts = data;

        });
    }
    $scope.getData();
    $scope.Expert = {};

    $scope.DeleteData = function (id) {

        $http.get("/api/Experts/DeleteExpert/" + id)
        .success(function (data, status) {
            alertify.success("با موفقیت حذف شد");

        }).error(function (data, status) {
            alertify.error(data.Message);
        }).then(function () {
            $scope.getData();
        });
    }


    $scope.SaveData = function () {
        var _form = new FormData();
        _form.append("Picture", imgUpload.files[0]);
        _form.append("Expert", JSON.stringify($scope.Expert));


        $http({
            url: '/api/Experts/RegisterExpert',
            method: "post",
            data: _form,
            headers: { 'Content-Type': undefined }

        }).success(function (data, status, headers, config) {

            alertify.success("با موفقیت ذخیره شد");
        }).error(function (data, status) {
            alertify.error(data.Message);
        }).then(function () {
            $('#myModal').modal('toggle');
            $scope.getData();
        });
    }

    $scope.FillData = function (id) {
        $http.get("/api/Experts/GetExpert/" + id)
               .success(function (data, status) {
                   $scope.Expert = data;
                   imgUpload.value = '';
               }).then(function () {
                   $('#myModal').modal('toggle');

               }

               );
    }

    $scope.ClearData = function () {
        $scope.Expert = {};
        $scope.Expert.ExpertId = 0;
        
        imgUpload.value = '';
    }

});


