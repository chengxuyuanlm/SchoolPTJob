$(function () {
    if ($.cookie('StuUserName') != 'null' && $.cookie('StuPwd') != 'null') {
        $.get("../ajax/edit.ashx", function (data) {
            data = eval('(' + data + ')');
            if (data[0][0]['s_Sex'] == '男')
                $("select[name = sex]").val('man');
            else if (data[0][0]['s_Sex'] == '女')
                $("select[name = sex]").val('woman');
            $("input[name = area]").val(data[0][0]['s_Address']);
            $("input[name = unit]").val(data[0][0]['s_Department']);
            $("input[name = major]").val(data[0][0]['s_Professional']);
            $("input[name = phone]").val(data[0][0]['s_Phone']);
            $("input[name = email]").val(data[0][0]['s_Email']);
            $("textarea[name = message]").val(data[1][0]['re_Edu']);
            $("textarea[name = time]").val(data[1][0]['re_WorkTime']);
            $("textarea[name = Skill]").val(data[1][0]['re_Skill']);
            $("textarea[name = Describe]").val(data[1][0]['re_Describe']);
        });
    }
    else
    {
        location.href = "index_login_student.html";
    }
    var a = 0;
    $("#bt").click(function () {
        if (a == 0) {
            $(":enabled").attr("disabled", "true");
            var json = {
                "s_Sex": $("select[name = sex] option:selected").text(),
                "s_Address": $("input[name = area]").val(),
                "s_Department": $("input[name = unit]").val(),
                "s_Professional": $("input[name = major]").val(),
                "s_Phone": $("input[name = phone]").val(),
                "s_Email": $("input[name = email]").val(),
                "re_Edu": $("textarea[name = message]").val(),
                "re_WorkTime": $("textarea[name = time]").val(),
                "re_Skill": $("textarea[name = Skill]").val(),
                "re_Describe": $("textarea[name = Describe]").val()

            }
            $.post("../ajax/edit.ashx", json, function (data) {
                console.log(data);
            });
            $(this).html("编辑");
            a = 1;
        } else {

            $(":disabled").removeAttr("disabled");
            
            $(this).html("保存");
            a = 0;
        }
    })
});