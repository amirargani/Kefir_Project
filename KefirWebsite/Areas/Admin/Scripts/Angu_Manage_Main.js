function SendAward()
{
    var i = AwardCount.value;
    $.ajax({
        method: "Get",
        url: "/api/Setting/SetAwardCount/" + i,
    })
  .success(function (msg) {
      alertify.success("با موفقیت ثبت شد");
  });
}
GetAward();
function GetAward()
{
    $.ajax({
        method: "Get",
        url: "/api/Setting/GetAwardCount/" ,
    })
 .success(function (msg) {
     AwardCount.value=msg;
 });
}