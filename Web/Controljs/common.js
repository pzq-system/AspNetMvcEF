//layer全局变量
var TwTime = 1500;
var LayerSkin = "layui-layer-rim";
var Anim = 6;


function dictBinds(obj, action, val) {
    layui.jquery.ajax({
        type: "post",
        dataType: "json",
        url: "../../ashx/dropdown.ashx?action=" + action,
        success: function (data) {
            layui.each(data.data, function (i, item) {
                if (item.BM === val) {
                    obj.append("<option value='" + item.BM + "' selected>" + item.BM + '-' + item.MC + "</option>");
                } else {
                    obj.append("<option value='" + item.BM + "'>" + item.BM + '-' + item.MC + "</option>");
                }
            });
            layui.form.render("select");
        }
    });
}

//小提示层
var mouseTips = function (str) {
    return "onmouseenter =\"layer.tips('" + str + "',this, {tips: 1});\" onmouseleave=\"layer.close(layer.tips())\"";
}

//获取系统编码
var getXtbm = function (obj, val) {
    layui.jquery.ajax({
        type: "post",
        dataType: "json",
        url: "../../system/Menu/GetSystemList",
        success: function (data) {
            layui.each(data.data, function (i, item) {
                var text = item.Value;
                if (item.Key === val) {
                    obj.append("<option value='" + item.Key + "' selected>" + item.Value + "</option>");
                } else {
                    obj.append("<option value='" + item.Key + "'>" + item.Value + "</option>");
                }
            });
            layui.form.render("select");
        }
    });
}

//获取数据字典
var getDict = function (xtbm, lx, obj, val, notFullText) {
    layui.jquery.ajax({
        type: "post",
        dataType: "json",
        data: {
            xtbm: xtbm,
            lx: lx
        },
        url: "../../ashx/sms/setting.ashx?action=GetDict",
        success: function (data) {
            layui.each(data.data, function (i, item) {
                var text = item.BM + "-" + item.MC;
                if (typeof (notFullText) === typeof (true)) text = item.MC;
                if (item.BM === val) {
                    obj.append("<option value='" + item.BM + "' selected>" + text + "</option>");
                } else {
                    obj.append("<option value='" + item.BM + "'>" + text + "</option>");
                }
            });
            layui.form.render("select");
        }
    });
}

//删除操作
var deleteData = function (url, data, callback, text) {
    var index = 0;
    layer.confirm(text || "确定删除选中记录？", { icon: 3, title: "确认" }, function () {
        layui.jquery.ajax({
            type: "post",
            dataType: "json",
            data: data,
            url: url,
            beforeSend: function () {
                index = layer.load(2);
            },
            success: function (result) {
                console.log(JSON.stringify(result));
                if (result.code === "0") {
                    layer.msg("数据操作成功", { time: 1500, icon: 1 }, callback);
                } else {
                    layer.alert(result.msg, { icon: 0 });
                }
            },
            complete: function () {
                layer.close(index);
            },
            error: function () {
                layer.alert("数据操作异常，请重试！", { icon: 2 });
            }
        });
    });
}

//编辑操作
var editData = function (url, data, obj, callback) {
    var index = 0;
    layui.jquery.ajax({
        type: "post",
        dataType: "json",
        data: data,
        url: url,
        beforeSend: function () {
            if (obj) {
                obj.attr({ disabled: "disabled" });
            }
            index = layer.load(2);
        },
        success: function (result) {
            if (result.code === "0") {
                layer.msg("数据操作成功", { time: 1500, icon: 1 }, callback);
            } else if (result.code == "0060") {
                location.href = "../login/Index";
            }
            else {
                layer.alert(result.msg, { icon: 0 }, function (index2) {
                    layer.close(index2);

                    if (obj) {
                        obj.removeAttr("disabled");
                    }
                });
            }
        },
        complete: function () {
            layer.close(index);
        },
        error: function () {
            layer.alert("数据操作异常，请重试！", { icon: 2 }, function (index2) {
                layer.close(index2);

                if (obj) {
                    obj.removeAttr("disabled");
                }
            });
        }
    });
}

