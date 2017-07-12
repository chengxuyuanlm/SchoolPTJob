/* 
* @Author: anchen
* @Date:   2016-11-13 15:04:54
* @Last Modified by:   anchen
* @Last Modified time: 2016-11-15 00:07:04
*/

$(document).ready(function(){
    $("#page_number td:nth-child(2)").click(function(){
        $(this).addClass('bgcolor')
        $(this).siblings('td').removeClass('bgcolor')
    })
    $("#page_number td:nth-child(3)").click(function(){
        $(this).addClass('bgcolor')
        $(this).siblings('td').removeClass('bgcolor')
    })
    $("#page_number td:nth-child(4)").click(function(){
        var aa='···';
        var bb = 4 ;
        var cc= 47 ;
        if($(this).prev().text() != aa && $(this).text() != bb && $("#page_number td:nth-child(5)").text()!=cc)
        {
        $(this).addClass('bgcolor')
        $(this).siblings('td').removeClass('bgcolor')
        }
        else if($(this).prev().text() == aa && $(this).text() != bb && $("#page_number td:nth-child(5)").text()!=cc)
        {
            var i = $("#page_number td:nth-child(4)").text();
            i--; 
            var j = $("#page_number td:nth-child(5)").text();
            j--;
            var k = $("#page_number td:nth-child(6)").text();
            k--;
            $("#page_number td:nth-child(4)").text(i)
            $("#page_number td:nth-child(5)").text(j)
            $("#page_number td:nth-child(6)").text(k)
            $(this).next().addClass('bgcolor')
            $(this).next().siblings('td').removeClass('bgcolor')
        }
        else if($("#page_number td:nth-child(5)").text()==cc)
        {
            var i = $("#page_number td:nth-child(4)").text();
            i--; 
            var j = $("#page_number td:nth-child(5)").text();
            j--;
            var k = $("#page_number td:nth-child(6)").text();
            k--;
            $("#page_number td:nth-child(7)").text('···')
            $("#page_number td:nth-child(4)").text(i)
            $("#page_number td:nth-child(5)").text(j)
            $("#page_number td:nth-child(6)").text(k)
            $(this).next().addClass('bgcolor')
            $(this).next().siblings('td').removeClass('bgcolor')
        }
        else
        {
            $("#page_number td:nth-child(3)").text('2')
            $("#page_number td:nth-child(4)").text('3')
            $("#page_number td:nth-child(5)").text('4')
            $("#page_number td:nth-child(6)").text('5')
            $(this).next().addClass('bgcolor')
            $(this).next().siblings('td').removeClass('bgcolor')
        }
    })
    $("#page_number td:nth-child(5)").click(function(){
        
            $(this).addClass('bgcolor')
            $(this).siblings('td').removeClass('bgcolor') 
    })
    $("#page_number td:nth-child(6)").click(function(){
        var aa= 48;
        if($("#page_number td:nth-child(6)").text()<aa)
        {
            var i = $("#page_number td:nth-child(4)").text();
            i++; 
            var j = $("#page_number td:nth-child(5)").text();
            j++;
            var k = $("#page_number td:nth-child(6)").text();
            k++;
            $("#page_number td:nth-child(3)").text('···')
            $("#page_number td:nth-child(4)").text(i)
            $("#page_number td:nth-child(5)").text(j)
            $(this).text(k)
            $(this).prev().addClass('bgcolor')
            $(this).prev().siblings('td').removeClass('bgcolor')
        }
        else if($("#page_number td:nth-child(6)").text()==aa)
        {
            $("#page_number td:nth-child(7)").text('49')
            $(this).addClass('bgcolor')
            $(this).siblings('td').removeClass('bgcolor')
        }
    })
    $("#page_number td:nth-child(7)").click(function(){
        $(this).addClass('bgcolor')
        $(this).siblings('td').removeClass('bgcolor')
    })
    $("#page_number td:nth-child(8)").click(function(){
        $(this).addClass('bgcolor')
        $(this).siblings('td').removeClass('bgcolor')
    })
    $("#page_number td:nth-child(1)").click(function(){
        var aa='···';
        var bb=4;
        var cc= 47;
        if($("#page_number td:nth-child(3)").text() == aa && $("#page_number td:nth-child(4)").text()!=bb && $("#page_number td:nth-child(5)").text() < cc && $("#page_number td:nth-child(7)").text()==aa)
        {
            var i = $("#page_number td:nth-child(4)").text();
            i--; 
            var j = $("#page_number td:nth-child(5)").text();
            j--;
            var k = $("#page_number td:nth-child(6)").text();
            k--;
            $("#page_number td:nth-child(4)").text(i)
            $("#page_number td:nth-child(5)").text(j)
            $("#page_number td:nth-child(6)").text(k)
            $("#page_number td:nth-child(5)").addClass('bgcolor')
            $("#page_number td:nth-child(5)").siblings('td').removeClass('bgcolor')
        }
        else if($("#page_number td:nth-child(4)").text()==bb)
        {
            $("#page_number td:nth-child(3)").text('2')
            $("#page_number td:nth-child(4)").text('3')
            $("#page_number td:nth-child(5)").text('4')
            $("#page_number td:nth-child(6)").text('5')
            $("#page_number td:nth-child(5)").addClass('bgcolor')
            $("#page_number td:nth-child(5)").siblings('td').removeClass('bgcolor')
        }
        else if($("#page_number td:nth-child(5)").text() == cc)
        {
            var i = $("#page_number td:nth-child(4)").text();
             
            var j = $("#page_number td:nth-child(5)").text();
            
            var k = $("#page_number td:nth-child(6)").text();
            
            $("#page_number td:nth-child(4)").text(i)
            $("#page_number td:nth-child(5)").text(j)
            $("#page_number td:nth-child(6)").text(k)
            $("#page_number td:nth-child(7)").text(aa)
            $("#page_number td:nth-child(5)").addClass('bgcolor')
            $("#page_number td:nth-child(5)").siblings('td').removeClass('bgcolor')
        }
    })

    $("#page_number td:nth-child(9)").click(function(){
        var aa='···';
        var bb=48;
        var cc=5;
        if($("#page_number td:nth-child(7)").text() == aa && $("#page_number td:nth-child(6)").text()!=bb && $("#page_number td:nth-child(5)").text()>=cc)
        {
            var i = $("#page_number td:nth-child(4)").text();
            i++; 
            var j = $("#page_number td:nth-child(5)").text();
            j++;
            var k = $("#page_number td:nth-child(6)").text();
            k++;
            $("#page_number td:nth-child(3)").text('···')
            $("#page_number td:nth-child(4)").text(i)
            $("#page_number td:nth-child(5)").text(j)
            $("#page_number td:nth-child(6)").text(k)
            $("#page_number td:nth-child(5)").addClass('bgcolor')
            $("#page_number td:nth-child(5)").siblings('td').removeClass('bgcolor')
        }
        else if($("#page_number td:nth-child(6)").text()==bb)
        {
            $("#page_number td:nth-child(7)").text('49')
            $("#page_number td:nth-child(6)").text('48')
            $("#page_number td:nth-child(5)").text('47')
            $("#page_number td:nth-child(5)").addClass('bgcolor')
            $("#page_number td:nth-child(5)").siblings('td').removeClass('bgcolor')
        }
    })
    $("#page_number td:nth-child(2)").click(function(){
            $("#page_number td:nth-child(3)").text('2')
            $("#page_number td:nth-child(4)").text('3')
            $("#page_number td:nth-child(5)").text('4')
            $("#page_number td:nth-child(6)").text('5')
            $("#page_number td:nth-child(7)").text('···')
            $("#page_number td:nth-child(2)").addClass('bgcolor')
            $("#page_number td:nth-child(2)").siblings('td').removeClass('bgcolor')
    })
    $("#page_number td:nth-child(8)").click(function(){
            $("#page_number td:nth-child(3)").text('···')
            $("#page_number td:nth-child(4)").text('46')
            $("#page_number td:nth-child(5)").text('47')
            $("#page_number td:nth-child(6)").text('48')
            $("#page_number td:nth-child(7)").text('49')
            $("#page_number td:nth-child(8)").addClass('bgcolor')
            $("#page_number td:nth-child(8)").siblings('td').removeClass('bgcolor')
    })


    $("#alert_bottom").children('input').click(function () {
        $("#all").hide();
        $("#alert").hide();
        updateJson = {};
        var comName = $("input[name=comName]").val();
        var RealName = $("input[name=RealName]").val();
        var Address = $("input[name=Address]").val();
        var comPhone = $("input[name=comPhone]").val();
        updateJson["user"] = json['user'];
        updateJson["userId"] = json['userId'];
        updateJson["page"] = json['page'];
        updateJson["comName"] = comName;
        updateJson["RealName"] = RealName;
        updateJson["Address"] = Address;
        updateJson["comPhone"] = comPhone;
        $.post("../ajax/admin.ashx", updateJson, function (data) {
            data = eval('(' + data + ')');
            if (data[1] % 5 == 0 && json['page'] == Math.floor(data[1] / 5))//删完最后一页跳到前一页  因为前一页变成最后一页
                json['page'] = json['page'] = Math.floor(data[1] / 5);
            if (json['page'] == 0)
                json['page'] = 1;
            getAjax('page', json['page']);
            var options = {
                totalNum: data[1],//总数据条数
                totalPage: Math.ceil(data[1] / 5),//总页数
                showPageNum: 5//最多显示多少页数
            };
            $('#pageBox').pageing(options);
            var width = $('#pageBox').width()
            var marginRight = (880 - width) / 2 + 'px';
            $('#pageBox').css('margin-right', marginRight);
            $("#pageMain .page a").removeClass('active');
            $("#pageMain .page").eq(json['page'] - 1).find('a').addClass('active');
        });
    });
    $("#kuang").click(function(){
        $("#all").hide();
        $("#alert").hide();
    })
     $("#alert_bottom2").children('input').click(function(){
        $("#all").hide();
        $("#alert2").hide();
        updateJson = {};
        var stuName = $("input[name=stuName]").val();
        var Professional = $("input[name=Professional]").val();
        var school = $("input[name=school]").val();
        var Phone = $("input[name=Phone]").val();
        updateJson["user"] = json['user'];
        updateJson["userId"] = json['userId'];
        updateJson["page"] = json['page'];
        updateJson["stuName"] = stuName;
        updateJson["Professional"] = Professional;
        updateJson["school"] = school;
        updateJson["Phone"] = Phone;
        $.post("../ajax/admin.ashx", updateJson, function (data) {
            data = eval('(' + data + ')');
            if (data[1] % 5 == 0 && json['page'] == Math.floor(data[1] / 5))//删完最后一页跳到前一页  因为前一页变成最后一页
                json['page'] = json['page'] = Math.floor(data[1] / 5);
            if (json['page'] == 0)
                json['page'] = 1;
            getAjax('page', json['page']);
            var options = {
                totalNum: data[1],//总数据条数
                totalPage: Math.ceil(data[1] / 5),//总页数
                showPageNum: 5//最多显示多少页数
            };
            $('#pageBox').pageing(options);
            var width = $('#pageBox').width()
            var marginRight = (880 - width) / 2 + 'px';
            $('#pageBox').css('margin-right', marginRight);
            $("#pageMain .page a").removeClass('active');
            $("#pageMain .page").eq(json['page'] - 1).find('a').addClass('active');
        });

    })
     $(".admin_change2").click(function () {
         $("#all").show();
         $("#alert2").show();
     });
    $("#admin_R_com").click(function(){
        $(this).addClass('admin_R_com');
        $("#admin_R_stu").removeClass('admin_R_stu');
        $("#admin_L_down_2_tab2").hide();
        $("#admin_L_down_2_tab1").show();
        $("#admin_L_down_1").show();
        $("#admin_L_down_1_1").hide();
        json = {};
        json['user'] = 'com';
        json['page'] = 1;
        getData();
    })
    $("#admin_R_stu").click(function () {
        $(this).addClass('admin_R_stu');
        $("#admin_R_com").removeClass('admin_R_com');
        $("#admin_L_down_2_tab2").show();
        $("#admin_L_down_2_tab1").hide();
        $("#admin_L_down_1").hide();
        $("#admin_L_down_1_1").show();
        json = {};
        json['user'] = 'stu';
        json['page'] = 1;
        getData();

    });
    $("#admin_search_stu_img").click(function () {
        var search = $("#admin_search_stu").val();
        json['user'] = 'stu';
        json['search'] = search;
        getData();
    });
    $("#admin_search_com_img").click(function () {
        var search = $("#admin_search_com").val();
        json['user'] = 'com';
        json['search'] = search;
        getData();
    });
    getData();
   
});
var json = {};
var updateJson = {};
json['user'] = 'stu';
function getData() {
    json['page'] = 1;
    $(document).ajaxStart(function () {
        $("#admin_L_down_2_tab1").html("");
        $("#admin_L_down_2_tab2").html("");
        $("#loading").show();
    });
    $.ajax({
        url: "../ajax/admin.ashx",
        type: 'get',
        data: json,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        timeout: 10000,
        success: function (data) {
            data = eval('(' + data + ')');
            $(document).ajaxStop(function () {
                $("#loading").hide();
                if (json['user'] == 'stu')
                    setData(data[0]);
                else
                    setData2(data[0]);
            });
            var options = {
                totalNum: data[1],//总数据条数
                totalPage: Math.ceil(data[1] / 5),//总页数
                showPageNum: 5//最多显示多少页数
            };
            $('#pageBox').pageing(options);
            var width = $('#pageBox').width()
            var marginRight = (880 - width) / 2 + 'px';
            $('#pageBox').css('margin-right', marginRight);
        }
    });
}
function getAjax(item, index)//发送get请求获取数据 用于分页查询
{
    json[item] = index;
    $(document).ajaxStart(function () {
        $("#admin_L_down_2_tab1").html("");
        $("#admin_L_down_2_tab2").html("");
        $("#loading").show();
    });
    $.ajax({
        url: "../ajax/admin.ashx",
        type: 'get',
        data: json,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        timeout: 10000,
        success: function (data) {
            data = eval('(' + data + ')');
            $(document).ajaxStop(function () {
                $("#loading").hide();
                if (json['user'] == 'stu')
                    setData(data[0]);
                else
                    setData2(data[0]);
            });
        }
    });

}
function setData(data) {//将获取的数据展示出来
    $("#admin_L_down_2_tab2").html("");
    var str = "<tr><td>序号</td><td>姓名</td><td>专业</td><td>学校</td><td>学历</td><td>操作</td></tr>";
    if (data.length > 0) {
        for (var i = 0 ; i < data.length; i++) {
            str += "<tr><td>" + data[i]['s_id'] + "</td><td>" + data[i]['s_UserName'] + "</td><td>" + data[i]['s_Professional'] + "</td><td>" + data[i]['s_Department'] + "</td><td>" + data[i]['s_Phone'] + "</td><td><img idNum=" + data[i]['s_id'] + " user='stu' src='../image/change.png' class='admin_change2' /><img user='stu' src='../image/delete.png' idNum=" + data[i]['s_id'] + " class='admin_delete' /></td></tr>";
        }
        $("#admin_L_down_2_tab2").html(str);
    }
    $(".admin_change2").click(function () {
        $("#all").show();
        $("#alert2").show();
        var user = $(this).attr("user");
        var userId = $(this).attr("idNum");
        json['user'] = user;
        json['userId'] = userId;
        delete json["type"];
    });
    $('.admin_delete').click(function () {
        del(this);
    });
}
function setData2(data) {//将获取的数据展示出来
    $("#admin_L_down_2_tab1").html("");
    var str = "<tr><td>序号</td><td>登录名称</td><td>公司名称</td><td>公司所有制</td><td>所属行业</td><td>操作</td></tr>";
    if (data.length > 0) {
        for (var i = 0 ; i < data.length; i++) {
            str += "<tr><td>" + data[i]['e_Id'] + "</td><td>" + data[i]['e_Name'] + "</td><td>" + data[i]['e_RealName'] + "</td><td>" + data[i]['e_Address'] + "</td><td>" + data[i]['e_Phone'] + "</td><td><img idNum=" + data[i]['e_Id'] + " user='com' src='../image/change.png' class='admin_change' /><img user='com' src='../image/delete.png' idNum=" + data[i]['e_Id'] + " class='admin_delete2' /></td></tr>";
        }
        $("#admin_L_down_2_tab1").html(str);
    }
    $(".admin_change").click(function () {
        $("#all").show();
        $("#alert").show();
        var user = $(this).attr("user");
        var userId = $(this).attr("idNum");
        json['user'] = user;
        json['userId'] = userId;
        delete json["type"];
    });
    $('.admin_delete2').click(function () {
        del(this);
    });
}
function del(obj)
{
    var user = $(obj).attr("user");
    var userId = $(obj).attr("idNum");
    json['user'] = user;
    json['userId'] = userId;
    json['type'] = 'del';
    $.post("../ajax/admin.ashx", json, function (data) {
        data = eval('(' + data + ')');
        if (data[1] % 5 == 0 && json['page'] == Math.floor(data[1] / 5))//删完最后一页跳到前一页  因为前一页变成最后一页
            json['page'] = json['page'] = Math.floor(data[1] / 5);
        if (json['page'] == 0)
            json['page'] = 1;
        getAjax('page', json['page']);
        var options = {
            totalNum: data[1],//总数据条数
            totalPage: Math.ceil(data[1] / 5),//总页数
            showPageNum: 5//最多显示多少页数
        };
        $('#pageBox').pageing(options);
        var width = $('#pageBox').width()
        var marginRight = (880 - width) / 2 + 'px';
        $('#pageBox').css('margin-right', marginRight);
        $("#pageMain .page a").removeClass('active');
        $("#pageMain .page").eq(json['page'] - 1).find('a').addClass('active');
    });
}