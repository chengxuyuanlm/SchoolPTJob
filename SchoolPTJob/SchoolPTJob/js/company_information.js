/* 
* @Author: anchen
* @Date:   2016-11-26 17:54:12
* @Last Modified by:   anchen
* @Last Modified time: 2016-12-22 13:23:15
*/
var PT_Id = "";
var RE_Id = "";
$(document).ready(function () {
    var str = "";
    var changeid = "";
    if ($.cookie('userName') != 'null' && $.cookie('pwd') != 'null') {
        getData();
        $(".photokuang").mouseenter(function () {
            $(".change_photo").show();
        })
        $(".photokuang").mouseout(function () {
            $(".change_photo").hide();
        })

        $(".choose li").mouseenter(function () {
            $(this).css("backgroundColor", "#79D3ED");
        })
        $(".choose li").mouseout(function () {
            $(this).css("backgroundColor", "#00B7EE");
        })
        $(".choose li:nth-child(1)").click(function () {
            $(this).addClass('choosebgc');
            $(this).siblings().removeClass('choosebgc');
            $(".members_home").show()
            $(".members_home").siblings().hide()

        })
        $(".choose li:nth-child(2)").click(function () {
            $(this).addClass('choosebgc');
            $(this).siblings().removeClass('choosebgc');
            $(".members_information").show()
            $(".members_information").siblings().hide();
            $(".base_information_head_right2").addClass('hide');
            $(".base_information_head_right1").removeClass('hide')
            $(".base_information_input").attr("disabled", true)

        })
        $(".choose li:nth-child(3)").click(function () {
            $(this).addClass('choosebgc');
            $(this).siblings().removeClass('choosebgc');
            $(".looking_for").show()
            $(".looking_for").siblings().hide()

        })
        $(".choose li:nth-child(4)").click(function () {
            $(this).addClass('choosebgc');
            $(this).siblings().removeClass('choosebgc');
            $(".security_center").show()
            $(".security_center").siblings().hide()

        })

        $(".icon1").click(function () {
            $(".choose li:nth-child(4)").addClass('choosebgc');
            $(".choose li:nth-child(4)").siblings().removeClass('choosebgc');
            $(".security_center").show()
            $(".security_center").siblings().hide()
        })
        $(".icon2").click(function () {
            $(".choose li:nth-child(4)").addClass('choosebgc');
            $(".choose li:nth-child(4)").siblings().removeClass('choosebgc');
            $(".security_center").show()
            $(".security_center").siblings().hide()
        })
        $(".icon3").click(function () {
            $(".choose li:nth-child(4)").addClass('choosebgc');
            $(".choose li:nth-child(4)").siblings().removeClass('choosebgc');
            $(".security_center").show()
            $(".security_center").siblings().hide()
        })


        $(".choose li:nth-child(5)").click(function () {
            $(this).addClass('choosebgc');
            $(this).siblings().removeClass('choosebgc');
            $(".hiring_record").show()
            $(".hiring_record").siblings().hide()

        })
        $(".choose li:nth-child(6)").click(function () {
            $(this).addClass('choosebgc');
            $(this).siblings().removeClass('choosebgc');
            $(".news").show()
            $(".news").siblings().hide()

        })
        $(".icon4").click(function () {
            $(".choose li:nth-child(6)").addClass('choosebgc');
            $(".choose li:nth-child(6)").siblings().removeClass('choosebgc');
            $(".news").show()
            $(".news").siblings().hide()
        })

        $(".looknow").mouseenter(function () {
            $(this).addClass('looknow_h')
        })
        $(".looknow").mouseout(function () {
            $(this).removeClass('looknow_h')
        })


        $(".alert_changepwd_center input").focus(function () {
            $(this).css("border-color", "#00B7EE")
        })
        $(".newpassword").blur(function () {
            $(this).css("border-color", "#ccc")
            if ($(this).val() != "") {
                $(this).css("border-color", "#00B7EE")
            }
        })
        $(".newpassword2").blur(function () {
            $(this).css("border-color", "#ccc")
            if ($(this).val() != "") {
                $(this).css("border-color", "#00B7EE")
            }
        })
        $(".password").blur(function () {
            $(this).css("border-color", "#ccc")
            if ($(this).val() != "") {
                $(this).css("border-color", "#00B7EE")
            }
            if ($.md5($.trim($(this).val())) != e_pwd) {
                $(this).css("border-color", "red")
            }
        })

        $(".alert_phone_center input").focus(function () {
            $(this).css("border-color", "#00B7EE")
        })
        $(".alert_phone_center input").blur(function () {
            $(this).css("border-color", "#ccc")
        })
        //var text1 = $("#text1").attr("value");
        //var pw1 = $("#pw1").attr("value");
        //var text2 = $("#text2").attr("value");
        //var text3 = $("#text3").attr("value");
        //var text4 = $("#text4").attr("value");
        //var text5 = $("#text5").attr("value");
        //var email = $("#email").attr("value");
        //var phone = $("#phone").attr("value");
        //$("#pw1").focus(function(){
        //    var account_value=$(this).val();
        //    if(account_value==pw1){
        //        $(this).val("");
        //    }
        //});
        //$("#pw1").blur(function(){
        //    var account_value=$(this).val();
        //    if(account_value==""){
        //        $(this).val(pw1);
        //    }
        //});
        //$("#text1").focus(function(){
        //    var account_value=$(this).val();
        //    if(account_value==text1){
        //        $(this).val("");
        //    }
        //});
        //$("#text1").blur(function(){
        //    var account_value=$(this).val();
        //    if(account_value==""){
        //        $(this).val(text1);
        //    }
        //});
        //$("#text2").focus(function(){
        //    var account_value=$(this).val();
        //    if(account_value==text2){
        //        $(this).val("");
        //    }
        //});
        //$("#text2").blur(function(){
        //    var account_value=$(this).val();
        //    if(account_value==""){
        //        $(this).val(text2);
        //    }
        //});
        //$("#text3").focus(function(){
        //    var account_value=$(this).val();
        //    if(account_value==text3){
        //        $(this).val("");
        //    }
        //});
        //$("#text3").blur(function(){
        //    var account_value=$(this).val();
        //    if(account_value==""){
        //        $(this).val(text3);
        //    }
        //});
        //$("#text4").focus(function(){
        //    var account_value=$(this).val();
        //    if(account_value==text4){
        //        $(this).val("");
        //    }
        //});
        //$("#text4").blur(function(){
        //    var account_value=$(this).val();
        //    if(account_value==""){
        //        $(this).val(text4);
        //    }
        //});
        //$("#text5").focus(function(){
        //    var account_value=$(this).val();
        //    if(account_value==text5){
        //        $(this).val("");
        //    }
        //});
        //$("#text5").blur(function(){
        //    var account_value=$(this).val();
        //    if(account_value==""){
        //        $(this).val(text5);
        //    }
        //});
        //$("#email").focus(function(){
        //    var account_value=$(this).val();
        //    if(account_value==email){
        //        $(this).val("");
        //    }
        //});
        //$("#email").blur(function(){
        //    var account_value=$(this).val();
        //    if(account_value==""){
        //        $(this).val(email);
        //    }
        //});
        //$("#phone").focus(function(){
        //    var account_value=$(this).val();
        //    if(account_value==phone){
        //        $(this).val("");
        //    }
        //});
        //$("#phone").blur(function(){
        //    var account_value=$(this).val();
        //    if(account_value==""){
        //        $(this).val(phone);
        //    }
        //})
        if (!$(".base_information_head_right1").is(":hidden")) {
            $(".base_information_input").attr("disabled", true)
        }
        $(".base_information_head_right1").click(function () {
            $(this).addClass('hide');
            $(".base_information_head_right2").removeClass('hide')
            $(".base_information_input").attr("disabled", false)
        })
        $(".base_information_head_right2").click(function () {
            $(this).addClass('hide');
            $(".base_information_head_right1").removeClass('hide')
            $(".base_information_input").attr("disabled", true)
        })


        $(".addnew").click(function () {
            $("#all").show();
            $("#alert").show();
            $("#alert_center").children('input').val("");
        })

        $(".alert_bottom").children('input').click(function () {
            $("#alert").hide();
            $("#alert_amend").hide();
        })
        $(".kuang").click(function () {
            $("#all").hide();
            $("#alert").hide();
            $("#alert_amend").hide();
        })
        $(".kuang2").click(function () {
            $("#all").hide();
            $("#alert_delete").hide();
            $("#alert_refuse").hide();
            $("#alert_interview").hide();
        })
        $(".changepwd").click(function () {
            $("#all").show();
            $(".alert_changepwd").show();

        })
        $(".alert_changepwd_kuang").click(function () {
            $("#all").hide();
            $(".alert_changepwd").hide(); $(".alert_phone").hide(); $(".alert_email").hide();
        })
        $(".changephone").click(function () {
            $("#all").show();
            $(".alert_phone").show();
        })
        $(".changeemail").click(function () {
            $("#all").show();
            $(".alert_email").show();
        })
        $(".no").click(function () {
            $("#all").hide();
            $("#alert_delete").hide();
            $("#alert_refuse").hide();
            $("#alert_interview").hide();
        })
        //$.ajax({
        //    url: "../ajax/company_information.ashx",
        //    type: 'POST',
        //    data:{},
        //    success: function (data) {
        //        data = eval('(' + data + ')');

        //        alert(data[0]);
        //        $("#kk").html($("#kk").html()+data[0]);
        //        //data = eval('(' + data + ')');
        //        //setData(data[0]);
        //    }
        //});


        $(".person_change").click(function () {
            $("#all").show();
            $("#alert_amend").show();

        })

        $(".looknow1").click(function () {
            $(".choose li:nth-child(3)").addClass('choosebgc');
            $(".choose li:nth-child(3)").siblings().removeClass('choosebgc');
            $(".looking_for").show()
            $(".looking_for").siblings().hide()
        })
        $(".looknow2").click(function () {
            $(".choose li:nth-child(6)").addClass('choosebgc');
            $(".choose li:nth-child(6)").siblings().removeClass('choosebgc');
            $(".news").show()
            $(".news").siblings().hide()
        })
    }
    else
    {
        location.href = "index_login_company.html";
    }
    
    
});

