layui.use(["form", "layer"], function () {
    var form = layui.form, //只有执行了这一步，部分表单元素才会自动修饰成功
        $ = layui.jquery;

    $("#btnClose").on("click", function () {
        parent.layer.closeAll();
    });

    //监听提交
    form.on("submit(btnSave)", function () {

        var url;
        if ($("#Id").val() == "") {
            url = "add";
        } else {
            url = "Update";
        }
        editData(url, form.val("component-form-group"), $("#btnSave"), function () {
            parent.layer.closeAll();
            parent.tools.reloadTable();
        });
        return false;
    });
});
