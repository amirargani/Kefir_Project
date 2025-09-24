
Adminapp.controller('UserController', function ($scope, $http) {
    $scope.Users = {};
    $scope.getData = function () {
        $http.get("/api/Users/GetUsers")
        .success(function (data, status) {
            $scope.Users = data;

        });
    }
    $scope.getData();
    $scope.User = {};

    $scope.DeleteData = function (id) {

        $http.get("/api/Users/DeleteUser/" + id)
        .success(function (data, status) {
            alertify.success("با موفقیت حذف شد");

        }).error(function (data, status) {
            alertify.error(data.Message);
        }).then(function () {
            $scope.getData();
        });
    }


    $scope.SaveData = function () {
        var i = RoleId.selectedIndex;
        if (i == 0) {
            $http.post("/api/Users/RegisterAdmin", $scope.User)
                 .success(function (data, status, headers, config) {
                     alertify.success("با موفقیت ذخیره شد");
                 }).error(function (data, status) {
                     alertify.error(data.Message);
                 }).then(function () {
                     $('#myModal').modal('toggle');
                     $scope.getData();
                 });
        }
        else
        {
            $http.post("/api/Users/RegisterMember", $scope.User)
            .success(function (data, status, headers, config) {
                alertify.success("با موفقیت ذخیره شد");
            }).then(function () {
                $('#myModal').modal('toggle');
                $scope.getData();
            });
        }
    }

    $scope.FillData = function (id) {
        $http.get("/api/Users/GetUser/" + id)
               .success(function (data, status) {
                   $scope.User.UserId = data.UserId;
                   $scope.User.UserFirstName = data.UserFirstName;
                   $scope.User.UserLastName = data.UserLastName;
                   $scope.User.UserEmail = data.UserEmail;
                   $scope.User.UserName = data.UserName;
                   User.Password = '';
                   RoleId.selectedIndex = data.role.RoleId-1;
               }).then(function () {
                   $('#myModal').modal('toggle');

               }

               );
    }

    $scope.ClearData = function () {

        $scope.User = {};
    }

});