var e_pwd = "";
function getAjax()//发送get请求获取数据 用于分页查询
{
    //json[item] = index;

}
function getData() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: {},
        success: function (data) {
            data = eval('(' + data + ')');
            $(".basic_setup a").text(data[1]);
            $("#kk").html(data[0]);
            $("#cc").html(data[2]);
            e_pwd = data[3][0]["e_Password"];
            $("#text1").val(data[3][0]['e_Name']);
            $("#text3").val(data[3][0]['e_industry']);
            $("#text4").val(data[3][0]['e_ownership']);
            if (data[3][0]['e_Phone'] == "") {
                $("#phone").val("未验证");
                $(".phone").text("未认证");
                $(".e_Phone").text("未认证");
            }
            else {
                $("#phone").val(data[3][0]['e_Phone']);
                var telVal = data[3][0]['e_Phone'];
                var newTelVal = '';
                if (telVal.length > 0) {
                    for (var i = 0; i < telVal.length; i++) {
                        if (i < 3 || i >= telVal.length - 3) {
                            newTelVal += telVal[i];
                        } else {
                            newTelVal += '*';
                        }
                    }
                }
                $(".e_Phone").text(newTelVal);
                $(".phone").text("已认证");
                $(".icontel").css("color", "#E84548")
            }

            if (data[3][0]['e_Email'] == "") {
                $("#email").val("hehe");
                $(".e_Email").text("未绑定");
                $(".email").text("未绑定");
            }
            else {
                $("#email").val(data[3][0]['e_Email']);
                $(".e_Email").text("hee");
                $(".email").val(data[3][0]['e_Email']);
                $(".iconmail").css("color", "#E84548")
            }

            if (data[3][0]['e_RealName'] != "") {
                $(".e_Realname").text(data[3][0]['e_RealName']);
                $(".realname").text("已认证");
                $("#text5").val(data[3][0]['e_RealName']);
                $(".iconreal").css("color", "#E84548")
            }
            else {
                $("#text5").val("未认证")
                $(".realname").text("未认证");
                $(".e_Realname").text("未认证");
            }
            $(".news_content").html(data[4]);
            $(".Post_recruitment").text(data[5]);
            $(".Recruit_students").text(data[6]);
            $(".NoPeoplePT").text(data[5] - data[6]);
            $(".NoDisposePT").text(data[7]);
        }
    });
}
function employeechange() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: {},
        success: function (data) {
            data = eval('(' + data + ')');
            $("#text1").val(data[3][0]['e_Name']);
            $("#text5").val(data[3][0]['e_RealName']);
            $("#text3").val(data[3][0]['e_industry']);
            $("#text4").val(data[3][0]['e_ownership']);
            if (data[3][0]['e_Phone'] == "") {
                $("#phone").val("未验证");
            }
            else {
                $("#phone").val(data[3][0]['e_Phone']);
            }
            if (data[3][0]['e_Email'] == "") {
                $("#email").val("未验证");
            }
            else {
                $("#email").val(data[3][0]['e_Email']);
            }

        }
    });
}
function employeechangeOK() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: { e_Name: $("#text1").val(), e_RealName: $("#text5").val(), e_industry: $("#text3").val(), e_ownership: $("#text4").val(), e_Phone: $("#phone").val(), e_Email: $("#email").val() },
        success: function (data) {
            data = eval('(' + data + ')');
        }
    });
}
function person_change_click(id) {
    $("#all").show();
    $("#alert_amend").show();
    changeid = id;
    ptchange();
}

