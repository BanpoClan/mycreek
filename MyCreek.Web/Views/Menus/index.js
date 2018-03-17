(function () {
    $(function () {
        var _service = abp.services.app.menuMgr;
        function getMenuList() {
            _service.getListDto().done(function (data) {
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
                        createMenu(treeNode);
                    },
                    onCheck: function (event, treeId, node) {
                        $("#curNode").html("当前节点:" + node.name);
                        $("#form_validation input[name='MenuGuid']").val(node.id);
                        $("#form_validation input[name='ParentMenuGuid']").val(node.pId);
                        $("#form_validation input[name='DisplayName']").val(node.name);
                    },
                    onRemove: function (e, treeId, treeNode) {
                    

                        if (treeNode.id.length > 10) {
                            _service.delete({ MenuGuid: treeNode.id }).done(function () {
                                debugger;
                                abp.notify.info(abp.localization.localize('SavedSuccessfully'));
                                getMenuList();
                            });
                        }


                    }
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

        function createMenu(node) {
            var menu = {};
            menu["Name"] = node.name;
            menu["PId"] = node.pId;
            menu["Id"] = node.id;


            $(".page-loader-wrapper").show();
            _service.createOrEdit(
                menu
            ).done(function () {
                
                abp.notify.info(abp.localization.localize('SavedSuccessfully'));
                getMenuList();
                $(".page-loader-wrapper").hide();
            });

        }

        

        function submit() {
            var _$form = $("#form_validation");
            var menu = _$form.serializeFormToObject();
            debugger;
            $(".page-loader-wrapper").show();
            _service.addAdditional(
                menu
            ).done(function () {
                debugger;
                abp.notify.info(abp.localization.localize('SavedSuccessfully'));
                $(".page-loader-wrapper").hide();
            });
        }
        $("#submit").on("click", function () {
            submit();
        });



    });
})();