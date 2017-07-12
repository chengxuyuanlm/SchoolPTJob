$(function () {
    loadContentInfopt();
    loadContentInfoe();
    if ($.cookie('StuUserName') != 'null' || $.cookie('userName') != 'null') {
        $("nav #top .user").show();
        $("nav #top .none").hide();
        if ($.cookie('StuUserName') != 'null')
            $("nav #top .user .login").eq(0).text($.cookie('StuUserName'));
        else if ($.cookie('userName') != 'null')
            $("nav #top .user .login").eq(0).text($.cookie('userName'));
    }
    $("nav #top .user .login").eq(1).click(function () {
        $.cookie('StuUserName', null);
        $.cookie('userName', null);
        $.cookie('StuPwd', null);
        $.cookie('pwd', null);
        location.reload();
    });
    //loadbtn();
    $("#btn").click(function () {//点击投个简历按钮
        loadbtn();
    });
    function loadbtn() {
        var json = getUrlJson();
        $.get("../ajax/content_session.ashx", { pt_Id: json["pt_Id"] }, function (data) {
            var serverData = $.parseJSON(data);
            var serverDataLength = serverData.length;
            if (serverData != "nodata") {//判断是否已登录
                //$("<td>" + serverData + "</td>").appendTo("#ptName");
                //alert(serverData);
                alert("提交成功");
            }
            else
            {
                alert("请先登录");
            }
        });
    }

});
function getUrlJson() {//将url转换成json格式

    var vars = {}, hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        if (hash[0] == 'hotName')
            hash[1] = decodeURIComponent(hash[1]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
//拿到PTJobTable表的需要的数据显示在网页上
function loadContentInfopt() {
    var json = getUrlJson();
    console.log(json);
    $.get("../ajax/content.ashx", json, function (data) {
        var serverData = $.parseJSON(data);
        var serverDataLength = serverData.length;
        //$("<td>"+serverDataLength+"</td>").appendTo("#ptName");
        for (var i = 0; i < serverDataLength; i++) {
            //    //$("<tr><td>" + serverData[i].bg_Name + "</td><td>" + serverData[i].bg_Pwd + "</td></tr>").appendTo("#tabList");
            //    //$("<td>是名字嘛</td>").appendTo("#ptName");
            $("#ptName").html(serverData[i].pt_Name);
            $("#ptAddress").html(serverData[i].pt_Address);
            $("#ptMoney").html(serverData[i].pt_Money);
            $("#ptTime").html(serverData[i].pt_Time);

        }
    });
}
//拿到Employee表的需要的数据显示在网页上
function loadContentInfoe() {
    var json = getUrlJson();
    $.get("../ajax/content1.ashx", json, function (data) {
        var serverData = $.parseJSON(data);
        var serverDataLength = serverData.length;
        //$("<td>"+serverDataLength+"</td>").appendTo("#ptName");
        for (var i = 0; i < serverDataLength; i++) {
            //    //$("<tr><td>" + serverData[i].bg_Name + "</td><td>" + serverData[i].bg_Pwd + "</td></tr>").appendTo("#tabList");
            //    //$("<td>是名字嘛</td>").appendTo("#ptName");
            $("#eAddress").html(serverData[i].e_Address);

        }
    });
}