//状态操作
var swtichZt = function (url, data, obj, obj_form, callback) {
    var index = 0;
    layui.jquery.ajax({
        type: "post",
        dataType: "json",
        data: data,
        url: url,
        beforeSend: function () {
            index = layer.load(2);
        },
        success: function (result) {
            if (result.code === "0") {
                layer.msg("数据操作成功", { time: 1500, icon: 1 }, callback);
            } else {
                layer.alert(result.msg, { icon: 0 }, function (idx) {
                    layer.close(idx);
                    obj.elem.checked = !obj.elem.checked;//修改switch开关
                    obj_form.render();
                });
            }
        },
        complete: function () {
            layer.close(index);
        },
        error: function () {
            layer.alert("数据操作异常，请重试！", { icon: 2 }, function (idx) {
                layer.close(idx);
                obj.elem.checked = !obj.elem.checked;//修改switch开关
                obj_form.render();
            });
        }
    });
}

function isValidIP(ip) {
    var reg = /^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$/;
    return reg.test(ip);
}

function isValidMAC(mac) {
    var reg = /[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}-[A-Fa-f0-9]{2}/;
    return reg.test(mac);
}

/**
* [通过参数名获取url中的参数值]
* 示例URL:http://htmlJsTest/getrequest.html?uid=admin&rid=1&fid=2&name=小明
* @param  {[string]} queryName [参数名]
* @return {[string]}           [参数值]
*/
function GetQueryValue(queryName) {
    var query = decodeURI(window.location.search.substring(1));
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == queryName) {
            return pair[1];
        }
    }
    return "";
}

/** *对Date的扩展，将 Date 转化为指定格式的String *月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q)
 * 可以用 1-2 个占位符， *年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
 * *例子： *(new Date()).Format("yyyy-MM-dd hh:mm:ss.S")
 * ==> 2006-07-02 08:09:04.423 *(new Date()).Format("yyyy-M-d h:m:s.S")  
 *     ==> 2006-7-2 8:9:4.18 
 */
Date.prototype.format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1,                 //月份
        "d+": this.getDate(),                    //日
        "h+": this.getHours(),                   //小时
        "m+": this.getMinutes(),                 //分
        "s+": this.getSeconds(),                 //秒
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度
        "S": this.getMilliseconds()             //毫秒
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt;
}

function strIsnull(s) {
    var str = s;
    if (s === "" || s === null || s === "null" || s === undefined || s === "undefined") {
        str = "-";
    }
    return str;
}

function strIsEmpty(s) {
    if (s === "" || s === null || s === "null" || s === undefined || s === "undefined") {
        return true;
    }
    return false;
}

function getDateArray(date) {//获取时间数组
    var darray = {};
    darray.year = date.year;
    darray.month = date.month - 1;
    var day = date.date;
    if (date.hours == 23 && date.minutes == 59 && date.seconds == 59) {
        day = day + 1;
    } else {
        darray.hours = date.hours;
        darray.minutes = date.minutes;
        darray.seconds = date.seconds;
    }
    darray.date = day;
    return darray;
}

function getRecentDay(day) {
    var today = new Date();
    var targetday_milliseconds = today.getTime() + 1000 * 60 * 60 * 24 * day;
    today.setTime(targetday_milliseconds);
    var tYear = today.getFullYear();
    var tMonth = today.getMonth();
    var tDate = today.getDate();
    tMonth = doHandleMonth(tMonth + 1);
    tDate = doHandleMonth(tDate);
    return tYear + "-" + tMonth + "-" + tDate;
}

function getRecentFullDay(day) {
    var today = new Date();
    var targetday_milliseconds = today.getTime() + 1000 * 60 * 60 * 24 * day;
    today.setTime(targetday_milliseconds);
    var tYear = today.getFullYear();
    var tMonth = today.getMonth();
    var tDate = today.getDate();
    tMonth = doHandleMonth(tMonth + 1);
    tDate = doHandleMonth(tDate);

    var tHour = today.getHours();
    var tMinutes = today.getMinutes();
    var tSeconds = today.getSeconds();
    tHour = doHandleMonth(tHour);
    tMinutes = doHandleMonth(tMinutes);
    tSeconds = doHandleMonth(tSeconds);

    return tYear + "-" + tMonth + "-" + tDate + " " + tHour + ":" + tMinutes + ":" + tSeconds;
}

function doHandleMonth(month) {
    var m = month;
    if (month.toString().length == 1) {
        m = "0" + month;
    }
    return m;
}
