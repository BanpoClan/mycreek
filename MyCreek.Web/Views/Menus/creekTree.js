var treeControl = {
    getMenuList: function (service) {
        service.getListDto().done(function (data) {
            treeControl.initTree(service, data);
        });
    },
    initTree: function (service, zNodes) {
        var setting = {
            view: {
                addHoverDom: treeControl.addHoverDom,
                removeHoverDom: treeControl.removeHoverDom,
                selectedMulti: false
            },
            check: {
                enable: true, chkStyle: 'radio', radioType: 'level'
            },
            data: {
                simpleData: {
                    enable: true
                }
            },
            edit: {
                enable: true
            },
            callback: {
                onRename: function (event, treeId, treeNode, isCancel) {

                    //创建菜单
                    treeControl.createMenu(service, treeNode);
                },
                onCheck: function (event, treeId, node) {

                    $("#form_validation input[name='MenuGuid']").val(node.id);
                    $("#form_validation input[name='ParentMenuGuid']").val(node.pId);
                    $("#form_validation input[name='DisplayName']").val(node.name);
                },
                onRemove: function (e, treeId, treeNode) {


                    if (treeNode.id.length > 10) {
                        service.delete({ MenuGuid: treeNode.id }).done(function () {
                            debugger;
                            abp.notify.info(abp.localization.localize('SavedSuccessfully'));
                            treeControl.getMenuList(service);
                        });
                    }


                }
            }
        };


        $.fn.zTree.init($("#treeDemo"), setting, zNodes);
    },
    addHoverDom: function (treeId, treeNode) {
        var sObj = $("#" + treeNode.tId + "_span");
        if (treeNode.editNameFlag || $("#addBtn_" + treeNode.tId).length > 0) return;
        var addStr = "<span class='button add' id='addBtn_" + treeNode.tId
            + "' title='add node' onfocus='this.blur();'></span>";
        sObj.after(addStr);
        var btn = $("#addBtn_" + treeNode.tId);
        if (btn) btn.bind("click", function () {
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            zTree.addNodes(treeNode, { id: (100 + treeControl.newCount), pId: treeNode.id, name: "new node" + (treeControl.newCount++) });
            return false;
        });
    },
    newCount: 1,

    removeHoverDom: function (treeId, treeNode) {
        $("#addBtn_" + treeNode.tId).unbind().remove();
    },
    createMenu: function (service, node) {
        var menu = {};
        menu["Name"] = node.name;
        menu["PId"] = node.pId;
        menu["Id"] = node.id;


        $(".page-loader-wrapper").show();
        service.createOrEdit(
            menu
        ).done(function () {

            abp.notify.info(abp.localization.localize('SavedSuccessfully'));
            treeControl.getMenuList(service);
            $(".page-loader-wrapper").hide();
        });

    }

};