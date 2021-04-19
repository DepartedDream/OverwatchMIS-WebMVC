$(document).ready(function autoSubmitSelect() {//表格选择后自动刷新
    $("#table_type_select").change(function () {
        var tableType = $("select option:selected").val();
        window.location.replace(`/Admin/AdminMain?tableType=${tableType}`)
    })
})

//获取get方法传递的datatable并修改select的选定值并判断操作是否成功
$(document).ready(function modifySelectAndConfimOperate() {
    var aQuery = window.location.href.split("?");
    var aGET = new Array();
    if (aQuery.length > 1) {//判断是否存在get参数
        var aBuf = aQuery[1].split("&");
        for (var i = 0; i < aBuf.length; i++) {
            var aTmp = aBuf[i].split("=");  //分离key与Value
            aGET[aTmp[0]] = aTmp[1];
        }
        var tableTypeValue = decodeURIComponent(aGET["tableType"]);
        $("#table_type_select").val(tableTypeValue);
        if (aGET["status"] == "False" || aGET["status"] == "false") {
            alert("操作失败")
        }
    }
})

$(document).ready(function () {//绑定编辑按钮事件
    $(".edit_input").click(function () {
        var currentRow = $(this).parent().parent();
        var tdArrayDom = currentRow.children("td");
        for (i = 0; i < tdArrayDom.length; i++) {
            if ($(tdArrayDom[i]).text() != "") {
                input = $(`<input type=\"text\" spellcheck=\"false\" value=${$(tdArrayDom[i]).text()}>`)
                $(tdArrayDom[i]).text("");
                $(tdArrayDom[i]).append(input);
            }
        }
        var tableType = $("select option:selected").val();
        /*将编辑按钮变为修改按钮*/
        $(this).unbind("click");
        var oldId = $($(currentRow.children("td")[0]).children("input")[0]).val();
        $(this).attr({ value: "修改", oldId: oldId });
        $(this).click(function () {//绑定更新按钮事件
            var oldId = $(this).attr("oldId");
            var text1 = $($(currentRow.children("td")[0]).children("input")[0]).val();
            var text2 = $($(currentRow.children("td")[1]).children("input")[0]).val();
            var text3 = $($(currentRow.children("td")[2]).children("input")[0]).val();
            var text4 = $($(currentRow.children("td")[3]).children("input")[0]).val();
            window.location.replace(`/Admin/AdminUpdate?tableType=${tableType}&oldId=${oldId}&text1=${text1}&text2=${text2}&text3=${text3}&text4=${text4}`);
        })
        /*将删除按钮变为取消按钮*/
        var deleteInput = $(this).next();
        deleteInput.unbind("click");
        deleteInput.attr("value", "取消");
        deleteInput.click(function () {//绑定取消按钮事件
            window.location.replace(`/Admin/AdminMain?tableType=${tableType}`)
        })
    })
})

$(document).ready(function () {//绑定删除按钮事件
    $(".delete_input").click(function () {
        var currentRow = $(this).parent().parent()
        var text1 = $(currentRow.children("td")[0]).text();
        var tableType = $("select option:selected").val();
        window.location.replace(`/Admin/AdminDelete?tableType=${tableType}&text1=${text1}`);
    })
})

$(document).ready(function () {//绑定添加按钮事件
    $("#insert_input").click(function () {
        var currentRow = $(this).parent().parent();
        var tableType = $("select option:selected").val();
        var text1 = $($(currentRow.children("td")[0]).children("input")[0]).val();
        var text2 = $($(currentRow.children("td")[1]).children("input")[0]).val();
        var text3 = $($(currentRow.children("td")[2]).children("input")[0]).val();
        var text4 = $($(currentRow.children("td")[3]).children("input")[0]).val();
        window.location.replace(`/Admin/AdminInsert?tableType=${tableType}&text1=${text1}&text2=${text2}&text3=${text3}&text4=${text4}`);
    })
})