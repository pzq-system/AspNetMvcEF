window.onload = function () {
    layui.use(["form", "layer"], function () {
        var form = layui.form, //只有执行了这一步，部分表单元素才会自动修饰成功
            $ = layui.jquery;

        //getDict("9999", $("#drpXtbm"), $("#hdXtbm").val());

        getXtbm($("#SystemCoding"), $("#hdSystemCoding").val());


        $("#btnClose").on("click", function () {
            parent.layer.closeAll();
        });

        $("#btnIcon").on("click", function () {
            parent.layer.open({
                title: "字体图标",
                type: 2,
                anim: 2,
                offset: "lb",
                content: "GetIcon",
                area: ["950px", "100%"]
            });
        });

        //监听提交
        form.on("submit(btnSave)", function () {

            editData($("#hdId").val() == "" ? "MenuCategroyAdd" : "MenuCategroyUpdate", form.val("component-form-group"), $("#btnSave"), function () {
                parent.layer.closeAll();
                parent.tools.reloadTable();
            });
            return false;
        });
    });
}