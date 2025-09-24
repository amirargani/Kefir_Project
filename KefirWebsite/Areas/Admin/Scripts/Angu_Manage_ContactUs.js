function changeCheck()
{
    angular.element(document.getElementById('ele')).scope().getData();
}
Adminapp.controller('ContactUsController', function ($scope, $http) {
    
    $scope.getData = function () {
        var flag = !(mySwitch.checked);
        $http.get("/api/ContactUs/GetMessages/"+flag)
        .success(function (data, status) {
            $scope.Messages = data;

        });
    }
    $scope.getData();
    $scope.MessageText = "";

    $scope.DeleteData = function (id) {

        $http.get("/api/ContactUs/DeleteMessage/" + id)
        .success(function (data, status) {
            alertify.success("با موفقیت حذف شد");

        }).error(function (data, status) {
            alertify.error(data.Message);
        }).then(function () {
            $scope.getData();
        });
    }

    $scope.getStatus = function(x)
    {
        if (x.HasRead == true)
        {
            x.StatusText= "خوانده شده";
            x.Color = "#fed779";
        }
        else
        {
            x.StatusText = "جدید";
            x.Color = "#8bfe79";
        }
    }

    $scope.FillData = function (x) {

        $('#myModal').modal('toggle');
        $scope.MessageText = x.ContactUsText;
        if (x.HasRead == false) {
            $http.get("/api/ContactUs/ChangeStatus/" + x.ContactUsId)
            .success(function (data, status) {
                x.HasRead = true;
                $scope.getData();
            });
        }
    }

    

});


