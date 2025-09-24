
Adminapp.controller('AbstractController', function ($scope, $http) {

    $scope.getData = function () {
        $http.get("/api/Abstract/GetAbstracts")
        .success(function (data, status) {
            $scope.Abstracts = data;

        });
    }
    $scope.getData();
    $scope.Abstract = {};

    $scope.DeleteData = function (id) {

        $http.get("/api/Abstract/DeleteAbstract/" + id)
        .success(function (data, status) {
            alertify.success("با موفقیت حذف شد");

        }).error(function (data, status) {
            alertify.error(data.Message);
        }).then(function () {
            $scope.getData();
        });
    }


    $scope.SaveData = function () {
        var abstrac = $scope.Abstract;
        $http.post("/api/Abstract/RegisterAbstract", abstrac)
            .success(function (data, status, headers, config) {
                alertify.success("با موفقیت ذخیره شد");
            }).error(function (data, status) {
                alertify.error(data.Message);
            }).then(function () {
                $('#myModal').modal('toggle');
                $scope.getData();
            });
    }

    $scope.FillData = function (id) {
        $http.get("/api/Abstract/GetAbstract/" + id)
               .success(function (data, status) {
                   $scope.Abstract.AbstractText = data.AbstractText;
                   $scope.Abstract.AbstractId = data.AbstractId;
               }).then(function () {
                   $('#myModal').modal('toggle');

               }

               );
    }

    $scope.ClearData = function () {

        $scope.Abstract.AbstractId = 0;
        $scope.Abstract.AbstractText = '';
    }

});


