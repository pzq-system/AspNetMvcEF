layui.use(["form", "layer", "laydate", "table", "laytpl"], function () {
    var form = layui.form,
        $ = layui.jquery,
        table = layui.table;

    $("#btnClose").on("click", function () {
        parent.layer.closeAll();
    });
    console.log($("#hdParentMenu").val());
    var tableIns = table.render({
        elem: "#layerTables",
        url: "GetMenu",
        method: 'POST',
        where: {
            filter: {
                ParentMenu: $("#hdParentMenu").val(),
            }
        },
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
                { title: "序号", fixed: "left", width: 60, type: "numbers", align: "center" },
                { field: "ParentMenuName", title: "上级菜单", align: "center" },
                { field: "MenuName", title: "菜单名称", align: "center" },
                {
                    field: "MenuAddress",
                    title: "菜单地址",
                    align: "center",
                    templet: function (d) {
                        return decodeURIComponent(d.MenuAddress);
                    }
                },
                { field: "Sorting", title: "菜单排序", align: "center" },
                {
                    field: "State",
                    title: "状态",
                    align: "center",
                    width: 110,
                    templet: function (d) {
                        var check = d.State === "1" ? "checked" : "";
                        return '<input type="checkbox" lay-filter="ZT" switch_Id="' + d.Id + '" lay-skin="switch" lay-text="正常|禁用" ' + check + " >";
                    }
                },
                {
                    title: "操作",
                    width: 100,
                    fixed: "right",
                    align: "center",
                    templet: function () {
                        var buttons = "<div class=\"layui-btn-group\">";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-normal \" lay-event=\"edit\" " + mouseTips("编辑") + " ><i class=\"layui-icon layui-icon-edit\"></i></button>";
                        buttons += "<button type=\"button\" class=\"layui-btn layui-btn-xs layui-btn-danger \" lay-event=\"del\" " + mouseTips("删除") + " ><i class=\"layui-icon layui-icon-delete\"></i></button>";
                        buttons += "</div>";
                        return buttons;
                    }
                }
            ]
        ]
    });

    //菜单状态
    form.on("switch(ZT)", function (obj) {
        //开关是否开启，true或者false
        var zt = obj.elem.checked ? "1" : "0";
        var id = obj.elem.attributes["switch_Id"].nodeValue;
        swtichZt("UpdateMenuZt", { Id: id, State: zt }, obj, form, function () { tableIns.reload(); });
    });

    //列表操作
    table.on("tool(layerTables)", function (obj) {
        var layEvent = obj.event,
            data = obj.data;
        if (layEvent === "edit") {
            addEdit(data);
        }
        if (layEvent === "del") {
            deleteData("DeleteMenu", { Id: data.Id }, function () { tableIns.reload(); });
        }
    });

    //添加、编辑
    function addEdit(data) {
        layui.layer.open({
            title: data ? "编辑菜单" : "添加菜单",
            type: 2,
            anim: 2,
            content: "MenuEdit",
            area: ["50%", "100%"],
            success: function (layero, index) {
                var body = layui.layer.getChildFrame("body", index);
                body.find("#hdSystemCoding").val($("#hdSystemCoding").val());
                body.find("#hdParentMenu").val($("#hdParentMenu").val());
                body.find("#MenuCategroy").val($("#hdParentMenu").val() + "-" + $("#hdParentMenuName").val());
                body.find("#MenuCategroy").attr("disabled", "disabled");
                body.find("#MenuCategroy").addClass("layui-disabled");
                body.find("#SystemCoding").attr("disabled", "disabled");
                body.find("#SystemCoding").addClass("layui-disabled");
                if (data) {
                    body.find("#hdId").val(data.Id);
                    body.find("#MenuName").val(data.MenuName);
                    body.find("#MenuAddress").val(decodeURIComponent(data.MenuAddress));
                    body.find("#Sorting").val(data.Sorting);
                    body.find("#Icon").val(data.Icon);
                    form.render();
                }

            }
        });
    }

    window.tools = {
        reloadTable: function () {
            tableIns.reload();
        }
    }

    $("#btnAdd").click(function () {
        addEdit();
    });

    $("#btnSearch").on("click", function () {
        tableIns.reload(
            {
                page: {
                    curr: 1
                },
                where: {
                    filter: {
                        MenuName: $("#MenuName").val()
                    }
                }
            });
    });
})