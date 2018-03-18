var tableControl = {
    initTable: function (_service, _createOrEditModal) {
        $('#FieldsContainer').jtable({
            paging: true,
            sorting: true,
            multiSorting: true,
            actions: {

                listAction: {
                    method: _service.getFields
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
                                tableControl.deleteData(_service,data.record.id);
                            });
                        return $span;
                    }
                },
                colName: {
                    title: '列名',
                    width: '40%'
                },
                colType: {
                    title: '类型',
                    width: '20%'
                },
                isNull: {
                    title: '是否可以为空',
                    width: '30%',
                    type: 'date',
                    create: false,
                    edit: false
                }
            }
        });
        $('#FieldsContainer').jtable('load', { MenuGuid: '42a0ab72-1ff4-4187-98db-488636841968', Filter: '' });

    },
    deleteData: function (_service,id) {
        _service.deleField(id);
        $('#FieldsContainer').jtable('load', { MenuGuid: '42a0ab72-1ff4-4187-98db-488636841968', Filter: '' });
    }
};