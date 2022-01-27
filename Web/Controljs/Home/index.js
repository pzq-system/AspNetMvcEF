var $, tab, dataStr, layer;
layui.config({
    base: "controljs/sys/"
}).extend({
    "bodyTab": "bodyTab"
});

layui.use(["bodyTab", "form", "element", "layer", "jquery"], function () {
    var element = layui.element;
    $ = layui.$;
    layer = parent.layer === undefined ? layui.layer : top.layer;
    tab = layui.bodyTab({
        openTabNum: "15", //最大可打开窗口数量
        url: "ashx/index.ashx?action=getCdxx" //获取菜单json地址
    });
    if (parseInt($("#hdxzqhcd").val()) == 4) {
        $("#secif").attr("src", "user/index.aspx");
    } else if (parseInt($("#hdxzqhcd").val()) == 6) {
        $("#secif").attr("src", "user/index.aspx");
    } else {
        var username = $("#hdUser").val();
        $("#secif").attr("src", "user/index.aspx");
    }

    $.ajax({
        type: "post",
        dataType: "json",
        url: "ashx/index.ashx?action=getXtbm",

        success: function (data) {
            if (data.code === "0") {
                var text = "";
                $.each(data.data,
                    function (i, item) {
                        var isFirst = "";
                        if (i === 0) {
                            isFirst = "layui-this";
                            getData(item.XTBM);
                        }
                        text += "<li class=\"layui-nav-item " + isFirst + "\" data-menu=\"" + item.XTBM + "\">";
                        text += "<a href=\"javascript:;\"><cite>" + item.MC + "</cite></a>";
                        text += "</li>";
                    });
                $(".top_menu").html(text);
            }
        },
        error: function () {
            location.href = "error.html";
        }
    });

    //通过顶部菜单获取左侧二三级菜单
    function getData(xtbm) {
        $.ajax({
            type: "post",
            dataType: "json",
            url: tab.tabConfig.url + "&xtbm=" + xtbm,
            success: function (data) {
                if (data.code === "0") {
                    dataStr = data.data;
                    //重新渲染左侧菜单
                    tab.render();
                }
            },
            error: function () {
                //location.href = "error.html";
            }
        });
    }
    $("#btnPasseord").on("click", function () {
        layui.layer.open({
            skin: "layui-layer-rim",
            title: "修改密码",
            type: 2,
            anim: 2,
            content: "user/password.aspx",
            area: ["500px", "400px"]
        });
    });
    //通过顶部菜单获取左侧菜单
    $("#ulTopmenu").on("click", "li", function () {
        ValidateSession(0);

        $(".top_menu li").eq($(this).index()).addClass("layui-this").siblings().removeClass("layui-this");
        $(".layui-layout-admin").removeClass("showMenu");
        $("body").addClass("site-mobile");
        getData($(this).data("menu"));
        //渲染顶部窗口
        tab.tabMove();
    });

    //隐藏左侧导航
    $(".hideMenu").click(function () {
        if ($(".topLevelMenus li.layui-this a").data("url")) {
            layer.msg("此栏目状态下左侧菜单不可展开"); //主要为了避免左侧显示的内容与顶部菜单不匹配
            return;
        }
        $(".layui-layout-admin").toggleClass("showMenu");
        //渲染顶部窗口
        tab.tabMove();
    });

    //手机设备的简单适配
    $(".site-tree-mobile").on("click", function () {
        $("body").addClass("site-mobile");
    });
    $(".site-mobile-shade").on("click", function () {
        $("body").removeClass("site-mobile");
    });

    // 添加新窗口
    $("body").on("click", ".layui-nav .layui-nav-item a:not('.mobileTopLevelMenus .layui-nav-item a')", function () {
        //如果不存在子级
        if ($(this).siblings().length === 0) {
            addTab($(this));
            $("body").removeClass("site-mobile"); //移动端点击菜单关闭菜单层
        }
        $(this).parent("li").siblings().removeClass("layui-nav-itemed");
    });
    $("#watch").on("click",
        function () {
            //如果不存在子级
            if ($(this).siblings().length == 0) {
                addTab($(this));
                $('body').removeClass('site-mobile'); //移动端点击菜单关闭菜单层
            }
            $(this).parent("li").siblings().removeClass("layui-nav-itemed");
        });
    //清除缓存
    $(".clearCache").click(function () {
        window.sessionStorage.clear();
        window.localStorage.clear();
        var index = layer.msg("清除缓存中，请稍候", { icon: 16, time: false, shade: 0.8 });
        setTimeout(function () {
            layer.close(index);
            layer.msg("缓存清除成功");
        }, 1000);
    });

    //刷新后还原打开的窗口
    if (cacheStr) {
        if (window.sessionStorage.getItem("menu") != null) {
            var menu = JSON.parse(window.sessionStorage.getItem("menu"));
            var curmenu = window.sessionStorage.getItem("curmenu");
            var openTitle = "";
            for (var i = 0; i < menu.length; i++) {
                openTitle = "";
                if (menu[i].icon) {
                    if (menu[i].icon.split("-")[0] === "icon") {
                        openTitle += '<i class="seraph ' + menu[i].icon + '"></i>';
                    } else {
                        openTitle += '<i class="layui-icon">' + menu[i].icon + "</i>";
                    }
                }
                openTitle += "<cite>" + menu[i].title + "</cite>";
                openTitle += '<i class="layui-icon layui-unselect layui-tab-close" data-id="' + menu[i].layId + '">&#x1006;</i>';
                element.tabAdd("bodyTab",
                    {
                        title: openTitle,
                        content: "<iframe src='" + menu[i].href + "' data-id='" + menu[i].layId + "'></frame>",
                        id: menu[i].layId
                    });
                //定位到刷新前的窗口
                if (curmenu !== "undefined") {
                    if (curmenu === "" || curmenu === "null") { //定位到后台首页
                        element.tabChange("bodyTab", "");
                    } else if (JSON.parse(curmenu).title === menu[i].title) { //定位到刷新前的页面
                        element.tabChange("bodyTab", menu[i].layId);
                    }
                } else {
                    element.tabChange("bodyTab", menu[menu.length - 1].layId);
                }
            }
            //渲染顶部窗口
            tab.tabMove();
        }
    } else {
        window.sessionStorage.removeItem("menu");
        window.sessionStorage.removeItem("curmenu");
    }
});

//打开新窗口
function addTab(_this) {
    tab.tabAdd(_this);
}