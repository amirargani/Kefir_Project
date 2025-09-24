/// <reference path="G:\model\KefirProject\KefirWebsite\Scripts/Angular/angular.min.js" />

Adminapp.controller('GalleryController', function ($scope, $http) {
    $scope.Title = {};
    $scope.Title.GalleryTitle = "درحال بارگیری";
    $scope.Title.GalleryText = "درحال بارگیری";
    $scope.SendTitleData = function () {

        $http.get("/api/Setting/SendGallery?GalleryTitle=" + $scope.Title.GalleryTitle + "&GalleryText=" + $scope.Title.GalleryText)
        .success(function (data, status) {
            alertify.success("با موفقیت حذف شد");

         });

    }


    $scope.getData = function () {
        $http.get("/api/Gallery/GetGallery")
        .success(function (data, status) {
            $scope.Gallery = data;

        });
    }
    $http.get("/api/Setting/GetGallery")
 .success(function (data, status) {
     $scope.Title.GalleryTitle = data.GalleryTitle;
     $scope.Title.GalleryText = data.GalleryText;


 });
    $scope.getData();
    $scope.Pic = {};

    $scope.DeleteData = function (id) {

        $http.get("/api/Gallery/DeletePic/" + id)
        .success(function (data, status) {
            alertify.success("با موفقیت حذف شد");

        }).error(function (data, status) {
            alertify.error(data.Message);
        }).then(function () {
            $scope.getData();
        });

    }
    $scope.ConvertDate = function (x)
    {
        var date = x.GalleryRegisterDate.split('T');
        var sDate = date[0].split('-');
        return ToShamsi(parseInt(sDate[0]), parseInt(sDate[1]), parseInt(sDate[2]), 'short'); 
    }

    $scope.SaveData = function () {
        var _form = new FormData();
        _form.append("Picture", imgUpload.files[0]);
        _form.append("Gallery", JSON.stringify($scope.Pic));


        $http({
            url: '/api/Gallery/RegisterPicture',
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
        $http.get("/api/Gallery/GetPicture/" + id)
               .success(function (data, status) {
                   $scope.Pic = data;
                   imgUpload.value = '';
               }).then(function () {
                   $('#myModal').modal('toggle');

               }

               );
    }

    $scope.ClearData = function () {

        
        $scope.Pic = {};
        $scope.Pic.GalleryPicId = 0;
        imgUpload.value = '';
    }

});


