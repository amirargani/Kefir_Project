function changeCheck() {
    angular.element(document.getElementById('ele')).scope().getData();
}
Adminapp.controller('FaqController', function ($scope, $http) {

    $scope.getData = function () {
        var flag = !(mySwitch.checked);
        $http.get("/api/FAQ/GetFAQs?HasAnswer=" + flag)
        .success(function (data, status) {
            $scope.FAQS = data;

        });
    }
    $scope.getData();
    $scope.FAQ = {};

    $scope.DeleteData = function (id) {

        $http.get("/api/FAQ/DeleteData?id=" + id)
        .success(function (data, status) {
            alertify.success("با موفقیت حذف شد");

        }).error(function (data, status) {
            alertify.error(data);
        }).then(function () {
            $scope.getData();
        });
    }

    $scope.getStatus = function (x) {
        if (x.Answer != null) {
            x.StatusText = "پاسخ داده شده";
            x.Color = "#fed779";
        }
        else {
            x.StatusText = "بدون پاسخ";
            x.Color = "#8bfe79";
        }
    }

    $scope.FillData = function (x) {

        
        $scope.FAQ.QuestionText = x.QuestionText;
        $scope.FAQ.Answer = x.Answer;
        $scope.FAQ.Id = x.Id;
        
        $('#myModal').modal('toggle');
    }

    $scope.ChangeQuestion = function()
    {
        $http.post("/api/FAQ/ChangeQuestion?id=" + $scope.FAQ.Id + "&answer=" + $scope.FAQ.Answer)
       .success(function (data, status) {
           alertify.success("با موفقیت ذخیره شد");

       }).error(function (data, status) {
           alertify.error(data);
       }).then(function () {
           $('#myModal').modal('toggle');
           $scope.getData();
       });
    }



});


