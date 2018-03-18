(function () {
    app.modals.CreateOrEditModal = function () {

        var _modalManager;
        var _service = abp.services.app.menuMgr;
        var form = null;
     

        this.init = function (modalManager) {
            _modalManager = modalManager;
            form = _modalManager.getModal().find('form');
            form.validate({ ignore: "" });
            this.setFoucs(form);
        };

        this.setFoucs = function (form) {
            $(form).find('input').each(function () {
                if ($(this).val().length > 0)
                {
                    $(this).parent().addClass('focused');
                }

                $(this).focus(function () {
                    $(this).parent().addClass('focused');
                });
                $(this).blur(function () {
                    if ($(this).val().length == 0) {
                        $(this).parent().removeClass('focused');
                    }
                    
                });
            });
        }

        this.save = function () {
            if (!form.valid()) {
                return;
            }

            var obj = form.serializeFormToObject();
            if (field.IsNull == "on") 
            {
                obj.IsNull = true;
            }
            else {
                obj.IsNull = false;
            }
            
            _modalManager.setBusy(true);
            _service.createOrEditField(obj).done(function () {
                abp.notify.info('SavedSuccessfully');
                _modalManager.close();
                abp.event.trigger('app.createOrEditRoleModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();