function person_delete_click(hhh) {
    $("#all").show();
    $("#alert_delete").show();
    str = hhh;
}

function interviewOK(hhh, jjj) {
    $("#all").show();
    $("#alert_interview").show();
    str = hhh; PT_Id = jjj;
}

function interviewNO(hhh) {
    $("#all").show();
    $("#alert_refuse").show();
    str = hhh;
}
function interviewOKok() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: { interviewOKok: str, PT_Id: PT_Id },
        success: function (data) {
            data = eval('(' + data + ')');
            $(".news_content").html(data[9]);
            $("#kk").html(data[8]);
            $("#all").hide();
            $("#alert_interview").hide();
        }
    });
}
function interviewOKno() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: { interviewOKno: str },
        success: function (data) {
            data = eval('(' + data + ')');
            $(".news_content").html(data[9]);
            $("#kk").html(data[8]);
            $("#all").hide();
            $("#alert_refuse").hide();
        }
    });
}


function ptdelet() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: { kk: str },
        success: function (data) {
            data = eval('(' + data + ')');
            $("#kk").html(data[8]);
            $("#all").hide();
            $("#alert_delete").hide();
        }
    });
}
function ptchange() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: { change: changeid },
        success: function (data) {
            data = eval('(' + data + ')');
            $("#pt_Kind").val(data[8][0]['pt_Kind']);
            $("#pt_Time").val(data[8][0]['pt_Time']);
            $("#pt_Money").val(data[8][0]['pt_Money']);
            $("#pt_Address").val(data[8][0]['pt_Address']);
            $("#pt_Name").val(data[8][0]['pt_Name']);
            $("#pt_Tel").val(data[8][0]['pt_Tel']);
            $("#pt_Need").val(data[8][0]['pt_Need']);
            $("#pt_State").val(data[8][0]['pt_State']);
        }
    });
}
function ptchangeok() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: { pt_Id: changeid, pt_Kind: $("#pt_Kind").val(), pt_Time: $("#pt_Time").val(), pt_Money: $("#pt_Money").val(), pt_Address: $("#pt_Address").val(), pt_Name: $("#pt_Name").val(), pt_Tel: $("#pt_Tel").val(), pt_Need: $("#pt_Need").val(), pt_State: $("#pt_State").val() },
        success: function (data) {
            data = eval('(' + data + ')');
            $("#kk").html(data[8]);
            $("#all").hide();
            $("#alert_amend").hide();
        }
    });
}
function ptAddok() {
    $.ajax({
        url: "../ajax/company_information.ashx",
        type: 'POST',
        data: { pt_addKind: $("#pt_addKind").val(), pt_addTime: $("#pt_addTime").val(), pt_addMoney: $("#pt_addMoney").val(), pt_addAddress: $("#pt_addAddress").val(), pt_addName: $("#pt_addName").val(), pt_addTel: $("#pt_addTel").val(), pt_addNeed: $("#pt_addNeed").val(), pt_addState: $("#pt_addState").val() },
        success: function (data) {
            data = eval('(' + data + ')');
            $("#kk").html(data[8]);
            $("#all").hide();
            $("#alert").hide();
        }
    });
}
function changepwd() {
    if ($(".password").val() == "" || $(".newpassword").val() == "" || $(".newpassword2").val() == "") {
        alert("无效输入值！请重新输入。");
    }
    else {
        if ($(".newpassword").val() != $(".newpassword2").val()) {
            alert("两次新密码不相同！请重新输入。")
        }
        else if ($.md5($.trim($(".password").val())) != e_pwd) {
            alert("密码错误！请重新输入。")
        }
        else {
            $.ajax({
                url: "../ajax/company_information.ashx",
                type: 'POST',
                data: { newEpwd: $.md5($.trim($('.newpassword').val())) },
                success: function (data) {
                    $("#all").hide();
                    $(".alert_changepwd").hide();
                    alert("修改成功！")
                }
            });
        }
    }
}
