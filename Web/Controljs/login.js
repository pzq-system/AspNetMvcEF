$(function () {
    $("#btnLogin").click(function () {
        Login();
    });

    $(document).keyup(function (event) {
        if (event.keyCode === 13) {
            Login();
        }
    });

    $("#imgCode").click(function () {
        this.src = "/Login/VerificationCode?rd=" + Math.random();
    });
});

function Login() {
    if (!CheckData()) {
        return;
    }
    var index = 0;
    $.ajax({
        type: "post",
        dataType: "json",
        url: "/Login/Login",
        data: {
            Useraccount: $("#Useraccount").val().trim(),
            Password: $("#Password").val().trim(),
            VerifyCode: $("#VerifyCode").val().trim()
        },
        beforeSend: function () {
            index = layer.load(2);
        },
        success: function (res) {
            console.log(JSON.stringify(res));
            if (res.code == "0") {
                location.href = "/Home/Index";
            } else {
                if (res.code == "0020") {
                    if (res.data != null) {
                        if (res.data == "0030") {
                            $("#imgCode").trigger("click");
                            layer.alert(data.msg, { icon: 0 });
                            $("#VerifyCode").val("");
                            $("#VerifyCode").focus();
                        }
                    } else {
                        layer.alert(res.msg, { icon: 0 });
                    }
                }
            }
            //var yhzh = $("#txtUsername").val();
            //if (yhzh) yhzh = encodeURIComponent(yhzh.trim());
            //if (data.result === "0000") {
            //    location.href = "index.aspx";
            //} else if (data.code === "0030") {
            //    $("#imgCode").trigger("click");
            //    layer.alert(data.msg, { icon: 0 });
            //    $("#txtCode").val("");
            //    $("#txtCode").focus();
            //} else if (data.code === "0040") {
            //    //检测到该帐号为默认密码必须修改密码之后才能继续操作
            //    $("#txtPassword").val("");
            //    layer.alert(data.msg,
            //        { icon: 0, closeBtn: 0 },
            //        function () {
            //            layer.closeAll();
            //            layer.open({
            //                type: 2,
            //                title: "修改初始密码",
            //                closeBtn: 1,
            //                shadeClose: false,
            //                shade: 0.4,
            //                skin: "layui-layer-rim",
            //                area: ["500px", "400px"],
            //                content: "user/password.aspx?yhzh=" + yhzh,
            //                scrollbar: false
            //            });
            //        });
            //} else if (data.code === "0050") { //密码到期天数提示
            //    $("#txtPassword").val("");
            //    layer.alert(data.msg,
            //        { icon: 0, closeBtn: 0 },
            //        function () {
            //            location.href = "index.aspx";
            //        });
            //} else if (data.code === "0060") { //密码过期请修改密码
            //    $("#txtPassword").val("");
            //    layer.alert(data.msg,
            //        { icon: 0, closeBtn: 0 },
            //        function () {
            //            layer.closeAll();
            //            layer.open({
            //                type: 2,
            //                title: "修改密码",
            //                closeBtn: 1,
            //                shadeClose: false,
            //                shade: 0.4,
            //                skin: "layui-layer-rim",
            //                area: ["500px", "400px"],
            //                content: "user/password.aspx?yhzh=" + yhzh,
            //                scrollbar: false
            //            });
            //        });
            //}
            //else {
            //    layer.alert(data.msg, { icon: 0 });
            //}
        },
        complete: function () {
            layer.close(index);
        },
        error: function () {
            layer.alert("登录时发生异常，请重试！", { icon: 2 });
        }
    });
}

function CheckBrowser() {
    if (!$.support.leadingWhitespace) {
        location.href = "user/browser.aspx";
    } else {
        //判断是否ie，且版本应该是10或以上
        var ie = IETester();
        if (ie) {
            if (parseFloat(ie) < 10) {
                location.href = "user/browser.aspx";
            }
        }
    }
}

function IETester() {
    var UA = navigator.userAgent;
    if (/msie/i.test(UA)) {
        return UA.match(/msie (\d+\.\d+)/i)[1];
    } else if (~UA.toLowerCase().indexOf("trident") && ~UA.indexOf("rv")) {
        return UA.match(/rv:(\d+\.\d+)/)[1];
    }
    return false;
}

function CheckData() {
    var useraccount = $("#Useraccount").val().trim();
    var password = $("#Password").val().trim();
    var code = $("#VerifyCode").val().trim();
    if (useraccount.length === 0) {
        layer.msg("请输入登录帐号", {
            time: TwTime,
            anim: Anim
        }, function () {
            $("#Useraccount").focus();
        });
        return false;
    }
    if (password.length === 0) {
        layer.msg("请输入登录密码", {
            time: TwTime,
            anim: Anim
        }, function () {
            $("#Password").focus();
        });
        return false;
    }
    if (code.length === 0) {
        layer.msg("请输入验证码", {
            time: TwTime,
            anim: Anim
        }, function () {
            $("#VerifyCode").focus();
        });
        return false;
    }

    if (code.length !== 4) {
        layer.msg("验证码长度错误", {
            time: TwTime,
            anim: Anim
        }, function () {
            $("#VerifyCode").focus();
        });
        return false;
    }
    return true;
}