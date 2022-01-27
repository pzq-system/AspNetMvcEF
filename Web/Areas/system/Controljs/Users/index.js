layui.use(["form", "layer", "laydate", "table", "laytpl"], function () {
    var form = layui.form,
        $ = layui.jquery,
        table = layui.table;

    var tableIns = table.render({
        elem: "#layerTables",
        url: "../../system/users",
        method: 'POST',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        toolbar: true,
        defaultToolbar: ["filter", "print", "exports"],
        limit: 10,
        limits: [10, 20, 30, 50, 100],
        id: "layerTables",
        cols: [
            [
                { title: "序号", fixed: "left", width: 80, type: "numbers", align: "center" },
                { field: "Useraccount", title: "帐号", align: "center" },
                { field: "UserName", title: "姓名", align: "center" },
                { field: "CreationTime", title: "入库时间", align: "center" },
                {
                    title: "操作",
                    width: 150,
                    fixed: "right",
                    align: "center",
                    templet: function () {
                        var buttons = "<div class=\"layui-btn-group\">";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs\" lay-event=\"edit\" " + mouseTips("编辑") + "> <i class=\"layui-icon layui-icon-edit\"></i></button>";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-normal\" lay-event=\"yhjs\" " + mouseTips("用户角色") + "><i class=\"layui-icon layui-icon-group\"></i></button>";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-warm\" lay-event=\"password\" " + mouseTips("重置密码") + "><i class=\"layui-icon layui-icon-key\"></i></button>";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-danger\" lay-event=\"del\" " + mouseTips("删除") + " ><i class=\"layui-icon layui-icon-delete\"></i></button>";
                        buttons += "</div>";
                        return buttons;
                    }
                }
            ]
        ]
    });

    $("#btnAdd").click(function () {
        addEdit();
    });

    //列表操作
    table.on("tool(layerTables)", function (obj) {
        var layEvent = obj.event,
            data = obj.data;
        if (layEvent === "edit") {
            addEdit(data);
        }
        if (layEvent === "del") {
            deleteData("Delete", { Id: data.Id }, function () { tableIns.reload(); });
        }
        if (layEvent === "password") {
            deleteData("../../ashx/xtgl/user.ashx?action=ResetPwd", { yhzh: data.YHZH }, null, "您确定要重置用户【" + data.YHZH + "】的密码为系统初始密码 ？");
        }
        if (layEvent === "yhjs") {
            layui.layer.open({
                title: "用户角色",
                type: 2,
                anim: 2,
                content: "user-role-set.aspx",
                area: ["70%", "100%"],
                success: function (layero, index3) {
                    var body = layui.layer.getChildFrame("body", index3);
                    body.find("#hdId").val(data.YHZH);
                    body.find("#hdJsbm").val(data.JSBM);
                    form.render();
                }
            });
        }
    });

    $("#btnSearch").on("click", function () {
        tableIns.reload(
            {
                page: {
                    curr: 1
                },
                where: {
                    filter: { UserName: $("#usersname").val() }
                }
            });
    });

    window.tools = {
        reloadTable: function () {
            tableIns.reload();
        }
    }

    //添加、编辑
    function addEdit(data) {
        layui.layer.open({
            title: data ? "编辑用户" : "添加用户",
            type: 2,
            anim: 2,
            content: "add",
            area: ["40%", "30%"],
            success: function (layero, index) {
                var body = layui.layer.getChildFrame("body", index);
                if (data) {
                    body.find("#Useraccount").val(data.Useraccount);
                    body.find("#Useraccount").attr("disabled", "disabled");
                    body.find("#Useraccount").addClass("layui-disabled");
                    body.find("#UserName").val(data.UserName);
                    body.find("#Id").val(data.Id);
                    form.render();
                }
                else {
                    form.render();
                }
            }
        });
    }
});
