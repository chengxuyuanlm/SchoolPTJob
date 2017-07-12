var json = {};
$(function () {
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
        location.reload();
    });

    $("#area li").click(function(){
            $(".area").removeClass("area");
            $(this).addClass("area");
           
        });
    $("#select1 ul li").click(function(){
        $("#select1 .selecting").toggleClass("selected");
        $("#select1 .selecting").removeClass("selecting");
        $(this).removeClass("selected");
        $(this).addClass("selecting");
        var index = $(this).index();
        getData('money', index);
    });
    $("#select2 ul li").click(function(){
        $("#select2 .selecting").toggleClass("selected");
        $("#select2 .selecting").removeClass("selecting");
        //$(".selecting").addClass("selected");
        $(this).removeClass("selected");
        $(this).addClass("selecting");
        var index = $(this).index();
        getData('num', index);
    });
    $("#select3 ul li").click(function(){
        $("#select3 .selecting").toggleClass("selected");
        $("#select3 .selecting").removeClass("selecting");
        //$(".selecting").addClass("selected");
        $(this).removeClass("selected");
        $(this).addClass("selecting");
        var index = $(this).index();
        getData('type', index);
    });
    $("#select4 ul li").click(function(){
        $("#select4 .selecting").toggleClass("selected");
        $("#select4 .selecting").removeClass("selecting");
        //$(".selecting").addClass("selected");
        $(this).removeClass("selected");
        $(this).addClass("selecting");
    });
    $("#select5 ul li").click(function(){
        $("#select5 .selecting").toggleClass("selected");
        $("#select5 .selecting").removeClass("selecting");
        //$(".selecting").addClass("selected");
        $(this).removeClass("selected");
        $(this).addClass("selecting");
    });
    $("#sort li").click(function(){
        $("#sort .sorting").toggleClass("sort");
        $("#sort .sorting").removeClass("sorting");
        $(this).removeClass("sort");
        $(this).addClass("sorting");
        var index = $(this).index();
        getData('sort', index);

    });
    $("#page div").click(function(){
        $(".pageing").toggleClass("page");
        $(".pageing").removeClass("pageing");
        $(this).removeClass("page");
        $(this).addClass("pageing");
       
    });

    $("#btn").click(function () {
        var str = $("#test").val();
        if(str != "")
        {
            location.href = 'search.html?hotName=' + str;
        }
        else
        {
            alert("请输入关键字");
        }
    })
    //getData(json);
    json = getUrlJson();
    getData(json);
});
function getUrlJson() {//将url转换成json格式

    var vars = {}, hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        if (hash[0] == 'hotName')
            hash[1] = decodeURIComponent(hash[1]);
        vars[hash[0]]=hash[1];
    }
    return vars;
}
function getData(item,index)//发送get请求 获取数据并初始化分页 用于查询和筛选
{
    //var json = getUrlJson();
    json[item] = index;
    json['page'] = 1;
    $(document).ajaxStart(function () { $(".content").remove(); $("#loading").show(); });
    
    $.ajax({
        url : "../ajax/search.ashx",
        type: 'get',
        data: json,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        timeout: 10000,
        success: function (data) {
            data = eval('(' + data + ')');
            $(document).ajaxStop(function () { $("#loading").hide(); setData(data[0]); });
        var options = {
            totalNum: data[1],//总数据条数
            totalPage: Math.ceil(data[1] / 6),//总页数
            showPageNum: 5//最多显示多少页数
        };
        $('#pageBox').pageing(options);
        var width = $('#pageBox').width()
        var marginRight =( 880 - width )/2+ 'px';
        $('#pageBox').css('margin-right', marginRight);
        //try {
        //
        //}
        //catch (e) {

        //}
        }
    });

    
}
function setData(data) {//将获取的数据展示出来
    $(".content").remove();
    if (data.length > 0)
    {
        for (var i = 0 ; i < data.length; i++)
        {
            var oDiv = document.createElement('div');
            oDiv.className = "content";
            oDiv.innerHTML = "<div class='contentL'><li class='contentT'><a href=../page/content.html?hotName=" + data[i]['pt_Name'] + "&empId=" + data[i]['pt_eId'] + "&pt_Id=" + data[i]['pt_Id'] +">" + data[i]['pt_Name'] + "</a></li><li class='education'>" + data[i]['e_Name'] + "</li></div><div class='img'><img src='../" + data[i]['e_PhotoPath'] + "'></div><div class='contentR'><li >" + data[i]['pt_Address'] + "</li><p>" + data[i]['pt_Money'] + "/天  " + data[i]['pt_Time'] + "</p></div>"
            $("#paging").before(oDiv);
        }
    }
    else
    {
        var oDiv = document.createElement('div');
        oDiv.className = "content";
        oDiv.innerHTML = "暂无相关数据";
        $("#paging").before(oDiv);
        
    }
        
}
function getAjax(item,index)//发送get请求获取数据 用于分页查询
{
    $(document).ajaxStart(function () { $(".content").remove(); $("#loading").show(); });
    json[item] = index;
    $.ajax({
        url: "../ajax/search.ashx",
        type: 'get',
        data: json,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        timeout: 10000,
        success: function (data) {
            data = eval('(' + data + ')');
            $(document).ajaxStop(function () { $("#loading").hide(); setData(data[0]); });
        }
    });
    
}