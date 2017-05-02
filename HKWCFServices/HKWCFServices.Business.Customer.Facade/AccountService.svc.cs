using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using HKWCFServices.Business.Customer.Contracts.Service;
using HKWCFServices.Business.Shared.ExceptionHandling;

namespace HKWCFServices.Business.Customer.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountService.svc or AccountService.svc.cs at the Solution Explorer and start debugging.
    [GlobalExceptionHandlerBehavior(typeof(GlobalExceptionHandling))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, AddressFilterMode = AddressFilterMode.Any)]
    public class AccountService : IAccountMgmtService
    {
 
        public string GetAccountById(string accountId)
        {
            throw new NotImplementedException();
        }
    }
}
