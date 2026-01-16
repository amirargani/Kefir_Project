app.controller('ControllerLogin', function ($scope, $http) {
    $scope.user = {
        UserName: "",
        Password: "",
        remember: false
    };

    $scope.sendData = function () {

        
        $http.post("/api/Login/SignIn", $scope.user)
       .success(function (data, status) {
           window.location.reload();
       }).error(function () {

           alertify.error("اطلاعات مطابقت ندارد");
       });
    }
    $scope.ForgetPass = function () {
        $("#loading").css({ "display": "block" });

        $http.get("/api/Users/ForgetPass?username=" + $scope.user.UserName)
           .success(function () {
               alertify.success("باتوجه به نام کاربری، رمز عبور به ایمیل شما ارسال شد");
               $("#loading").css({ "display": "none" });

               $scope.c = {};
           }).error(function (data) {
               alertify.error(data.Message);
               $("#loading").css({ "display": "none" });


           });
    }

});



