/// <reference path="G:\model\KefirProject\KefirWebsite\Scripts/Angular/angular.min.js" />

Adminapp.controller('SlideController', function ($scope, $http) {

    $scope.getData = function () {
        $http.get("/api/Slides/GetSlides")
        .success(function (data, status) {
            $scope.Slides = data;

        });
    }
    $scope.getData();
    $scope.slide = {};

    $scope.DeleteData = function (id) {

        $http.get("/api/Slides/DeleteSlide/" + id)
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
        _form.append("slide", JSON.stringify($scope.slide));


        $http({
            url: '/api/Slides/RegisterSlide',
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
        $http.get("/api/Slides/GetSlide/" + id)
               .success(function (data, status) {
                   $scope.slide.SlideId = data.SlideId;
                   $scope.slide.SlideSimpleTitle = data.SlideSimpleTitle;
                   $scope.slide.SlideCssTitle = data.SlideCssTitle;
                   $scope.slide.SlideCssTitle = data.SlideCssTitle;
                   $scope.slide.SlidePicDesc = data.SlidePicDesc;
                   $scope.slide.SlideText = data.SlideText;
                   imgUpload.value = '';
               }).then(function () {
                   $('#myModal').modal('toggle');

               }
               
               );
    }

    $scope.ClearData = function()
    {

        $scope.slide.SlideId = 0;
        $scope.slide = {}
        imgUpload.value = '';
    }

});


