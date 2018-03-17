(function () {
    $(function () {
        var _roleService = abp.services.app.menuMgr;
        function getMenuList() {
            _roleService.getListDto().done(function (data) {
                initTree(data);
            });
        }
       
        getMenuList();

        function initTree(zNodes) {
            var setting = {
                view: {
                    addHoverDom: addHoverDom,
                    removeHoverDom: removeHoverDom,
                    selectedMulti: false
                },
                check: {
                    enable: true
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
                        debugger;
                        //创建菜单
                    },
                    onCheck: function (event, treeId, node) {
                        debugger;
                        $("#curNode").html("当前节点:" + node.name);
                        $("#form_validation input[name='MenuGuid']").val(node.id);
                        $("#form_validation input[name='ParentMenuGuid']").val(node.pId);
                        $("#form_validation input[name='DisplayName']").val(node.name);
                    },
                }
            };


            $.fn.zTree.init($("#treeDemo"), setting, zNodes);
        }

        var newCount = 1;
        function addHoverDom(treeId, treeNode) {
            var sObj = $("#" + treeNode.tId + "_span");
            if (treeNode.editNameFlag || $("#addBtn_" + treeNode.tId).length > 0) return;
            var addStr = "<span class='button add' id='addBtn_" + treeNode.tId
                + "' title='add node' onfocus='this.blur();'></span>";
            sObj.after(addStr);
            var btn = $("#addBtn_" + treeNode.tId);
            if (btn) btn.bind("click", function () {
                var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                zTree.addNodes(treeNode, { id: (100 + newCount), pId: treeNode.id, name: "new node" + (newCount++) });
                return false;
            });
        };
        function removeHoverDom(treeId, treeNode) {
            $("#addBtn_" + treeNode.tId).unbind().remove();
        };




    });
})();