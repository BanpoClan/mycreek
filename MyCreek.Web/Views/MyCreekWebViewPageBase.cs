using Abp.Web.Mvc.Views;

namespace MyCreek.Web.Views
{
    public abstract class MyCreekWebViewPageBase : MyCreekWebViewPageBase<dynamic>
    {

    }

    public abstract class MyCreekWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MyCreekWebViewPageBase()
        {
            LocalizationSourceName = MyCreekConsts.LocalizationSourceName;
        }
    }
}