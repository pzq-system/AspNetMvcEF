layui.use(["form", "layer", "laydate", "table", "laytpl"], function () {
    var form = layui.form,
        $ = layui.jquery,
        table = layui.table;

    getXtbm($("#SystemCoding"));

    var tableIns = table.render({
        elem: "#layerTables",
        url: "GetMenuCategroy",
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
                { field: "MenuName", title: "菜单类别", align: "center" },
                { field: "CodingName", title: "系统名称", align: "center" },
                { field: "Icon", title: "菜单图标", align: "center" },
                { field: "Sorting", title: "排序号", align: "center" },
                {
                    title: "操作",
                    width: 150,
                    fixed: "right",
                    align: "center",
                    templet: function () {
                        var buttons = "<div class=\"layui-btn-group\">";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-normal \" lay-event=\"edit\" " + mouseTips("编辑") + "><i class=\"layui-icon layui-icon-edit\"></i></button>";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs\" lay-event=\"cdxx\" ley-event=\"cdxx\" " + mouseTips("菜单信息") + "><i class=\"layui-icon layui-icon-table\"></i></button>";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-danger \" lay-event=\"del\" " + mouseTips("删除") + "><i class=\"layui-icon layui-icon-delete\"></i></button>";
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
        if (layEvent === "cdxx") {
            layui.layer.open({
                title: "菜单信息",
                maxmin: true,
                type: 2,
                anim: 2,
                content: "GetMenu",
                area: ["80%", "100%"],
                success: function (layero, index1) {
                    var body = layui.layer.getChildFrame("body", index1);
                    body.find("#hdSystemCoding").val(data.SystemCoding);
                    body.find("#hdParentMenu").val(data.Id);
                    body.find("#hdParentMenuName").val(data.MenuName);
                    form.render();
                }
            });
        }
        if (layEvent === "del") {
            deleteData("DeleteMenuCategroy", { Id: data.Id }, function () { tableIns.reload(); });
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
                        SystemCoding: $("#SystemCoding").val(),
                        MenuName: $("#MenuName").val()
                    }
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
            title: data ? "编辑菜单类别" : "添加菜单类别",
            type: 2,
            anim: 2,
            content: "MenuCategroyEdit",
            area: ["50%", "100%"],
            success: function (layero, index) {
                var body = layui.layer.getChildFrame("body", index);
                if (data) {
                    body.find("#hdId").val(data.Id);
                    body.find("#MenuName").val(data.MenuName);
                    body.find("#Sorting").val(data.Sorting);
                    body.find("#Icon").val(data.Icon);
                    body.find("#hdSystemCoding").val(data.SystemCoding);
                    body.find("#SystemCoding").attr("disabled", "disabled");
                    body.find("#SystemCoding").addClass("layui-disabled");
                    form.render();
                }
            }
        });
    }
});