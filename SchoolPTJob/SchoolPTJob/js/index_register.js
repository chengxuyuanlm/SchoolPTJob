$(function () {

    var aLi = document.getElementsByClassName('registerbar')[0].getElementsByTagName('li');
    var aInput = document.getElementsByClassName('register_moblieform')[0].getElementsByTagName('input');
    var length = aLi.length;
    var oP = document.createElement('p');
    var isPhone = true;
    aLi[0].appendChild(oP);
    for (var i = 0; i < length; i++) {
        aLi[i].i = i;
        aLi[i].onclick = function () {
            if (this.i) {
                aLi[0].className = '';
                aLi[1].className = 'on';
                isPhone = false;
                aLi[0].removeChild(oP);
                aLi[1].appendChild(oP);
                aInput[0].style.display = 'none';
                aInput[0].value = '';
                aInput[1].style.display = 'block';
            } else {
                aLi[0].className = 'on';
                aLi[1].className = '';
                isPhone = true;
                aLi[0].appendChild(oP);
                aInput[0].style.display = 'block';
                aInput[1].value = '';
                aInput[1].style.display = 'none';
            };
        };
    };

    $("#container #register_content .register_moblieform ul li").click(function () {
        $(this).addClass('selectUser').siblings().removeClass('selectUser');
    })

    $("input[type=checkbox]").click(function () {
        if ($("input[type=checkbox]").is(":checked")) {
            $("input[type=button]").prop("disabled", false);
        }
        else {
            $("input[type=button]").prop("disabled", true);
        }
    });
    $("input[type=button]").click(function () {
        var phoneOrMail;
        if ($(".registerbar .on").text() == "手机注册") {
            phoneOrMail = $.trim($('input[name=phone]').val());
        }
        else {
            phoneOrMail = $.trim($('input[name=email]').val());
        }


        var pwd = $.md5($.trim($('input[name=pwd]').val()));
        var yzm = $.trim($('input[name=yzm]').val());
        if (phoneOrMail == '' || pwd == '' || yzm == '') {
            alert("请将信息填写完整");
        }
        else if ($(".registerbar .on").text() == "手机注册" && /^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$/.test(phoneOrMail) == false) {
            alert("手机格式不正确");
        }
        else if ($(".registerbar .on").text() == "邮箱注册" && /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/.test(phoneOrMail) == false) {
            alert("邮箱格式不正确");
        }
        else if (yzm.toLowerCase() != _picTxt.toLowerCase()) {
            alert("验证码错误");
        }
        else {
            if ($.trim($(".selectUser p").text()) == '学生') {
                $.post("../ajax/stuReg.ashx", { "phoneOrMail": phoneOrMail, "pwd": pwd, "isPhone": isPhone }, function (data) {
                    alert(data);
                });
            }
            else {
                $.post("../ajax/companyReg.ashx", { "phoneOrMail": phoneOrMail, "pwd": pwd, "isPhone": isPhone }, function (data) {
                    alert(data);
                });
            }
        }
    });
});