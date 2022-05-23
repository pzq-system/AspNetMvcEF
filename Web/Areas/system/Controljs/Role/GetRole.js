layui.use(["form", "layer", "laydate", "table", "laytpl"], function () {
    var form = layui.form,
        $ = layui.jquery,
        table = layui.table;

    getXtbm($("#SystemCoding"));

    var tableIns = table.render({
        elem: "#layerTables",
        url: "GetRole",
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
                { field: "CodingName", title: "系统名称", align: "center" },
                { field: "RoleName", title: "角色名称", align: "center" },
                { field: "CreationTime", title: "更新时间", align: "center" },
                {
                    title: "操作",
                    width: 100,
                    fixed: "right",
                    align: "center",
                    templet: function () {
                        var buttons = "<div class=\"layui-btn-group\">";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-normal\" lay-event=\"edit\" " + mouseTips("编辑") + "><i class=\"layui-icon layui-icon-edit\"></i></button>";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-danger\" lay-event=\"del\" " + mouseTips("删除") + "><i class=\"layui-icon layui-icon-delete\"></i></button>";
                        buttons += "</div>";
                        return buttons;
                    }
                }
            ]
        ]
    });

    //列表操作
    table.on("tool(layerTables)", function (obj) {
        var layEvent = obj.event,
            data = obj.data;
        console.log(data.ROLE_ID);
        if (layEvent === "edit") {
            addEdit(data);
        }
        if (layEvent === "del") {
            deleteData("RoleDelete", { RoleId: data.RoleId }, function () { tableIns.reload(); });
        }
    });

    $("#btnSearch").on("click", function () {
        tableIns.reload(
            {
                page: {
                    curr: 1
                },
                where: {
                    filter: {
                        SystemCoding: $("#SystemCoding").val()
                    }
                }
            });
    });

    //添加、编辑
    function addEdit(data) {
        layui.layer.open({
            title: data ? "编辑角色" : "添加角色",
            type: 2,
            anim: 2,
            content: "RoleEdit",
            area: ["40%", "80%"],
            success: function (layero, index) {
                var body = layui.layer.getChildFrame("body", index);
                if (data) {
                    body.find("#hdSystemCoding").val(data.SystemCoding);
                    body.find("#hdRoleId").val(data.RoleId);
                    body.find("#hdMenuIds").val(data.MenuIds);
                    body.find("#RoleName").val(data.RoleName);
                    form.render();
                }
            }
        });
    }

    $("#btnAdd").click(function () {
        addEdit();
    });

    window.tools = {
        reloadTable: function () {
            tableIns.reload();
        }
    }
})