$(function () {
    console.log($.cookie('userName'));
    if ($.cookie('userName')!='null' && $.cookie('pwd')!='null') {
        $('input[name=phoneOrMail]').val($.cookie('userName'));
        $('input[name=pwd]').val($.cookie('pwd'));
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
            $.post("../ajax/companyLogin.ashx", { "phoneOrMail": phoneOrMail, "pwd": $.md5(pwd) }, function (data) {
                location.href = "company_information.html";
                if (data == "登录成功") {
                    if ($("input[type=checkbox]").is(":checked")) {
                        $.cookie('userName', phoneOrMail, { expires: 365, path: '/' });
                        $.cookie('pwd', pwd, { expires: 365, path: '/' });
                    }
                    else
                    {
                        $.cookie('userName', phoneOrMail, { expires: 1, path: '/' });
                        $.cookie('pwd', pwd, { expires: 1, path: '/' });
                    }
                }
            });
        }
    });
})