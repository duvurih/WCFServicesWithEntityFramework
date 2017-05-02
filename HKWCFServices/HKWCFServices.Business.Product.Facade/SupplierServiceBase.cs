using HKWCFServices.Business.Shared.WCFBaseClasses;


namespace HKWCFServices.Business.Product.Facade
{
    public abstract class SupplierServiceBase: WCFService
    {
        protected override void InitializeService()
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
