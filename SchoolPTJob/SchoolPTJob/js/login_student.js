$(function () {
    if ($.cookie('StuUserName')!='null' && $.cookie('StuPwd')!='null')
    {
        $('input[name=phoneOrMail]').val($.cookie('StuUserName'));
        $('input[name=pwd]').val($.cookie('StuPwd'));
        $("input[type=checkbox]").attr("checked", "checked");
    }
    $("input[type=button]").click(function () {
        var phoneOrMail = $.trim($('input[name=phoneOrMail]').val());
        var pwd = $.trim($('input[name=pwd]').val());
        var yzm = $.trim($('input[name=yzm]').val());
        if (phoneOrMail == '' || pwd == '' || yzm == '') {
            alert("请将信息填写完整");
        }
        else if (yzm.toLowerCase() != _picTxt.toLowerCase()) {
            alert("验证码错误");
        }
        else {
            $.post("../ajax/stuLogin.ashx", { "phoneOrMail": phoneOrMail, "pwd": $.md5(pwd) }, function (data) {
                location.href = "resume.html";
                if (data == "登录成功") {
                    if ($("input[type=checkbox]").is(":checked")) {
                        $.cookie('StuUserName', phoneOrMail, { expires: 365, path: '/' });
                        $.cookie('StuPwd', pwd, { expires: 365, path: '/' });
                    }
                    else
                    {
                        $.cookie('StuUserName', phoneOrMail, { expires: 1, path: '/' });
                        $.cookie('StuPwd', pwd, { expires: 1, path: '/' });
                    }
                }
            });
        }
    });
})