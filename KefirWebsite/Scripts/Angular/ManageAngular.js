

app.controller('ControllerSlider', function ($scope, $http) {
    $http.get("/api/Slides/GetSlides")
   .success(function (data, status) {
       $scope.slides = data;

   });
    $scope.SetSlideText = function (x) {
        modalBody.innerHTML = x.SlideText;
    }
    $scope.getActive = function(d)
    {
        if (d == 0) return "active";
        return "";
    }

});



app.controller('ControllerProgress', function ($scope, $http) {

    $scope.Title = {};
    $http.get("/api/Progress/GetProgresses")
   .success(function (data, status) {
       $scope.progresses = data;

   });
    $http.get("/api/Setting/GetProgress")
   .success(function (data, status) {
       $scope.Title.AbstractText = data.AbstractText;
       $scope.Title.AbstractTitle = data.AbstractTitle;


   });
    $scope.getStyle = function(i)
    {
        if(i==3)
            return "margin-top: 40%";
        return "";
    }
    

   


});
app.controller('ControllerGallery', function ($scope, $http) {
    $scope.Title = {};
    $scope.ConvertDate = function(d)
    {
        var date = d.GalleryRegisterDate.split('T');
        var sDate = date[0].split('-');
        return ToShamsi(parseInt(sDate[0]), parseInt(sDate[1]), parseInt(sDate[2]), 'short');
        
    }

    $http.get("/api/Gallery/GetGallery")
   .success(function (data, status) {
       $scope.gallery = data;

   });

    $http.get("/api/Setting/GetGallery")
  .success(function (data, status) {
      $scope.Title.GalleryTitle = data.GalleryTitle;
      $scope.Title.GalleryText = data.GalleryText;

  });
});


app.controller('ControllerExperts', function ($scope, $http) {

    $scope.Title = {};
    $http.get("/api/Experts/GetExperts")
   .success(function (data, status) {
       $scope.experts = data;

   });


    $http.get("/api/Setting/GetExpert")
   .success(function (data, status) {
       $scope.Title.ExpertTitle = data.ExpertTitle;
       $scope.Title.ExpertText = data.ExpertText;;


   });
});

app.controller('ControllerAbstracts', function ($scope, $http) {


    $http.get("/api/Abstract/GetAbstracts")
   .success(function (data, status) {
       $scope.abstracts = data;

   });

    $scope.getActive = function(i)
    {
        if (i == 0) return "active";
        return "";
    }

});
app.controller('ControllerNews', function ($scope, $http) {
    $scope.Title = {};
    $scope.Title.NewsTitle = "درحال بارگیری";
    $scope.Title.NewsText = "درحال بارگیری";
    $http.get("/api/Setting/GetNews")
       .success(function (data, status) {
           $scope.Title.NewsTitle = data.NewsTitle;
           $scope.Title.NewsText = data.NewsText;

       });
    $scope.firstNews = [];
    $scope.news = [];
    var list = [];
    $http.get("/api/News/GetNews")
   .success(function (data, status) {
       var _to = data.length;
       list = data;
       for (var i = 0; (i < _to)&&(i<3); i++) {
           $scope.firstNews[i] = list[i];
       }
       $scope.news = $scope.firstNews;
      
   });
    $scope.moreData = function()
    {
        for (var i = 3; i < list.length ; i++) {
            $scope.firstNews[i] = list[i];
        }
    }

    $scope.isSlider = function (n) {
        return n.NewsPirctures.length > 1;
    }
    $scope.getClassName = function (i) {
        if (i == 0) return "active";
        return "";
    }
    $scope.ConvertDate = function(x)
    {
        var date = x.NewsDate.split('T');
        var sDate = date[0].split('-');
        return ToShamsi(parseInt(sDate[0]), parseInt(sDate[1]), parseInt(sDate[2]), 'short');
    }
 
    
});


app.controller('ControllerContactUs', function ($scope, $http) {
    $scope.c = {};
    $scope.sendData = function () {
        $scope.c.HasRead = false;
        $http.post("/api/ContactUs/RegisterContacuUs", $scope.c)
        .success(function () {
            alertify.success("با موفقیت ذخیره شد");
            $scope.c = {};
        }).error(function (obj) {
            alertify.error(obj.Message);
        });
    }
});



app.controller('ControllerRegister', function ($scope, $http) {
    $scope.User = {};
    $scope.sendData = function () {
        $("#loadingReg").css({"display":"block"});
        if ($scope.User.Password === $scope.User.Password2) {
            $http.post("/api/Users/Register", $scope.User)
            .success(function () {
                alertify.success("ثبت نام با موفقیت انجام شد. لینک فعالسازی به ایمیل شما ارسال گردید.");
                $("#loadingReg").css({ "display": "none" });
                $scope.c = {};
            }).error(function (obj) {
                alertify.error(obj.Message);
                $("#loadingReg").css({ "display": "none" });
            });
        }
        else
        {
            alertify.error("عدم مطابقت رمز عبور و تکرار آن");
        }
    }

    

});

