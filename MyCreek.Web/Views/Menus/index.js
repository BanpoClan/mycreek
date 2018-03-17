(function () {
    $(function () {
        initPage();
        var _service = abp.services.app.menuMgr;
        function getMenuList() {
            _service.getListDto().done(function (data) {
                initTree(data);
            });
        }

        getMenuList();

        function initPage() {
           
        }

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

        tableControl.initTable();

    });


    var tableControl = {
        initTable: function () {
            $('#OrdersTableContainer').jtable({
                title: 'Orders list',
                paging: true, //Enable paging
                pageSize: 10, //Set page size (default: 10)
                sorting: true, //Enable sorting
                defaultSorting: 'Order Date DESC', //Set default sorting
                actions: {
                    listAction: '/Actions/OrdersList',
                    createAction: '/Actions/CreateOrder',
                    updateAction: '/Actions/UpdateOrder',
                    deleteAction: '/Actions/DeleteOrder'
                },
                fields: {
                    'Order Id': {
                        key: true,
                        list: false
                    },
                    //CHILD TABLE DEFINITION FOR "DETAILS"
                    'Details': {
                        title: '',
                        width: '5%',
                        sorting: false,
                        edit: false,
                        create: false,
                        display: function (OrderData) {
                            //Create an image that will be used to open child table
                            var $img = $('<img src="http://www.codeproject.com/Content/Images/list_metro.png" ' +
                                'title="Edit order details" />');
                            //Open child table when user clicks the image
                            $img.click(function () {
                                $('#OrdersTableContainer').jtable('openChildTable',
                                    $img.closest('tr'),
                                    {
                                        title: OrderData.record['Ship Name'] +
                                        ' - Order Details',
                                        actions: {
                                            listAction:
                                            '/Actions/ChildTable/DetailsList?OrderId='
                                            + OrderData.record['Order Id'],
                                            deleteAction: '/Actions/ChildTable/DeleteDetail',
                                            updateAction: '/Actions/ChildTable/UpdateDetail',
                                            createAction: '/Actions/ChildTable/CreateDetail'
                                        },
                                        fields: {
                                            'Order Id': {
                                                type: 'hidden',
                                                defaultValue: OrderData.record['Order Id']
                                            },
                                            'Detail Id': {
                                                key: true,
                                                create: false,
                                                edit: false,
                                                list: false
                                            },
                                            'Product Name': {
                                                title: 'Product',
                                                width: '50%'
                                            },
                                            'Unit Price': {
                                                title: 'Unit Price',
                                                width: '25%'
                                            },
                                            'Quantity': {
                                                title: 'Quantity',
                                                width: '25%'
                                            }
                                        }
                                    }, function (data) {
                                        data.childTable.jtable('load');
                                    });
                            });
                            //Return image to show on the order row
                            return $img;
                        }
                    },
                    'Ship Name': {
                        title: 'Firm',
                        width: '40%'
                    },
                    'Ship Country': {
                        title: 'Country',
                        width: '20%'
                    },
                    'Order Date': {
                        title: 'Order',
                        width: '20%',
                        type: 'date'
                    },
                    'Shipped': {
                        title: 'Shipped',
                        width: '20%',
                        type: 'checkbox',
                        values: { 'false': 'False', 'true': 'True' }
                    }
                }
            });
            $('#OrdersTableContainer').jtable('load');
        }
    };
})();