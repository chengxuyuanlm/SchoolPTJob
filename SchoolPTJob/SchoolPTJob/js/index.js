$(function () {
    if ($.cookie('StuUserName') != 'null' || $.cookie('userName') != 'null') {
        $("nav #top .user").show();
        $("nav #top .none").hide();
        if ($.cookie('StuUserName') != 'null') {
            $("nav #top .user .login").eq(0).text($.cookie('StuUserName'));
            $("nav #top .user .login").eq(0).attr("href", "page/resume.html");
        }
        else if ($.cookie('userName') != 'null')
        {
            $("nav #top .user .login").eq(0).text($.cookie('userName'));
            $("nav #top .user .login").eq(0).attr("href", "page/company_information.html");
        }
    }
    $("nav #top .user .login").eq(1).click(function () {
        $.cookie('StuUserName', null);
        $.cookie('userName', null);
        $.cookie('StuPwd', null);
        $.cookie('pwd', null);
        location.reload();
    });

    getData();

    auto();
    //轮播图
    var index = 0;
    var len = $("#banner #lb ul li").length - 1;
    $("#banner #btnLeft").click(function () {
        index--;
        index = index < 0 ? len : index;
        $("#banner #lb ul li").eq(index).fadeIn().siblings().fadeOut();
    });

    $("#banner #btnRight").click(function () {
        auto();
    });

    $("#banner").hover(function () {
        $("#banner .btn").fadeIn();
        clearInterval(timer);
    }, function () {
        $("#banner .btn").fadeOut();
        setInterval('auto()', 10000);
    });

    var timer = setInterval('auto()', 10000);
    function auto() {
        index++;
        index = index > len ? 0 : index;
        $("#banner #lb ul li").eq(index).fadeIn().siblings().fadeOut();
    }
    //轮播图

    //兼职分类列表
    $("#workClass ul li .show").each(function (index) {
        var showLeft = index * 158 + 72;
        var triLeft = showLeft + 41 + "px";
        showLeft = -showLeft + "px";
        $(this).css("left", showLeft);
        $(this).find(".triangle").css("left", triLeft);
    });
    //兼职分类列表

    $("#searchBtn").click(function () {
        var str = $("#searchInput").val();
        location.href = str == "" ? '../page/search.html' : '../page/search.html?hotName='+str;
    });

    function getData()//获取热门兼职数据
    {
        $.get("../ajax/index.ashx", function (data) {
            data = eval('(' + data + ')');
            try
            {
                var str = "";//热门兼职
                for(var i = 0 ; i<data[0].length;i++)
                {
                    if(i<6)//热门推荐取前6条
                        str += "<li><a href='../page/search.html?hotName=" + data[0][i]['pt_Name'] + "'>" + data[0][i]['pt_Name'] + "</a></li>";
                    var oA = document.createElement('a');
                    oA.href = '../page/search.html?hotName=' + data[0][i]['pt_Name'];
                    oA.innerHTML = data[0][i]['pt_Name'];
                    switch(data[0][i]['pt_Kind'])
                    {
                        
                        case "专业兼职": $(".show").eq(0).find('.content').append(oA);break;
                        case "长期兼职": $(".show").eq(1).find('.content').append(oA); break;
                        case "周末兼职": $(".show").eq(2).find('.content').append(oA); break;
                        case "临时兼职": $(".show").eq(3).find('.content').append(oA); break;
                        case "其他兼职": $(".show").eq(4).find('.content').append(oA); break;
                    }
                }
                str = $("#search ul").html() + str;
                $("#search ul").html(str);

                var oDiv;
                str = "";
                for (var i = 0 ; i < data[1].length; i++)
                {
                    if(i%2==0)
                    {
                        oDiv = document.createElement('div');
                        oDiv.className = "work";
                    }
                    console.log(data[1][0]);
                    str += "<div class='workCon'><div class='conLeft'><p class='workTit'><a href=../page/content.html?hotName=" + data[1][i]['pt_Name'] + "&empId=" + data[1][i]['pt_eId'] + "&pt_Id=" + data[1][i]['pt_Id'] + ">" + data[1][i]['pt_Name'] + "</a></p><p>" + data[1][i]['e_Name'] + "</p><p><img align='absmiddle' src='image/local.png'><span>" + data[1][i]['pt_Address'] + "</span><span>￥" + data[1][i]['pt_Money'] + "元/天</span><span>" + data[1][i]['pt_Time'] + "</span></p></div><div class='conRight'><img src='" + data[1][i]['e_PhotoPath'] + "'></div></div>";
                    if(i%2==0)
                        str += "<div class='hr'></div>";
                    if (i % 2 != 0)
                    {
                        oDiv.innerHTML = str;
                        str = "";
                        $("#hotMain").append(oDiv);
                    }
                }
                str = $("#hotMain").html();
                str += "<div id='more'><a href='../page/search.html'>更多职位</a></div>";
                $("#hotMain").html(str);
            }
            catch(e)
            {
               alert(data);
            } 
            
        });
    }
});
