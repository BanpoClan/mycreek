(function () {
    $(function () {
        var _service = abp.services.app.menuMgr;

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'menus/PartialFieldModal',
            scriptUrl: abp.appPath + 'Views/Menus/_PartialFieldModal.js',
            modalClass: 'CreateOrEditModal'
        });

        function initPage(service) {
            treeControl.getMenuList(service);
            tableControl.initTable(service, _createOrEditModal);
        }

        initPage(_service, _createOrEditModal);

        function submit() {
            var _$form = $("#form_validation");
            var menu = _$form.serializeFormToObject();

            $(".page-loader-wrapper").show();
            _service.addAdditional(
                menu
            ).done(function () {
                abp.notify.info(abp.localization.localize('SavedSuccessfully'));
                $(".page-loader-wrapper").hide();
            }); 
        }
        $("#submit").on("click", function () {
            var menuGuid = $("input[name='MenuGuid']").val();
            if (menuGuid) {
                submit();
            }
            else {
                abp.message.info('请选择一个功能节点!');
            }
            
        });

        

        $("#btnAddField").on("click", function () {
            var menuGuid = $("input[name='MenuGuid']").val();
            if (menuGuid) {
                _createOrEditModal.open({ id: 0, menuGuid: menuGuid });
            }
            else {
                abp.message.info('请选择一个功能节点!');
            }
           
        });


        $("#btnCreateDBStruct").on("click", function () {
            var menuGuid = $("input[name='MenuGuid']").val();
            if (menuGuid) {
                _service.createCustomFeatureStruct(menuGuid).done(function (result) {
                    abp.notify.info('SavedSuccessfully');
                });
            }
            else {
                abp.message.info('请选择一个功能节点!');
            }

        });

        abp.event.on('app.createOrEditRoleModalSaved', function () {
            tableControl.initTable(_service, _createOrEditModal);
        });


        uediterControl.bindControl();

   
       
    });



   
})();