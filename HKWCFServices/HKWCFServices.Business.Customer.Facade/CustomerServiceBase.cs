using HKWCFServices.Business.Shared.WCFBaseClasses;

namespace HKWCFServices.Business.Customer.Facade
{
    public abstract class CustomerServiceBase: WCFService
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