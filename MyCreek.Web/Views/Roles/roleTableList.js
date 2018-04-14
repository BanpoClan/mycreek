var roleTableList = {
    initTable: function (_service, _createOrEditModal) {
        $('#list').jtable({
            paging: true,
            sorting: true,
            multiSorting: true,
            actions: {

                listAction: {
                    method: _service.getRoles
                }

            },
            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: '操作',//操作列
                    width: '15%',
                    sorting: false,
                    display: function (data) {
                        var $span = $('<span></span>');
                        $('<button class="btn btn-default btn-xs" title="编辑"><i class="fa fa-edit"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                _createOrEditModal.open({ id: data.record.id });
                            });

                        $('<button class="btn btn-default btn-xs" title="删除"><i class="fa fa-trash-o"></i></button>')
                            .appendTo($span)
                            .click(function () {
                                tableControl.deleteData(_service, data.record.id);
                            });
                        return $span;
                    }
                },
                name: {
                    title: '角色名称',
                    width: '10%'
                },
                displayName: {
                    title: '显示名称',
                    width: '10%'
                },
                description: {
                    title: '角色描述',
                    width: '40%'
                },
                isStatic: {
                    title: '是否可以修改',
                    width: '10%'
                },
            }
        });
        $('#list').jtable('load', { MenuGuid: '42a0ab72-1ff4-4187-98db-488636841968', Filter: '' });

    },
    deleteData: function (_service, id) {
        _service.deleField(id);
        $('#list').jtable('load', { MenuGuid: '42a0ab72-1ff4-4187-98db-488636841968', Filter: '' });
    }
};