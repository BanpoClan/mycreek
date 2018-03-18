(function () {
    $(function () {
        var _service = abp.services.app.menuMgr;


        function initPage(service) {
            treeControl.getMenuList(service);
            tableControl.initTable(service);
        }

        initPage(_service);
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
            submit();
        });

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'menus/PartialFieldModal',
            scriptUrl: abp.appPath + 'Views/Menus/_PartialFieldModal.js',
            modalClass: 'CreateOrEditRoleModal'
        });

        _createOrEditModal.open();

    });



   
})();