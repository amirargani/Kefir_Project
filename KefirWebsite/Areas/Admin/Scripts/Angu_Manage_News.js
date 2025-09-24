
Adminapp.controller('NewsController', function ($scope, $http) {
    $scope.Title = {};
    $scope.Title.NewsTitle = "درحال بارگیری";
    $scope.Title.NewsText = "درحال بارگیری";

   
        $http.get("/api/Setting/GetNews")
        .success(function (data, status) {
            $scope.Title.NewsTitle = data.NewsTitle;
            $scope.Title.NewsText = data.NewsText;

        });
    
    $scope.SendTitleData = function()
    {
        $http.get("/api/Setting/SendNews?NewsTitle=" + $scope.Title.NewsTitle + "&NewsText=" + $scope.Title.NewsText)
       .success(function (data, status) {
           alertify.success("با موفقیت ثبت شد");

       });
    }
    $scope.getData = function () {
        $http.get("/api/News/GetNews")
        .success(function (data, status) {
            $scope.News = data;

        });
    }
    $scope.getData();
    $scope.CurrentNews= {};
    $scope.CovertDate = function (x) {
        var date = x.NewsDate.split('T');
        var sDate = date[0].split('-');
        return ToShamsi(parseInt(sDate[0]), parseInt(sDate[1]), parseInt(sDate[2]), 'short');
    }

    $scope.DeleteData = function (id) {

        $http.get("/api/News/DeleteNews/" + id)
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
        for (var i = 1; i <= 3&&i<=imgUpload.files.length; i++) {
            _form.append("Picture"+i, imgUpload.files[i-1]);
        }
        
        _form.append("News", JSON.stringify($scope.CurrentNews));


        $http({
            url: '/api/News/RegisterNews',
            method: "POST",
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
        $http.get("/api/News/GetCurrentNews/" + id)
               .success(function (data, status) {
                   $scope.CurrentNews.NewsId = data.NewsId;
                   $scope.CurrentNews.NewsTitle = data.NewsTitle;
                   $scope.CurrentNews.NewsDate = data.NewsDate;
                   $scope.CurrentNews.NewsText = data.NewsText;
                   imgUpload.value = '';
               }).then(function () {
                   $('#myModal').modal('toggle');

               }

               );
    }

    $scope.ClearData = function () {
        $scope.CurrentNews = {};
        $scope.CurrentNews.NewsId = 0;
     
        imgUpload.value = '';
    }

});


