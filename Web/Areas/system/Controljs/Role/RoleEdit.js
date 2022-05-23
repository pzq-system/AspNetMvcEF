window.onload = function () {
    layui.use(["form", "tree", "layer"], function () {
        var form = layui.form, //只有执行了这一步，部分表单元素才会自动修饰成功
            $ = layui.jquery,
            tree = layui.tree;
        //渲染
        tree.render({
            elem: "#treeMenu", //绑定元素
            showCheckbox: true,
            id: "treeMenu"
        });
        function getCdxx(systemcoding,roles) {
            var index = layer.msg("正在加载数据...", { icon: 16, shade: 0.5 });
            $.ajax({
                type: "post",
                dataType: "json",
                url: "GetMenu",
                data: {
                    systemcoding: systemcoding,
                    roles: roles
                },
                success: function (res) {
                    console.log(JSON.stringify(res.data));
                    var data = res.data;
                    tree.reload("treeMenu", {
                        data: data
                    });
                    layer.close(index);
                }
            });
        }
        getXtbm($("#SystemCoding"), $("#hdSystemCoding").val());

        if ($("#hdRoleId").val() != "") {
            $("#SystemCoding").attr("disabled", "disabled");
            $("#SystemCoding").addClass("layui-disabled");
            getCdxx($("#hdSystemCoding").val(),$("#hdMenuIds").val());
        }
  
        form.on("select(SystemCoding)", function (obj) {
            $("#treeMenu").html("");
            if (obj.value.length > 0) {
                getCdxx(obj.value, "");
            }
        });


        $("#btnClose").on("click",
            function () {
                parent.layer.closeAll();
            });

        //监听提交
        form.on("submit(btnSave)",
            function () {
                var checkedData = tree.getChecked("treeMenu"); //获取选中节点的数据
                if (checkedData.length == 0) {
                    layer.msg("至少选择一个菜单", { icon: 5, time: 2000, anim: 6 });
                    return false;
                }
                let jsqx = "";
                $.each(checkedData, function (index, value) {
                    jsqx += value.id + ","
                    $.each(value.children, function (index, value) {
                        jsqx += value.id + ","
                    });
                });
                console.log(jsqx.substr(0, jsqx.lastIndexOf(',')));
            
                editData("RoleAdd", {
                    SystemCoding: $("#SystemCoding").val(),
                    RoleName: $("#RoleName").val(),
                    RoleId: $("#hdRoleId").val(),
                    RoleMenuIds: jsqx.substr(0, jsqx.lastIndexOf(','))
                }, $("#btnSave"), function () {
                    parent.layer.closeAll();
                    parent.tools.reloadTable();
                });
                return false;
            });
    });
}