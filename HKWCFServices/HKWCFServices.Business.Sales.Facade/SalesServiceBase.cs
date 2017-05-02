using HKWCFServices.Business.Shared.WCFBaseClasses;

namespace HKWCFServices.Business.Sales.Facade
{
    public abstract class SalesServiceBase : WCFService
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
