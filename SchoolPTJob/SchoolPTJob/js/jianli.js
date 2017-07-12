$(function () {
    if ($.cookie('StuUserName') != 'null' && $.cookie('StuPwd') != 'null') {
        $.get("../ajax/resume.ashx", function (data) {
            data = eval('(' + data + ')');
            var str = "<div id='pic'><img src=" + data[0][0]['s_PhotoPath'] + "></div><div id='name'>" + data[0][0]['s_RealName'] + "</div><div id='more'><ul><li id='sex'>" + data[0][0]['s_Sex'] + "</li><li>|</li><li id='area'>" + data[0][0]['s_Address'] + "</li><li>|</li><li id='unit'>" + data[0][0]['s_Department'] + "</li><li>|</li><li id='major'>" + data[0][0]['s_Professional'] + "</li></ul><ul id='more2'><li id='ipone'>" + data[0][0]['s_Phone'] + "</li><li></li><li id='email'>" + data[0][0]['s_Email'] + "</li></ul></div>"
            $("#introduce").html(str);
            str = "";
            for(var i =0 ;i<data[1].length;i++)
            {
                var pass = "";
                if (data[1][i]['RE_Pass'] == '通过')
                    pass = "通过面试";
                else if (data[1][i]['RE_Pass'] == '拒绝')
                    pass = "未通过面试";
                else
                    pass = "正在处理中";
                str += "<div class='content'><div class='left'><div class='job'>" + data[1][i]['pt_Name'] + "</div><div class='company'>" + data[1][i]['e_RealName'] + "</div><div class='message'><div class='img'><img src='../img/area.png'></div><div class='Area'>" + data[1][i]['pt_Address'] + "</div><div class='money'>￥" + data[1][i]['pt_Money'] + "元/天</div><div class='date'>" + data[1][i]['pt_Time'] + "</div></div></div><div class='right'>" + pass + "</div></div>";
               
            }
            $("#content").html(str);
        });
    }
    else {
        location.href = "index_login_student.html";
    }

    $("#editmenu div").click(function () {
        $(".ing").removeClass("ing");
        var a = $(this).attr("id") + '2';
        var aa = document.getElementById(a);
        aa.className = "ing";
    });
});